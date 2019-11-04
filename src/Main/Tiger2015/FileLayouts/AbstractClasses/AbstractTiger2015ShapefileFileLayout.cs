﻿using Reimers.Esri;
using System;
using System.Data;
using USC.GISResearchLab.Common.Shapefiles.ShapefileReaders;

namespace USC.GISResearchLab.Common.Census.Tiger2015.FileLayouts.AbstractClasses
{
    public abstract class AbstractTiger2015ShapefileFileLayout : AbstractTiger2015FileLayout
    {

        #region Events

        public event ShapefileRecordReadHandler ShapefileRecordRead;
        public event ShapefileRecordConvertedHandler ShapefileRecordConverted;

        #endregion

        #region Delegates

        public delegate void ShapefileRecordReadHandler(int numberOfRecordsRead);
        public delegate void ShapefileRecordConvertedHandler(int numberOfRecordsComputed);

        #endregion


        public AbstractTiger2015ShapefileFileLayout(string tableName)
            : base(tableName) { }

        public override DataTable GetDataTable(string fileLocation)
        {
            DataTable ret = null;

            try
            {
                Shapefile shapeFile = new Shapefile(fileLocation);
                shapeFile.NotifyAfter = 10;
                shapeFile.DbfRecordRead += new Reimers.Esri.DbfRecordReadHandler(dbfRecordRead);
                shapeFile.DbfNumberOfRecordsRead += new Reimers.Esri.DbfNumberOfRecordsReadHandler(dbfNumberOfRecordsRead);
                shapeFile.ShapefileRecordRead += new Reimers.Esri.ShapefileRecordReadHandler(shapeFile_ShapefileRecordRead);
                shapeFile.ShapefileRecordConverted += new Reimers.Esri.ShapefileRecordConvertedHandler(shapeFile_ShapeRecordConverted);

                ret = shapeFile.GetShapefileAsDataTable(false, true, false, false, false, true, true, 4269);
            }
            catch (Exception e)
            {
                throw new Exception("Error getting datatable: " + e.Message, e);
            }

            return ret;
        }

        public override IDataReader GetDataReader(string fileLocation)
        {
            ExtendedShapefileDataReader ret = null;

            try
            {
                ret = new ExtendedShapefileDataReader(fileLocation);
                ret.IncludeSqlGeography = true;
                ret.IncludeSqlGeometry = true;
                ret.IncludeSoundex = HasSoundexColumns;
                ret.IncludeSoundexDM = HasSoundexDMColumns;
                ret.SoundexColumns = SoundexColumns;
                ret.SoundexDMColumns = SoundexDMColumns;

            }
            catch (Exception e)
            {
                throw new Exception("Error getting datatable: " + e.Message, e);
            }

            return ret;
        }

        private void shapeFile_ShapefileRecordRead(int numberOfRecordsRead)
        {
            if (ShapefileRecordRead != null)
            {
                ShapefileRecordRead(numberOfRecordsRead);
            }
        }

        private void shapeFile_ShapeRecordConverted(int numberOfRecordsComputed)
        {
            if (ShapefileRecordConverted != null)
            {
                ShapefileRecordConverted(numberOfRecordsComputed);
            }
        }
    }
}
