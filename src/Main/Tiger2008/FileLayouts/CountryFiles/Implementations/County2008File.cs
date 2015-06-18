using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.Implementations
{
    public class County2008File : AbstractTiger2008ShapefileCountryFileLayout
    {

        public County2008File(string stateName)
            : base(stateName)
        {

            FileName = "county.zip";

            HasSoundexColumns = true;
            HasSoundexDMColumns = true;
            SoundexColumns = new string[] { "Name" };
            SoundexDMColumns = new string[] { "Name" };

            ShouldIncludeArea = true;
            ShouldIncludeCentroid = true;

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "stateFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "countyNs varchar(8) DEFAULT NULL,";
            SQLCreateTable += "cntyIdFp varchar(5) DEFAULT NULL,";
            SQLCreateTable += "Name varchar(100) DEFAULT NULL,";
            SQLCreateTable += "Name_Soundex varchar(4) DEFAULT NULL,";
            SQLCreateTable += "Name_SoundexDM varchar(6) DEFAULT NULL,";
            SQLCreateTable += "NameLsad varchar(100) DEFAULT NULL,";
            SQLCreateTable += "lsad varchar(2) DEFAULT NULL,";
            SQLCreateTable += "classFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc varchar(5) DEFAULT NULL,";
            SQLCreateTable += "csAfp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "cbsaFp varchar(5) DEFAULT NULL,";
            SQLCreateTable += "metDivFp varchar(5) DEFAULT NULL,";
            SQLCreateTable += "funcStat varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "shapeArea varchar(55) ,";
            SQLCreateTable += "centroidX varchar(55) ,";
            SQLCreateTable += "centroidY varchar(55) ,";
            SQLCreateTable += "PRIMARY KEY  (cntyIdFp)";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name] ON [dbo].[" + OutputTableName + "] (Name) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name_Soundex] ON [dbo].[" + OutputTableName + "] (Name_Soundex) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name_SoundexDM] ON [dbo].[" + OutputTableName + "] (Name_SoundexDM) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
        }
    }
}
