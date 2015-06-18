﻿using USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.StateFiles.Implementations
{
    public class CountySub2010File : AbstractTiger2010ShapefileStateFileLayout
    {

        public CountySub2010File(string stateName)
            : base(stateName)
        {

            FileName = "cousub10.zip";

            HasSoundexColumns = true;
            HasSoundexDMColumns = true;
            SoundexColumns = new string[] { "Name10" };
            SoundexDMColumns = new string[] { "Name10" };

            //ExcludeColumns = new string[] { "Name00_Soundex", "Name00_SoundexDM" };

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "stateFp10 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp10 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "cousubFp10 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "cousubNs10 varchar(8) DEFAULT NULL,";
            SQLCreateTable += "GeoId10 varchar(10) DEFAULT NULL,";
            SQLCreateTable += "Name10 varchar(100) DEFAULT NULL,";
            SQLCreateTable += "Name10_Soundex varchar(4) DEFAULT NULL,";
            SQLCreateTable += "Name10_SoundexDM varchar(6) DEFAULT NULL,";
            SQLCreateTable += "NameLsad10 varchar(100) DEFAULT NULL,";
            SQLCreateTable += "lsad10 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "classFp10 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc10 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "cnectaFp10 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "nectaFp10 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "nctadvFp10 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat10 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "aLand10 varchar(14) DEFAULT NULL,";
            SQLCreateTable += "aWater10 varchar(14) DEFAULT NULL,";
            SQLCreateTable += "intPtLat10 varchar(11) DEFAULT NULL,";
            SQLCreateTable += "intPtLon10 varchar(12) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_cousubFp] PRIMARY KEY CLUSTERED ([cousubFp10] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name10] ON [dbo].[" + OutputTableName + "] (Name10) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name10_Soundex] ON [dbo].[" + OutputTableName + "] (Name10_Soundex) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name10_SoundexDM] ON [dbo].[" + OutputTableName + "] (Name10_SoundexDM) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
        }
    }
}
