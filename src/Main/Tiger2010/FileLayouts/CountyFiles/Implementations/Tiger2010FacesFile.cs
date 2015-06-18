using USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountyFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountyFiles.Implementations
{
    public class Tiger2010FacesFile : AbstractTiger2010ShapefileCountyFileLayout
    {
        public Tiger2010FacesFile(string stateName)
            : base(stateName)
        {

            FileName = "faces.zip";

            ExcludeColumns = new string[] { 
                "countyName00", "couSubName00", "subMcdName00", "conCtyName00", "placeName00", 
                "countyName00_Soundex", "couSubName00_Soundex", "subMcdName00_Soundex", "conCtyName00_Soundex", "placeName00_Soundex", 
                "countyName00_SoundexDM", "couSubName00_SoundexDM", "subMcdName00_SoundexDM", "conCtyName00_SoundexDM", "placeName00_SoundexDM", 

                "countyName10", "couSubName10", "subMcdName10", "conCtyName10", "placeName10", 
                "countyName10_Soundex", "couSubName10_Soundex", "subMcdName10_Soundex", "conCtyName10_Soundex", "placeName10_Soundex", 
                "countyName10_SoundexDM", "couSubName10_SoundexDM", "subMcdName10_SoundexDM", "conCtyName10_SoundexDM", "placeName10_SoundexDM", 
            };

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "TFID int not null, ";
            SQLCreateTable += "STATEFP00 varchar(2), ";

            SQLCreateTable += "COUNTYFP00 varchar(3), ";
            SQLCreateTable += "countyName00 varchar(100), ";
            SQLCreateTable += "countyName00_Soundex varchar(4), ";
            SQLCreateTable += "countyName00_SoundexDM varchar(6), ";

            SQLCreateTable += "TRACTCE00 varchar(6), ";
            SQLCreateTable += "BLKGRPCE00 varchar(1), ";
            SQLCreateTable += "BLOCKCE00 varchar(4), ";

            SQLCreateTable += "COUSUBFP00 varchar(5), ";
            SQLCreateTable += "couSubName00 varchar(100), ";
            SQLCreateTable += "couSubName00_Soundex varchar(4), ";
            SQLCreateTable += "couSubName00_SoundexDM varchar(6), ";

            SQLCreateTable += "SUBMCDFP00 varchar(5), ";
            SQLCreateTable += "subMcdName00 varchar(100), ";
            SQLCreateTable += "subMcdName00_Soundex varchar(4), ";
            SQLCreateTable += "subMcdName00_SoundexDM varchar(6), ";

            SQLCreateTable += "CONCTYFP00 varchar(5), ";
            SQLCreateTable += "conCtyName00 varchar(100), ";
            SQLCreateTable += "conCtyName00_Soundex varchar(4), ";
            SQLCreateTable += "conCtyName00_SoundexDM varchar(6), ";

            SQLCreateTable += "PLACEFP00 varchar(5), ";
            SQLCreateTable += "placeName00 varchar(100), ";
            SQLCreateTable += "placeName00_Soundex varchar(4), ";
            SQLCreateTable += "placeName00_SoundexDM varchar(6), ";

            SQLCreateTable += "AIANNHFP00 varchar(5), ";
            SQLCreateTable += "AIANNHCE00 varchar(4), ";
            SQLCreateTable += "COMPTYP00 varchar(1), ";
            SQLCreateTable += "TRSUBFP00 varchar(5), ";
            SQLCreateTable += "TRSUBCE00 varchar(3), ";
            SQLCreateTable += "ANRCFP00 varchar(5), ";
            SQLCreateTable += "ELSDLEA00 varchar(5), ";
            SQLCreateTable += "SCSDLEA00 varchar(5), ";
            SQLCreateTable += "UNSDLEA00 varchar(5), ";
            SQLCreateTable += "UACE varchar(5), ";
            SQLCreateTable += "CD108FP varchar(2), ";
            SQLCreateTable += "SLDUST00 varchar(3), ";
            SQLCreateTable += "SLDLST00 varchar(3), ";
            SQLCreateTable += "VTDST00 varchar(6), ";
            SQLCreateTable += "ZCTA5CE00 varchar(5), ";
            SQLCreateTable += "TAZCE00 varchar(6), ";
            SQLCreateTable += "UGACE00 varchar(5), ";
            SQLCreateTable += "PUMA5CE00 varchar(5), ";
            SQLCreateTable += "STATEFP10 varchar(2), ";
            SQLCreateTable += "COUNTYFP10 varchar(3), ";
            SQLCreateTable += "countyName10 varchar(100), ";
            SQLCreateTable += "countyName10_Soundex varchar(4), ";
            SQLCreateTable += "countyName10_SoundexDM varchar(6), ";

            SQLCreateTable += "TRACTCE10 varchar(6), ";
            SQLCreateTable += "BLKGRPCE10 varchar(1), ";
            SQLCreateTable += "BLOCKCE10 varchar(4), ";
            SQLCreateTable += "COUSUBFP10 varchar(5), ";
            SQLCreateTable += "couSubName10 varchar(100), ";
            SQLCreateTable += "couSubName10_Soundex varchar(4), ";
            SQLCreateTable += "couSubName10_SoundexDM varchar(6), ";

            SQLCreateTable += "SUBMCDFP10 varchar(5), ";
            SQLCreateTable += "subMcdName10 varchar(100), ";
            SQLCreateTable += "subMcdName10_Soundex varchar(4), ";
            SQLCreateTable += "subMcdName10_SoundexDM varchar(6), ";

            SQLCreateTable += "CONCTYFP10 varchar(5), ";
            SQLCreateTable += "conCtyName10 varchar(100), ";
            SQLCreateTable += "conCtyName10_Soundex varchar(4), ";
            SQLCreateTable += "conCtyName10_SoundexDM varchar(6), ";

            SQLCreateTable += "PLACEFP10 varchar(5), ";
            SQLCreateTable += "placeName10 varchar(100), ";
            SQLCreateTable += "placeName10_Soundex varchar(4), ";
            SQLCreateTable += "placeName10_SoundexDM varchar(6), ";

            SQLCreateTable += "AIANNHFP10 varchar(5), ";
            SQLCreateTable += "AIANNHCE10 varchar(4), ";
            SQLCreateTable += "COMPTYP10 varchar(1), ";
            SQLCreateTable += "TRSUBFP10 varchar(5), ";
            SQLCreateTable += "TRSUBCE10 varchar(3), ";
            SQLCreateTable += "ANRCFP10 varchar(5), ";
            SQLCreateTable += "TTRACTCE10 varchar(6), ";
            SQLCreateTable += "TBLKGPCE10 varchar(1), ";
            SQLCreateTable += "ELSDLEA10 varchar(5), ";
            SQLCreateTable += "SCSDLEA10 varchar(5), ";
            SQLCreateTable += "UNSDLEA10 varchar(5), ";
            SQLCreateTable += "UACE10 varchar(5), ";
            SQLCreateTable += "CD111FP varchar(2), ";
            SQLCreateTable += "SLDUST10 varchar(3), ";
            SQLCreateTable += "SLDLST10 varchar(3), ";
            SQLCreateTable += "VTDST10 varchar(6), ";
            SQLCreateTable += "ZCTA5CE10 varchar(5), ";
            SQLCreateTable += "TAZCE10 varchar(6), ";
            SQLCreateTable += "UGACE10 varchar(5), ";
            SQLCreateTable += "PUMACE10 varchar(5), ";
            SQLCreateTable += "CSAFP10 varchar(3), ";
            SQLCreateTable += "CBSAFP10 varchar(5), ";
            SQLCreateTable += "METDIVFP10 varchar(5), ";
            SQLCreateTable += "CNECTAFP10 varchar(3), ";
            SQLCreateTable += "NECTAFP10 varchar(5), ";
            SQLCreateTable += "NCTADVFP10 varchar(5), ";
            SQLCreateTable += "LWFLAG varchar(1), ";
            SQLCreateTable += "OFFSET varchar(1), ";
            SQLCreateTable += "ATOTAL varchar(14), ";
            SQLCreateTable += "INTPTLAT varchar(14), ";
            SQLCreateTable += "INTPTLON varchar(14), ";

            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_tfid] PRIMARY KEY CLUSTERED ([tfid] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_countyFp10' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_countyFp10] ON [dbo].[" + OutputTableName + "] (countyFp10) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_couSubFp10' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_couSubFp10] ON [dbo].[" + OutputTableName + "] (couSubFp10) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            //SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_subMcdName00' )";
            //SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_subMcdName00] ON [dbo].[" + OutputTableName + "] (subMcdName00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_conCtyFp10' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_conCtyFp10] ON [dbo].[" + OutputTableName + "] (conCtyFp10) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_placeFp10' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_placeFp10] ON [dbo].[" + OutputTableName + "] (placeFp10) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";



            //SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            //SQLPostInsertTableUpdate += " SET ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName00 = [us_county00].Name00, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName00_Soundex = [us_county00].Name00_Soundex, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName00_SoundexDM = [us_county00].Name00_SoundexDM";
            //SQLPostInsertTableUpdate += " FROM ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [us_county00] ";
            //SQLPostInsertTableUpdate += " WHERE ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyFp00 = [us_county00].countyFp00 ";
            //SQLPostInsertTableUpdate += "  AND ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].stateFp00 = [us_county00].stateFp00 ;";

            //SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            //SQLPostInsertTableUpdate += " SET ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName00 = [" + StateName + "_cousub00].Name00, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName00_Soundex = [" + StateName + "_cousub00].Name00_Soundex, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName00_SoundexDM = [" + StateName + "_cousub00].Name00_SoundexDM";
            //SQLPostInsertTableUpdate += " FROM ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_cousub00] ";
            //SQLPostInsertTableUpdate += " WHERE ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubFp00 = [" + StateName + "_cousub00].couSubFp00 ;";

            //SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            //SQLPostInsertTableUpdate += " SET ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName00 = [" + StateName + "_concity00].Name00, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName00_Soundex = [" + StateName + "_concity00].Name00_Soundex, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName00_SoundexDM = [" + StateName + "_concity00].Name00_SoundexDM";
            //SQLPostInsertTableUpdate += " FROM ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_concity00] ";
            //SQLPostInsertTableUpdate += " WHERE ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyFp00 = [" + StateName + "_concity00].conCtyFp00 ;";

            //SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            //SQLPostInsertTableUpdate += " SET ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName00 = [" + StateName + "_place00].Name00, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName00_Soundex = [" + StateName + "_place00].Name00_Soundex, ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName00_SoundexDM = [" + StateName + "_place00].Name00_SoundexDM";
            //SQLPostInsertTableUpdate += " FROM ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_place00] ";
            //SQLPostInsertTableUpdate += " WHERE ";
            //SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeFp00 = [" + StateName + "_place00].placeFp00 ;";


            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName10 = [us_county10].Name10, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName10_Soundex = [us_county10].Name10_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyName10_SoundexDM = [us_county10].Name10_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [us_county10] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].countyFp10 = [us_county10].countyFp10 ";
            SQLPostInsertTableUpdate += "  AND ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].stateFp10 = [us_county10].stateFp10 ;";

            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName10 = [" + StateName + "_cousub10].Name10, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName10_Soundex = [" + StateName + "_cousub10].Name10_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubName10_SoundexDM = [" + StateName + "_cousub10].Name10_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_cousub10] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].couSubFp10 = [" + StateName + "_cousub10].couSubFp10 ;";

            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName10 = [" + StateName + "_concity10].Name10, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName10_Soundex = [" + StateName + "_concity10].Name10_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyName10_SoundexDM = [" + StateName + "_concity10].Name10_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_concity10] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].conCtyFp10 = [" + StateName + "_concity10].conCtyFp10 ;";

            SQLPostInsertTableUpdate += " UPDATE [" + OutputTableName + "] ";
            SQLPostInsertTableUpdate += " SET ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName10 = [" + StateName + "_place10].Name10, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName10_Soundex = [" + StateName + "_place10].Name10_Soundex, ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeName10_SoundexDM = [" + StateName + "_place10].Name10_SoundexDM";
            SQLPostInsertTableUpdate += " FROM ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "], [" + StateName + "_place10] ";
            SQLPostInsertTableUpdate += " WHERE ";
            SQLPostInsertTableUpdate += "  [" + OutputTableName + "].placeFp10 = [" + StateName + "_place10].placeFp10 ;";



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