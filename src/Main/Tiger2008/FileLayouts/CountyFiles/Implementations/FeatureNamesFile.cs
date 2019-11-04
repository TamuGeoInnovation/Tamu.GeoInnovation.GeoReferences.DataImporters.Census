using System;
using System.Data;
using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.AbstractClasses;
using USC.GISResearchLab.Common.Databases.Dbf;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.Implementations
{
    public class FeatureNamesFile : AbstractTiger2008CountyFileLayout
    {
        public FeatureNamesFile(string stateName)
            : base(stateName)
        {
            FileName = "featnames.zip";

            HasSoundexColumns = true;
            SoundexColumns = new string[] { "Name" };

            HasSoundexDMColumns = true;
            SoundexDMColumns = new string[] { "Name" };

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "tlid int NOT NULL,";
            SQLCreateTable += "fullName varchar(100) DEFAULT NULL,";
            SQLCreateTable += "name varchar(100) DEFAULT NULL,";
            SQLCreateTable += "name_Soundex varchar(4) DEFAULT NULL,";
            SQLCreateTable += "name_SoundexDM varchar(6) DEFAULT NULL,";
            SQLCreateTable += "preDirAbrv varchar(15) DEFAULT NULL,";
            SQLCreateTable += "preTypAbrv varchar(50) DEFAULT NULL,";
            SQLCreateTable += "preQualAbr varchar(15) DEFAULT NULL,";
            SQLCreateTable += "sufDirAbrv varchar(15) DEFAULT NULL,";
            SQLCreateTable += "sufTypAbrv varchar(50) DEFAULT NULL,";
            SQLCreateTable += "sufQualAbr varchar(15) DEFAULT NULL,";
            SQLCreateTable += "preDir varchar(2) DEFAULT NULL,";
            SQLCreateTable += "preTyp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "preQual varchar(2) DEFAULT NULL,";
            SQLCreateTable += "sufDir varchar(2) DEFAULT NULL,";
            SQLCreateTable += "sufTyp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "sufQual varchar(2) DEFAULT NULL,";
            SQLCreateTable += "lineArid varchar(22) DEFAULT NULL,";
            SQLCreateTable += "mtFCC varchar(5) DEFAULT NULL,";
            SQLCreateTable += "paFlag varchar(1) DEFAULT NULL, ";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_tlid_lineArid] PRIMARY KEY CLUSTERED ([tlid], [lineArid] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLAlterTableAddForeignKeys += " ALTER TABLE [" + OutputTableName + "] ";
            SQLAlterTableAddForeignKeys += " ADD ";
            SQLAlterTableAddForeignKeys += " CONSTRAINT [FK_" + OutputTableName + "_tlid] FOREIGN KEY (tlid) REFERENCES " + stateName + "_edges (tlid)";
            SQLAlterTableAddForeignKeys += " ;";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_tlid] ON [dbo].[" + OutputTableName + "](	tlid ASC)INCLUDE (fullName, name, preDirAbrv, preTypAbrv, preQualAbr, sufDirAbrv, sufTypAbrv, sufQualAbr) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ; ";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_name_Soundex] ON [dbo].[" + OutputTableName + "] ([name_Soundex]) INCLUDE ([tlid],[fullName],[name],[name_SoundexDM],[preDirAbrv],[preTypAbrv],[preQualAbr],[sufDirAbrv],[sufTypAbrv],[sufQualAbr]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ; ";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_name] ON [dbo].[" + OutputTableName + "] ([name]) INCLUDE ([tlid],[fullName],[name_Soundex],[name_SoundexDM],[preDirAbrv],[preTypAbrv],[preQualAbr],[sufDirAbrv],[sufTypAbrv],[sufQualAbr]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ; ";


            SQLPostInsertTableDelete += " DELETE FROM [" + OutputTableName + "] ";
            SQLPostInsertTableDelete += " WHERE ";
            SQLPostInsertTableDelete += "  [" + OutputTableName + "].[tlid] NOT IN ";
            SQLPostInsertTableDelete += "   ( ";
            SQLPostInsertTableDelete += "     SELECT ";
            SQLPostInsertTableDelete += "      tlid ";
            SQLPostInsertTableDelete += "     FROM ";
            SQLPostInsertTableDelete += "      dbo." + StateName + "_edges ";
            SQLPostInsertTableDelete += "    ); ";

        }

        public override IDataReader GetDataReader(string fileLocation)
        {
            DbfDataReaderAddSoundex ret = null;

            try
            {
                ret = new DbfDataReaderAddSoundex(fileLocation);
                ret.NotifyAfter = 10;
                ret.IncludeSoundex = HasSoundexColumns;
                ret.SoundexColumns = SoundexColumns;
                ret.IncludeSoundexDM = HasSoundexDMColumns;
                ret.SoundexDMColumns = SoundexDMColumns;

            }
            catch (Exception e)
            {
                throw new Exception("Error getting datatable: " + e.Message, e);
            }

            return ret;
        }
    }
}
