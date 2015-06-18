using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.Implementations
{
    public class FacesFile : AbstractTiger2008CountyFileLayout
    {
        public FacesFile(string stateName)
            : base(stateName)
        {

            FileName = "faces.zip";

            ExcludeColumns = new string[] { 
                "countyName00", "couSubName00", "subMcdName00", "conCtyName00", "placeName00", 
                "countyName00_Soundex", "couSubName00_Soundex", "subMcdName00_Soundex", "conCtyName00_Soundex", "placeName00_Soundex", 
                "countyName00_SoundexDM", "couSubName00_SoundexDM", "subMcdName00_SoundexDM", "conCtyName00_SoundexDM", "placeName00_SoundexDM", 
            };

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "tfid int not null, ";
            SQLCreateTable += "stateFp00 varchar(2), ";
            SQLCreateTable += "countyFp00 varchar(3), ";
            SQLCreateTable += "countyName00 varchar(100), ";
            SQLCreateTable += "countyName00_Soundex varchar(4), ";
            SQLCreateTable += "countyName00_SoundexDM varchar(6), ";
            SQLCreateTable += "tractCe00 varchar(6), ";
            SQLCreateTable += "blkGrpCe00 varchar(1), ";
            SQLCreateTable += "blockCe00 varchar(4), ";
            SQLCreateTable += "suffix1Ce varchar(1), ";
            SQLCreateTable += "couSubFp00 varchar(5), ";
            SQLCreateTable += "couSubName00 varchar(100), ";
            SQLCreateTable += "couSubName00_Soundex varchar(4), ";
            SQLCreateTable += "couSubName00_SoundexDM varchar(6), ";
            SQLCreateTable += "subMcdFp00 varchar(5), ";
            SQLCreateTable += "subMcdName00 varchar(100), ";
            SQLCreateTable += "subMcdName00_Soundex varchar(4), ";
            SQLCreateTable += "subMcdName00_SoundexDM varchar(6), ";
            SQLCreateTable += "conCtyFp00 varchar(5), ";
            SQLCreateTable += "conCtyName00 varchar(100), ";
            SQLCreateTable += "conCtyName00_Soundex varchar(4), ";
            SQLCreateTable += "conCtyName00_SoundexDM varchar(6), ";
            SQLCreateTable += "placeFp00 varchar(5), ";
            SQLCreateTable += "placeName00 varchar(100), ";
            SQLCreateTable += "placeName00_Soundex varchar(4), ";
            SQLCreateTable += "placeName00_SoundexDM varchar(6), ";
            SQLCreateTable += "aiannhCe00 varchar(4), ";
            SQLCreateTable += "comptyp00 varchar(1), ";
            SQLCreateTable += "trSubCe00 varchar(3), ";
            SQLCreateTable += "tTractCe00 varchar(6), ";
            SQLCreateTable += "anrcFp00 varchar(5), ";
            SQLCreateTable += "elsDlea00 varchar(5), ";
            SQLCreateTable += "scsDlea00 varchar(5), ";
            SQLCreateTable += "unsDlea00 varchar(5), ";
            SQLCreateTable += "uAce00 varchar(5), ";
            SQLCreateTable += "uAce varchar(5), ";
            SQLCreateTable += "sldUst00 varchar(3), ";
            SQLCreateTable += "sldLst00 varchar(3), ";
            SQLCreateTable += "vtdSt00 varchar(6), ";
            SQLCreateTable += "tazCe00 varchar(6), ";
            SQLCreateTable += "ugaCe00 varchar(5), ";
            SQLCreateTable += "puma1Ce00 varchar(5), ";
            SQLCreateTable += "puma5Ce00 varchar(5), ";
            SQLCreateTable += "zcta5Ce00 varchar(5), ";
            SQLCreateTable += "zcta3Ce00 varchar(3), ";
            SQLCreateTable += "stateFp varchar(2), ";
            SQLCreateTable += "countyFp varchar(3), ";
            SQLCreateTable += "couSubFp varchar(5), ";
            SQLCreateTable += "subMcdFp varchar(5), ";
            SQLCreateTable += "conCtyFp varchar(5), ";
            SQLCreateTable += "placeFp varchar(5), ";
            SQLCreateTable += "aiannhCe varchar(4), ";
            SQLCreateTable += "compTyp varchar(1), ";
            SQLCreateTable += "anrCfp varchar(5), ";
            SQLCreateTable += "trSubCe varchar(3), ";
            SQLCreateTable += "cd108Fp varchar(2), ";
            SQLCreateTable += "cd110Fp varchar(2), ";
            SQLCreateTable += "sldUst varchar(3), ";
            SQLCreateTable += "sldLst varchar(3), ";
            SQLCreateTable += "csAfp varchar(3), ";
            SQLCreateTable += "cbsAfp varchar(5), ";
            SQLCreateTable += "metDivFp varchar(5), ";
            SQLCreateTable += "cNectaFp varchar(3), ";
            SQLCreateTable += "nectaFp varchar(5), ";
            SQLCreateTable += "nctAdvFp varchar(5), ";
            SQLCreateTable += "elsDlea varchar(5), ";
            SQLCreateTable += "scsDlea varchar(5), ";
            SQLCreateTable += "unsDlea varchar(5), ";
            SQLCreateTable += "ugaCe varchar(5), ";
            SQLCreateTable += "zcta5Ce varchar(5), ";
            SQLCreateTable += "zcta3Ce varchar(3), ";
            SQLCreateTable += "stateFpEc varchar(2), ";
            SQLCreateTable += "countyFpEc varchar(3), ";
            SQLCreateTable += "conCtyFpEc varchar(5), ";
            SQLCreateTable += "placeFpEc varchar(5), ";
            SQLCreateTable += "comRgceEc varchar(1), ";
            SQLCreateTable += "lwFlag varchar(1), ";
            SQLCreateTable += "offset varchar(1), ";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_tfid] PRIMARY KEY CLUSTERED ([tfid] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_countyFp00] ON [dbo].[" + OutputTableName + "] (countyFp00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_couSubFp00] ON [dbo].[" + OutputTableName + "] (couSubFp00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            //SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_subMcdName00] ON [dbo].[" + OutputTableName + "] (subMcdName00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_conCtyFp00] ON [dbo].[" + OutputTableName + "] (conCtyFp00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_placeFp00] ON [dbo].[" + OutputTableName + "] (placeFp00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";



            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName00 = [us_county00].Name00, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName00_Soundex = [us_county00].Name00_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName00_SoundexDM = [us_county00].Name00_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [us_county00] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyFp00 = [us_county00].countyFp00 ";
            SQLPostInsertTableUpdate += "  AND ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].stateFp00 = [us_county00].stateFp00 ;";

            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName00 = [" + StateName + "_cousub00].Name00, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName00_Soundex = [" + StateName + "_cousub00].Name00_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName00_SoundexDM = [" + StateName + "_cousub00].Name00_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_cousub00] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubFp00 = [" + StateName + "_cousub00].couSubFp00 ;";

            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName00 = [" + StateName + "_concity00].Name00, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName00_Soundex = [" + StateName + "_concity00].Name00_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName00_SoundexDM = [" + StateName + "_concity00].Name00_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_concity00] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyFp00 = [" + StateName + "_concity00].conCtyFp00 ;";

            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName00 = [" + StateName + "_place00].Name00, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName00_Soundex = [" + StateName + "_place00].Name00_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName00_SoundexDM = [" + StateName + "_place00].Name00_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_place00] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeFp00 = [" + StateName + "_place00].placeFp00 ;";



            SQLPostInsertTableDelete += " DELETE FROM [" + OutputTableName + "] ";
            SQLPostInsertTableDelete += " WHERE ";
            SQLPostInsertTableDelete += "   [" + OutputTableName + "].[tfid] NOT IN ";
            SQLPostInsertTableDelete += "   ( ";
            SQLPostInsertTableDelete += "     SELECT ";
            SQLPostInsertTableDelete += "      tfidl ";
            SQLPostInsertTableDelete += "     FROM ";
            SQLPostInsertTableDelete += "      dbo." + StateName + "_edges ";
            SQLPostInsertTableDelete += "    ) ";
            SQLPostInsertTableDelete += "  AND ";
            SQLPostInsertTableDelete += "   [" + OutputTableName + "].[tfid] NOT IN ";
            SQLPostInsertTableDelete += "   ( ";
            SQLPostInsertTableDelete += "     SELECT ";
            SQLPostInsertTableDelete += "      tfidr ";
            SQLPostInsertTableDelete += "     FROM ";
            SQLPostInsertTableDelete += "      dbo." + StateName + "_edges ";
            SQLPostInsertTableDelete += "    ); ";
        }
    }
}
