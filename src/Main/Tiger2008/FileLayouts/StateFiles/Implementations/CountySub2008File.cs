using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.Implementations
{
    public class CountySub2008File : AbstractTiger2008ShapefileStateFileLayout
    {

        public CountySub2008File(string stateName)
            : base(stateName)
        {

            FileName = "cousub.zip";

            HasSoundexColumns = true;
            HasSoundexDMColumns = true;
            SoundexColumns = new string[] { "Name" };
            SoundexDMColumns = new string[] { "Name" };

            //ExcludeColumns = new string[] { "Name00_Soundex", "Name00_SoundexDM" };

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "stateFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "cousubFp varchar(5) DEFAULT NULL,";
            SQLCreateTable += "cousubNs varchar(8) DEFAULT NULL,";
            SQLCreateTable += "cosbIdFp varchar(10) DEFAULT NULL,";
            SQLCreateTable += "Name varchar(100) DEFAULT NULL,";
            SQLCreateTable += "Name_Soundex varchar(4) DEFAULT NULL,";
            SQLCreateTable += "Name_SoundexDM varchar(6) DEFAULT NULL,";
            SQLCreateTable += "NameLsad varchar(100) DEFAULT NULL,";
            SQLCreateTable += "lsad varchar(2) DEFAULT NULL,";
            SQLCreateTable += "classFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc varchar(5) DEFAULT NULL,";
            SQLCreateTable += "cnectaFp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "nectaFp varchar(5) DEFAULT NULL,";
            SQLCreateTable += "nctadvFp varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_cousubFp] PRIMARY KEY CLUSTERED ([cousubFp] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name] ON [dbo].[" + OutputTableName + "] (Name) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name_Soundex] ON [dbo].[" + OutputTableName + "] (Name_Soundex) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name_SoundexDM] ON [dbo].[" + OutputTableName + "] (Name_SoundexDM) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
        }
    }
}
