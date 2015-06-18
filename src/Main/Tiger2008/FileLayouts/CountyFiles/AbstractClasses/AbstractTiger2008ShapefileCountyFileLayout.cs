using System;
using System.Data;
using Reimers.Esri;
using USC.GISResearchLab.Common.Shapefiles.ShapefileReaders;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.AbstractClasses
{
    public abstract class AbstractTiger2008ShapefileCountyFileLayout : AbstractTiger2008CountyFileLayout
    {
        #region Events

        public event ShapefileRecordReadHandler ShapefileRecordRead;
        public event ShapefileRecordConvertedHandler ShapefileRecordConverted;
        public event PercentReadHandler PercentRead;
        public event RecordsReadHandler RecordsRead;

        #endregion

        #region Delegates

        public delegate void ShapefileRecordReadHandler(int numberOfRecordsRead);
        public delegate void ShapefileRecordConvertedHandler(int numberOfRecordsComputed);
        public delegate void PercentReadHandler(double percentRead);
        public delegate void RecordsReadHandler(int recordsRead, int totalRecords);

        #endregion


        public AbstractTiger2008ShapefileCountyFileLayout(string tableName)
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

                ret = shapeFile.GetShapefileAsDataTable(false, true, false, false, false, false, false, 4269);
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
                ret.PercentRead += new Reimers.Esri.PercentReadHandler(shapeFile_PercentRead);
                ret.RecordsRead += new Reimers.Esri.RecordsReadHandler(shapeFile_RecordsRead);
                ret.NotifyAfter = 10;
                ret.SRID = 4269;
                ret.IncludeSqlGeography = true;
                ret.IncludeSqlGeometry = true;
                ret.IncludeSoundex = HasSoundexColumns;
                ret.IncludeSoundexDM = HasSoundexDMColumns;
                ret.SoundexColumns = SoundexColumns;
                ret.SoundexDMColumns = SoundexDMColumns;
                ret.IncludeLineEndPoints = HasEndPointsColumns;
                ret.IncludeLineEndPointsColumns = EndPointsColumns;
                ret.ShouldAddEvenOddFlag = ShouldAddEvenOddFlag;
                ret.AddEvenOddFlagColumns = AddEvenOddFlagColumns;
                ret.ShouldSplitAddressRanges = ShouldSplitAddressRanges;
                ret.SplitAddressRangesColumns = SplitAddressRangesColumns;

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

        private void shapeFile_PercentRead(double percentRead)
        {
            if (PercentRead != null)
            {
                PercentRead(percentRead);
            }
        }

        private void shapeFile_RecordsRead(int recordsRead, int totalRecords)
        {
            if (RecordsRead != null)
            {
                RecordsRead(recordsRead, totalRecords);
            }
        }
    }
}
