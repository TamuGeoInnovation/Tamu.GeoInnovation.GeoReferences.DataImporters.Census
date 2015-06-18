using USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountyFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountyFiles.Implementations
{
    public class Tiger2010EdgesFile : AbstractTiger2010ShapefileCountyFileLayout
    {

        public Tiger2010EdgesFile(string stateName, bool shouldDoOnlyStreets, bool shouldDoOnlyNamedStreets)
            : base(stateName)
        {

            HasEndPointsColumns = true;
            EndPointsColumns = new string[] { "fromLon", "fromLat", "toLon", "toLat" };

            ShouldSplitAddressRanges = true;
            SplitAddressRangesColumns = new string[] { "lFromAdd", "lToAdd", "rFromAdd", "rToAdd" };

            ShouldAddEvenOddFlag = true;
            AddEvenOddFlagColumns = new string[] { "lFromAdd_Number", "rFromAdd_Number" };

            FileName = "edges.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "tlid int NOT NULL,";
            SQLCreateTable += "stateFp varchar(55) DEFAULT NULL,";
            SQLCreateTable += "countyFp varchar(55) DEFAULT NULL,";
            SQLCreateTable += "tfidL varchar(255) DEFAULT NULL,";
            SQLCreateTable += "tfidR varchar(255) DEFAULT NULL,";
            SQLCreateTable += "mtFcc varchar(5) DEFAULT NULL,";
            SQLCreateTable += "fullName varchar(100) DEFAULT NULL,";
            SQLCreateTable += "smid varchar(22) DEFAULT NULL,";
            SQLCreateTable += "lFromAdd varchar(12) DEFAULT NULL,";
            SQLCreateTable += "lFromAdd_Number varchar(12) DEFAULT NULL,";
            SQLCreateTable += "lFromAdd_Number_Even bit, ";
            SQLCreateTable += "lFromAdd_Unit varchar(12), ";
            SQLCreateTable += "lToAdd varchar(12) DEFAULT NULL,";
            SQLCreateTable += "lToAdd_Number varchar(12) DEFAULT NULL,";
            SQLCreateTable += "lToAdd_Unit varchar(12), ";
            SQLCreateTable += "rFromAdd varchar(12) DEFAULT NULL,";
            SQLCreateTable += "rFromAdd_Number varchar(12) DEFAULT NULL,";
            SQLCreateTable += "rFromAdd_Number_Even bit, ";
            SQLCreateTable += "rFromAdd_Unit varchar(12), ";
            SQLCreateTable += "rToAdd varchar(12) DEFAULT NULL,";
            SQLCreateTable += "rToAdd_Number varchar(12) DEFAULT NULL,";
            SQLCreateTable += "rToAdd_Unit varchar(12), ";
            SQLCreateTable += "zipL varchar(5) DEFAULT NULL,";
            SQLCreateTable += "zipR varchar(5) DEFAULT NULL,";
            SQLCreateTable += "featCat varchar(1) DEFAULT NULL,";
            SQLCreateTable += "hydroFlg varchar(1) DEFAULT NULL,";
            SQLCreateTable += "railFlg varchar(1) DEFAULT NULL,";
            SQLCreateTable += "roadFlg varchar(1) DEFAULT NULL,";
            SQLCreateTable += "olfFlg varchar(1) DEFAULT NULL,";
            SQLCreateTable += "passFlg varchar(1) DEFAULT NULL,";
            SQLCreateTable += "divRoad varchar(1) DEFAULT NULL,";
            SQLCreateTable += "extTyp varchar(1) DEFAULT NULL,";
            SQLCreateTable += "tTyp varchar(1) DEFAULT NULL,";
            SQLCreateTable += "deckedRoad varchar(1) DEFAULT NULL,";
            SQLCreateTable += "artPath varchar(1) DEFAULT NULL,";
            SQLCreateTable += "persist varchar(1) DEFAULT NULL,";
            SQLCreateTable += "gcseFlg varchar(1) DEFAULT NULL,";
            SQLCreateTable += "offsetL varchar(1) DEFAULT NULL,";
            SQLCreateTable += "offsetR varchar(1) DEFAULT NULL,";
            SQLCreateTable += "tnidF varchar(255) DEFAULT NULL,";
            SQLCreateTable += "tnidT varchar(255) DEFAULT NULL,";
            SQLCreateTable += "fromLon varchar(20) DEFAULT NULL,";
            SQLCreateTable += "fromLat varchar(20) DEFAULT NULL,";
            SQLCreateTable += "toLon varchar(20) DEFAULT NULL,";
            SQLCreateTable += "toLat varchar(20) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography, ";
            SQLCreateTable += "shapeGeom geometry, ";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_tlid] PRIMARY KEY CLUSTERED ([tlid] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            //ExcludeColumns = new string[] { "id" };

            //SQLAlterTableAddForeignKeys += " ALTER TABLE [" + OutputTableName + "] ";
            //SQLAlterTableAddForeignKeys += " ADD";
            //SQLAlterTableAddForeignKeys += " CONSTRAINT [FK_featnames_tlid] FOREIGN KEY (tlid) REFERENCES " + stateName + "_featnames (tlid), ";
            //SQLAlterTableAddForeignKeys += " CONSTRAINT [FK_addr_tlid] FOREIGN KEY (tlid) REFERENCES " + stateName + "_addr (tlid) ";
            //SQLAlterTableAddForeignKeys += " ;";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_tfidL' )";
            SQLCreateTableIndexes += "CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_tfidL] ON [dbo].[" + OutputTableName + "](tfidL ASC) INCLUDE (tlid, shapeGeog, shapeGeom, lToAdd, lFromAdd) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_tfidR' )";
            SQLCreateTableIndexes += "CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_tfidR] ON [dbo].[" + OutputTableName + "](tfidR ASC) INCLUDE (tlid, shapeGeog, shapeGeom, rToAdd, rFromAdd) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";



            SQLPostInsertTableDeleteStreetsOnly += " DELETE FROM [" + OutputTableName + "] ";
            SQLPostInsertTableDeleteStreetsOnly += " WHERE ";
            SQLPostInsertTableDeleteStreetsOnly += "  [" + OutputTableName + "].[roadFlg] <> 'Y' ;";


            SQLPostProcessOutputToSingleTable = "";
            SQLPostProcessOutputToSingleTable += " CREATE TABLE [dbo].[" + StateName + "_Left] (";
            SQLPostProcessOutputToSingleTable += " [tlid] [int] NOT NULL, ";
            SQLPostProcessOutputToSingleTable += " [fromLon] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fromLat] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toLon] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toLat] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tfidL] [varchar](255) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lFromAdd] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lFromAdd_Number] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lFromAdd_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lFromAdd_Number_Even] [bit] NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [lToAdd] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lToAdd_Number] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lToAdd_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [edges_fullname] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [edges_zip] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [arid] [varchar](22) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [side] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fromHN] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fromHN_Number] [int] NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [fromHN_Number_Even] [bit] NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [fromHN_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toHN] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toHN_Number] [int]  NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [toHN_Number_Even] [bit]  NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [toHN_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [zip] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [plus4] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lineArid] [varchar](22) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fullName] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [preDirAbrv] [varchar](15) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [preTypAbrv] [varchar](50) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [preQualAbr] [varchar](15) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [name] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [name_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [name_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [sufDirAbrv] [varchar](15) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [sufTypAbrv] [varchar](50) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [sufQualAbr] [varchar](15) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [placeFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [conCtyFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [subMcdFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [couSubFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [countyFp00] [varchar](3) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyFp10] [varchar](3) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [stateFp00] [varchar](2) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tractCe00] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blkGrpCe00] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blockCe00] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [stateFp10] [varchar](2) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tractCe10] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blkGrpCe10] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blockCe10] [varchar](4) NOT NULL DEFAULT '', ";

            //SQLPostProcessOutputToSingleTable += " [suffix1Ce] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tfid] [int] NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [shapeGeog] [geography] NULL, ";
            SQLPostProcessOutputToSingleTable += " [shapeGeom] [geometry] NULL, ";
            SQLPostProcessOutputToSingleTable += " [UniqueId] [int] IDENTITY(1,1) NOT NULL ";
            SQLPostProcessOutputToSingleTable += " ) ;";

            SQLPostProcessOutputToSingleTable += " CREATE TABLE [dbo].[" + StateName + "_Right] (";
            SQLPostProcessOutputToSingleTable += " [tlid] [int] NOT NULL, ";
            SQLPostProcessOutputToSingleTable += " [fromLon] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fromLat] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toLon] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toLat] [varchar](20) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tfidR] [varchar](255) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [rFromAdd] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [rFromAdd_Number] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [rFromAdd_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [rFromAdd_Number_Even] [bit] NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [rToAdd] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [rToAdd_Number] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [rToAdd_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [edges_fullname] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [edges_zip] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [arid] [varchar](22) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [side] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fromHN] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fromHN_Number] [int]  NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [fromHN_Number_Even] [bit]  NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [fromHN_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toHN] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [toHN_Number] [int]  NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [toHN_Number_Even] [bit]  NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [toHN_Unit] [varchar](12) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [zip] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [plus4] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [lineArid] [varchar](22) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [fullName] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [preDirAbrv] [varchar](15) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [preTypAbrv] [varchar](50) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [preQualAbr] [varchar](15) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [name] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [name_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [name_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [sufDirAbrv] [varchar](15) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [sufTypAbrv] [varchar](50) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [sufQualAbr] [varchar](15) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [placeFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [placeName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [conCtyFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [subMcdFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [couSubFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubFp10] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [countyFp00] [varchar](3) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyFp10] [varchar](3) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName10] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName10_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName10_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";

            SQLPostProcessOutputToSingleTable += " [stateFp00] [varchar](2) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tractCe00] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blkGrpCe00] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blockCe00] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [stateFp10] [varchar](2) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tractCe10] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blkGrpCe10] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blockCe10] [varchar](4) NOT NULL DEFAULT '', ";

            //SQLPostProcessOutputToSingleTable += " [suffix1Ce] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tfid] [int] NOT NULL DEFAULT 0, ";
            SQLPostProcessOutputToSingleTable += " [shapeGeog] [geography] NULL, ";
            SQLPostProcessOutputToSingleTable += " [shapeGeom] [geometry] NULL, ";
            SQLPostProcessOutputToSingleTable += " [UniqueId] [int] IDENTITY(1,1) NOT NULL ";
            SQLPostProcessOutputToSingleTable += " ) ;";


            SQLPostProcessOutputToSingleTable += " INSERT INTO [dbo].[" + StateName + "_Left] ";
            SQLPostProcessOutputToSingleTable += " ( ";
            SQLPostProcessOutputToSingleTable += " [tlid]";
            SQLPostProcessOutputToSingleTable += " ,[fromLon]";
            SQLPostProcessOutputToSingleTable += " ,[fromLat]";
            SQLPostProcessOutputToSingleTable += " ,[toLon]";
            SQLPostProcessOutputToSingleTable += " ,[toLat]";
            SQLPostProcessOutputToSingleTable += " ,[tfidL]";
            SQLPostProcessOutputToSingleTable += " ,[lFromAdd]";
            SQLPostProcessOutputToSingleTable += " ,[lFromAdd_Number]";
            SQLPostProcessOutputToSingleTable += " ,[lFromAdd_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[lFromAdd_Number_Even]";
            SQLPostProcessOutputToSingleTable += " ,[lToAdd]";
            SQLPostProcessOutputToSingleTable += " ,[lToAdd_Number]";
            SQLPostProcessOutputToSingleTable += " ,[lToAdd_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[edges_fullname]";
            SQLPostProcessOutputToSingleTable += " ,[edges_zip]";
            SQLPostProcessOutputToSingleTable += " ,[arid]";
            SQLPostProcessOutputToSingleTable += " ,[side]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN_Number]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN_Number_Even]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[toHN]";
            SQLPostProcessOutputToSingleTable += " ,[toHN_Number]";
            SQLPostProcessOutputToSingleTable += " ,[toHN_Number_Even]";
            SQLPostProcessOutputToSingleTable += " ,[toHN_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[zip]";
            SQLPostProcessOutputToSingleTable += " ,[plus4]";
            SQLPostProcessOutputToSingleTable += " ,[lineArid]";
            SQLPostProcessOutputToSingleTable += " ,[fullName]";
            SQLPostProcessOutputToSingleTable += " ,[preDirAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[preTypAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[preQualAbr]";
            SQLPostProcessOutputToSingleTable += " ,[name]";
            SQLPostProcessOutputToSingleTable += " ,[name_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[name_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[sufDirAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[sufTypAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[sufQualAbr]";

            SQLPostProcessOutputToSingleTable += " ,[placeFp00]";
            SQLPostProcessOutputToSingleTable += " ,[placeName00]";
            SQLPostProcessOutputToSingleTable += " ,[placeName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[placeName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[placeFp10]";
            SQLPostProcessOutputToSingleTable += " ,[placeName10]";
            SQLPostProcessOutputToSingleTable += " ,[placeName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[placeName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[conCtyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyFp10]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName10]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[subMcdFp00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdFp10]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName10]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[couSubFp00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[couSubFp10]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName10]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[countyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[countyFp10]";
            SQLPostProcessOutputToSingleTable += " ,[countyName10]";
            SQLPostProcessOutputToSingleTable += " ,[countyName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[countyName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[stateFp00]";
            SQLPostProcessOutputToSingleTable += " ,[tractCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blkGrpCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blockCe00]";
            SQLPostProcessOutputToSingleTable += " ,[stateFp10]";
            SQLPostProcessOutputToSingleTable += " ,[tractCe10]";
            SQLPostProcessOutputToSingleTable += " ,[blkGrpCe10]";
            SQLPostProcessOutputToSingleTable += " ,[blockCe10]";

            //SQLPostProcessOutputToSingleTable += " ,[suffix1Ce]";
            SQLPostProcessOutputToSingleTable += " ,[tfid]";
            SQLPostProcessOutputToSingleTable += " ,[shapeGeog]";
            SQLPostProcessOutputToSingleTable += " ,[shapeGeom]";
            SQLPostProcessOutputToSingleTable += " )";
            SQLPostProcessOutputToSingleTable += " SELECT ";

            SQLPostProcessOutputToSingleTable += " ISNULL( dbo." + StateName + "_edges.tlid, 0 ) ,  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.fromLon, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.fromLat, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.toLon, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.toLat, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.tfidL, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lFromAdd, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lFromAdd_Number, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lFromAdd_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lFromAdd_Number_Even, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lToAdd, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lToAdd_Number, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.lToAdd_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.fullname , '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.zipl , '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.arid, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.side, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN_Number, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN_Number_Even, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN_Number, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN_Number_Even, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.zip, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.plus4, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.lineArid, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.fullName, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.preDirAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.preTypAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.preQualAbr, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.name, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.name_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.name_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.sufDirAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.sufTypAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.sufQualAbr, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.stateFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tractCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blkGrpCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blockCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.stateFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tractCe10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blkGrpCe10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blockCe10, '' ),  ";

            //SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.suffix1Ce, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tfid, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " dbo." + StateName + "_edges.shapeGeog,  ";
            SQLPostProcessOutputToSingleTable += " dbo." + StateName + "_edges.shapeGeom  ";

            SQLPostProcessOutputToSingleTable += " FROM          ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_edges ";
            SQLPostProcessOutputToSingleTable += "  LEFT JOIN ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_addr ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_addr.tlid ";
            SQLPostProcessOutputToSingleTable += "  LEFT JOIN ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_featnames ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_featnames.tlid ";
            SQLPostProcessOutputToSingleTable += "  LEFT JOIN ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_faces ON dbo." + StateName + "_edges.tfidL = dbo." + StateName + "_faces.tfid ";



            SQLPostProcessOutputToSingleTable += "; ";


            SQLPostProcessOutputToSingleTable += " INSERT INTO [dbo].[" + StateName + "_Right] ";
            SQLPostProcessOutputToSingleTable += " ( ";
            SQLPostProcessOutputToSingleTable += " [tlid]";
            SQLPostProcessOutputToSingleTable += " ,[fromLon]";
            SQLPostProcessOutputToSingleTable += " ,[fromLat]";
            SQLPostProcessOutputToSingleTable += " ,[toLon]";
            SQLPostProcessOutputToSingleTable += " ,[toLat]";
            SQLPostProcessOutputToSingleTable += " ,[tfidR]";
            SQLPostProcessOutputToSingleTable += " ,[rFromAdd]";
            SQLPostProcessOutputToSingleTable += " ,[rFromAdd_Number]";
            SQLPostProcessOutputToSingleTable += " ,[rFromAdd_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[rFromAdd_Number_Even]";
            SQLPostProcessOutputToSingleTable += " ,[rToAdd]";
            SQLPostProcessOutputToSingleTable += " ,[rToAdd_Number]";
            SQLPostProcessOutputToSingleTable += " ,[rToAdd_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[edges_fullname]";
            SQLPostProcessOutputToSingleTable += " ,[edges_zip]";
            SQLPostProcessOutputToSingleTable += " ,[arid]";
            SQLPostProcessOutputToSingleTable += " ,[side]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN_Number]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN_Number_Even]";
            SQLPostProcessOutputToSingleTable += " ,[fromHN_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[toHN]";
            SQLPostProcessOutputToSingleTable += " ,[toHN_Number]";
            SQLPostProcessOutputToSingleTable += " ,[toHN_Number_Even]";
            SQLPostProcessOutputToSingleTable += " ,[toHN_Unit]";
            SQLPostProcessOutputToSingleTable += " ,[zip]";
            SQLPostProcessOutputToSingleTable += " ,[plus4]";
            SQLPostProcessOutputToSingleTable += " ,[lineArid]";
            SQLPostProcessOutputToSingleTable += " ,[fullName]";
            SQLPostProcessOutputToSingleTable += " ,[preDirAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[preTypAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[preQualAbr]";
            SQLPostProcessOutputToSingleTable += " ,[name]";
            SQLPostProcessOutputToSingleTable += " ,[name_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[name_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[sufDirAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[sufTypAbrv]";
            SQLPostProcessOutputToSingleTable += " ,[sufQualAbr]";

            SQLPostProcessOutputToSingleTable += " ,[placeFp00]";
            SQLPostProcessOutputToSingleTable += " ,[placeName00]";
            SQLPostProcessOutputToSingleTable += " ,[placeName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[placeName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[placeFp10]";
            SQLPostProcessOutputToSingleTable += " ,[placeName10]";
            SQLPostProcessOutputToSingleTable += " ,[placeName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[placeName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[conCtyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyFp10]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName10]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[subMcdFp00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdFp10]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName10]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[couSubFp00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[couSubFp10]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName10]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[countyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[countyFp10]";
            SQLPostProcessOutputToSingleTable += " ,[countyName10]";
            SQLPostProcessOutputToSingleTable += " ,[countyName10_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[countyName10_SoundexDM]";

            SQLPostProcessOutputToSingleTable += " ,[stateFp00]";
            SQLPostProcessOutputToSingleTable += " ,[tractCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blkGrpCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blockCe00]";
            SQLPostProcessOutputToSingleTable += " ,[stateFp10]";
            SQLPostProcessOutputToSingleTable += " ,[tractCe10]";
            SQLPostProcessOutputToSingleTable += " ,[blkGrpCe10]";
            SQLPostProcessOutputToSingleTable += " ,[blockCe10]";

            //SQLPostProcessOutputToSingleTable += " ,[suffix1Ce]";
            SQLPostProcessOutputToSingleTable += " ,[tfid]";
            SQLPostProcessOutputToSingleTable += " ,[shapeGeog]";
            SQLPostProcessOutputToSingleTable += " ,[shapeGeom]";
            SQLPostProcessOutputToSingleTable += " )";

            SQLPostProcessOutputToSingleTable += " SELECT ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.tlid, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.fromLon, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.fromLat, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.toLon, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.toLat, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.tfidR, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rFromAdd, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rFromAdd_Number, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rFromAdd_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rFromAdd_Number_Even, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rToAdd, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rToAdd_Number, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.rToAdd_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.fullname , '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_edges.zipr , '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.arid, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.side, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN_Number, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN_Number_Even, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.fromHN_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN_Number, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN_Number_Even, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.toHN_Unit, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.zip, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_addr.plus4, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.lineArid, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.fullName, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.preDirAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.preTypAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.preQualAbr, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.name, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.name_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.name_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.sufDirAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.sufTypAbrv, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_featnames.sufQualAbr, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.placeName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName10_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName10_SoundexDM, '' ),  ";

            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.stateFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tractCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blkGrpCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blockCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.stateFp10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tractCe10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blkGrpCe10, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blockCe10, '' ),  ";

            //SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.suffix1Ce, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tfid, 0 ),  ";
            SQLPostProcessOutputToSingleTable += " dbo." + StateName + "_edges.shapeGeog,  ";
            SQLPostProcessOutputToSingleTable += " dbo." + StateName + "_edges.shapeGeom  ";

            SQLPostProcessOutputToSingleTable += " FROM          ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_edges ";
            SQLPostProcessOutputToSingleTable += "  LEFT JOIN ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_addr ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_addr.tlid ";
            SQLPostProcessOutputToSingleTable += "  LEFT JOIN ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_featnames ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_featnames.tlid ";
            SQLPostProcessOutputToSingleTable += "  LEFT JOIN ";
            SQLPostProcessOutputToSingleTable += "  dbo." + StateName + "_faces ON dbo." + StateName + "_edges.tfidR = dbo." + StateName + "_faces.tfid ";



            SQLPostProcessOutputToSingleTable += "; ";



            SQLPostInsertTableDeleteNamedStreetsOnly = "";
            SQLPostInsertTableDeleteNamedStreetsOnly += " DELETE FROM ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Right] ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " WHERE ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ( ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Right].[edges_fullname] IS NULL ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Right].[fullName] IS NULL ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ) ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " OR ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ( ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Right].[edges_fullname] = ''";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Right].[fullName] = ''";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ) ";

            SQLPostInsertTableDeleteNamedStreetsOnly += " ; ";

            SQLPostInsertTableDeleteNamedStreetsOnly += " DELETE FROM ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Left] ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " WHERE ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ( ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Left].[edges_fullname] IS NULL ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Left].[fullName] IS NULL ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ) ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " OR ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ( ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Left].[edges_fullname] = '' ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteNamedStreetsOnly += "  [dbo].[" + StateName + "_Left].[fullName]  = '' ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ) ";
            SQLPostInsertTableDeleteNamedStreetsOnly += " ; ";

            SQLPostInsertTableDeleteAddressableStreetsOnly = "";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " DELETE FROM ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right] ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " WHERE ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ( ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[rFromAdd_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[fromHN_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[rToAdd_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[toHN_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ) ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " OR ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ( ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[rFromAdd_Number]=0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[fromHN_Number] =0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[rToAdd_Number] =0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Right].[toHN_Number] =0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ) ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ; ";

            SQLPostInsertTableDeleteAddressableStreetsOnly += " DELETE FROM ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left] ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " WHERE ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ( ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[lFromAdd_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[fromHN_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[lToAdd_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[toHN_Number] IS NULL ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ) ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " OR ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ( ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[lFromAdd_Number]=0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[fromHN_Number] =0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[lToAdd_Number] =0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  AND ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += "  [dbo].[" + StateName + "_Left].[toHN_Number] =0";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ) ";
            SQLPostInsertTableDeleteAddressableStreetsOnly += " ; ";

            SQLPostInsertSingleTableUpdate = "";
            SQLPostInsertSingleTableUpdate += " DELETE FROM ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  side = 'L' ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " UPDATE ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdate += " SET ";
            SQLPostInsertSingleTableUpdate += "  fromHN = rFromAdd , ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Number = rFromAdd_Number , ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Unit = rFromAdd_Unit , ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Number_Even = rFromAdd_Number_Even  ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  rFromAdd_Number IS NOT NULL ";
            SQLPostInsertSingleTableUpdate += "  AND ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Number IS NULL ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " UPDATE ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdate += " SET ";
            SQLPostInsertSingleTableUpdate += "  toHN = rToAdd , ";
            SQLPostInsertSingleTableUpdate += "  toHN_Number = rToAdd_Number , ";
            SQLPostInsertSingleTableUpdate += "  toHN_Unit = rToAdd_Unit  ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  rToAdd_Number IS NOT NULL ";
            SQLPostInsertSingleTableUpdate += "  AND ";
            SQLPostInsertSingleTableUpdate += "  toHN_Number IS NULL ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " UPDATE ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdate += " SET ";
            SQLPostInsertSingleTableUpdate += "  zip = edges_zip  ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  edges_zip IS NOT NULL ";
            SQLPostInsertSingleTableUpdate += "  AND ";
            SQLPostInsertSingleTableUpdate += "  zip IS NULL ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " DELETE FROM ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  side = 'R' ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " UPDATE ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdate += " SET ";
            SQLPostInsertSingleTableUpdate += "  fromHN = lFromAdd , ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Number = lFromAdd_Number , ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Unit = lFromAdd_Unit , ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Number_Even = lFromAdd_Number_Even  ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  lFromAdd_Number IS NOT NULL ";
            SQLPostInsertSingleTableUpdate += "  AND ";
            SQLPostInsertSingleTableUpdate += "  fromHN_Number IS NULL ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " UPDATE ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdate += " SET ";
            SQLPostInsertSingleTableUpdate += "  toHN = lToAdd , ";
            SQLPostInsertSingleTableUpdate += "  toHN_Number = lToAdd_Number , ";
            SQLPostInsertSingleTableUpdate += "  toHN_Unit = lToAdd_Unit ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  lToAdd_Number IS NOT NULL ";
            SQLPostInsertSingleTableUpdate += "  AND ";
            SQLPostInsertSingleTableUpdate += "  toHN_Number IS NULL ";
            SQLPostInsertSingleTableUpdate += " ; ";

            SQLPostInsertSingleTableUpdate += " UPDATE ";
            SQLPostInsertSingleTableUpdate += "  [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdate += " SET ";
            SQLPostInsertSingleTableUpdate += "  zip = edges_zip  ";
            SQLPostInsertSingleTableUpdate += " WHERE ";
            SQLPostInsertSingleTableUpdate += "  edges_zip IS NOT NULL ";
            SQLPostInsertSingleTableUpdate += "  AND ";
            SQLPostInsertSingleTableUpdate += "  zip IS NULL ";
            SQLPostInsertSingleTableUpdate += " ; ";




            // left side statistics
            string SQLPostInsertSingleTableUpdateStatistics = "";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_26_20_33_19_23_44_48_52_56] ON [dbo].[" + StateName + "_Left]([zip], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [conCtyName10], [subMcdName10], [couSubName10], [countyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_34_20_19_23_26_44_48_52_56] ON [dbo].[" + StateName + "_Left]([name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [zip], [conCtyName10], [subMcdName10], [couSubName10], [countyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_34_20_26_40_19_23] ON [dbo].[" + StateName + "_Left]([name_Soundex], [fromHN_Number_Even], [zip], [placeName10], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_34_26_40] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [zip], [placeName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_40_26_19_34] ON [dbo].[" + StateName + "_Left]([toHN_Number], [placeName10], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_48_44_52_56_26_19_34] ON [dbo].[" + StateName + "_Left]([toHN_Number], [subMcdName10], [conCtyName10], [couSubName10], [countyName10], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_40_20_26] ON [dbo].[" + StateName + "_Left]([placeName10], [fromHN_Number_Even], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_52_20_33_19_23_26_44] ON [dbo].[" + StateName + "_Left]([couSubName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_56_20_33_19_23_26_44_48] ON [dbo].[" + StateName + "_Left]([countyName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName10], [subMcdName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_19_23_33_40_26] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number], [toHN_Number], [name], [placeName10], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_44_20_33_19_23] ON [dbo].[" + StateName + "_Left]([conCtyName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_48_19_23_52_44_56_33_26] ON [dbo].[" + StateName + "_Left]([subMcdName10], [fromHN_Number], [toHN_Number], [couSubName10], [conCtyName10], [countyName10], [name], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_48_20_33_19_23_26] ON [dbo].[" + StateName + "_Left]([subMcdName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_20_33_26_40_19] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [name], [zip], [placeName10], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_26_33_40_19_67] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [zip], [name], [placeName10], [fromHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_33_26_40_19] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [name], [zip], [placeName10], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_20_33_23] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [fromHN_Number_Even], [name], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_20_34_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [fromHN_Number_Even], [name_Soundex], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_23_33_40_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [name], [placeName10], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_56_34_20_19_23_67_26_44_48] ON [dbo].[" + StateName + "_Left]([countyName10], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName10], [subMcdName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_52_34_20_19_23_67_26_44] ON [dbo].[" + StateName + "_Left]([couSubName10], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_48_34_20_19_23_67_26] ON [dbo].[" + StateName + "_Left]([subMcdName10], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_34_20_26_40_19] ON [dbo].[" + StateName + "_Left]([UniqueId], [name_Soundex], [fromHN_Number_Even], [zip], [placeName10], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_34_20_19] ON [dbo].[" + StateName + "_Left]([UniqueId], [name_Soundex], [fromHN_Number_Even], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_26_44_48_52] ON [dbo].[" + StateName + "_Left]([UniqueId], [zip], [conCtyName10], [subMcdName10], [couSubName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_34_20_26_40_23_67] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [zip], [placeName10], [toHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_34_20_23_67_26_44_48_52_56] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [toHN_Number], [UniqueId], [zip], [conCtyName10], [subMcdName10], [couSubName10], [countyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_49_20_34_19_23_26_41] ON [dbo].[" + StateName + "_Left]([subMcdName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_45_20_34_19_23_26] ON [dbo].[" + StateName + "_Left]([conCtyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_57_20_34_19_23_26_41_45_49] ON [dbo].[" + StateName + "_Left]([countyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_53_20_34_19_23_26_41_45] ON [dbo].[" + StateName + "_Left]([couSubName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_41_53_19_23_26_57_45_49_34] ON [dbo].[" + StateName + "_Left]([placeName00_Soundex], [couSubName00_Soundex], [fromHN_Number], [toHN_Number], [zip], [countyName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [name_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_19_26_34_53_57_41_45_20] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number], [zip], [name_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [placeName00_Soundex], [conCtyName00_Soundex], [fromHN_Number_Even]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_41_20_34_19_23] ON [dbo].[" + StateName + "_Left]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_26_20_34_19_23_41_45_49_53_57] ON [dbo].[" + StateName + "_Left]([zip], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_20_34_19_23_26_41_45_49_53] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_41_20_34_19_23_26_45_49_53_57_67] ON [dbo].[" + StateName + "_Left]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_34_19_26_41_45_49_53_57_67] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";

            // right side statistics
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_26_20_33_19_23_44_48_52_56] ON [dbo].[" + StateName + "_Right]([zip], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [conCtyName10], [subMcdName10], [couSubName10], [countyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_34_20_19_23_26_44_48_52_56] ON [dbo].[" + StateName + "_Right]([name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [zip], [conCtyName10], [subMcdName10], [couSubName10], [countyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_34_20_26_40_19_23] ON [dbo].[" + StateName + "_Right]([name_Soundex], [fromHN_Number_Even], [zip], [placeName10], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_34_26_40] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [zip], [placeName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_40_26_19_34] ON [dbo].[" + StateName + "_Right]([toHN_Number], [placeName10], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_48_44_52_56_26_19_34] ON [dbo].[" + StateName + "_Right]([toHN_Number], [subMcdName10], [conCtyName10], [couSubName10], [countyName10], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_40_20_26] ON [dbo].[" + StateName + "_Right]([placeName10], [fromHN_Number_Even], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_52_20_33_19_23_26_44] ON [dbo].[" + StateName + "_Right]([couSubName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_56_20_33_19_23_26_44_48] ON [dbo].[" + StateName + "_Right]([countyName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName10], [subMcdName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_19_23_33_40_26] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number], [toHN_Number], [name], [placeName10], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_44_20_33_19_23] ON [dbo].[" + StateName + "_Right]([conCtyName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_48_19_23_52_44_56_33_26] ON [dbo].[" + StateName + "_Right]([subMcdName10], [fromHN_Number], [toHN_Number], [couSubName10], [conCtyName10], [countyName10], [name], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_48_20_33_19_23_26] ON [dbo].[" + StateName + "_Right]([subMcdName10], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_20_33_26_40_19] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [name], [zip], [placeName10], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_26_33_40_19_67] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [zip], [name], [placeName10], [fromHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_33_26_40_19] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [name], [zip], [placeName10], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_20_33_23] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [fromHN_Number_Even], [name], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_20_34_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [fromHN_Number_Even], [name_Soundex], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_23_33_40_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [name], [placeName10], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_56_34_20_19_23_67_26_44_48] ON [dbo].[" + StateName + "_Right]([countyName10], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName10], [subMcdName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_52_34_20_19_23_67_26_44] ON [dbo].[" + StateName + "_Right]([couSubName10], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_48_34_20_19_23_67_26] ON [dbo].[" + StateName + "_Right]([subMcdName10], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_34_20_26_40_19] ON [dbo].[" + StateName + "_Right]([UniqueId], [name_Soundex], [fromHN_Number_Even], [zip], [placeName10], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_34_20_19] ON [dbo].[" + StateName + "_Right]([UniqueId], [name_Soundex], [fromHN_Number_Even], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_26_44_48_52] ON [dbo].[" + StateName + "_Right]([UniqueId], [zip], [conCtyName10], [subMcdName10], [couSubName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_34_20_26_40_23_67] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [zip], [placeName10], [toHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_19_34_20_23_67_26_44_48_52_56] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [toHN_Number], [UniqueId], [zip], [conCtyName10], [subMcdName10], [couSubName10], [countyName10]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_49_20_34_19_23_26_41] ON [dbo].[" + StateName + "_Right]([subMcdName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_45_20_34_19_23_26] ON [dbo].[" + StateName + "_Right]([conCtyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_57_20_34_19_23_26_41_45_49] ON [dbo].[" + StateName + "_Right]([countyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_53_20_34_19_23_26_41_45] ON [dbo].[" + StateName + "_Right]([couSubName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_41_53_19_23_26_57_45_49_34] ON [dbo].[" + StateName + "_Right]([placeName00_Soundex], [couSubName00_Soundex], [fromHN_Number], [toHN_Number], [zip], [countyName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [name_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_19_26_34_53_57_41_45_20] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number], [zip], [name_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [placeName00_Soundex], [conCtyName00_Soundex], [fromHN_Number_Even]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_41_20_34_19_23] ON [dbo].[" + StateName + "_Right]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_26_20_34_19_23_41_45_49_53_57] ON [dbo].[" + StateName + "_Right]([zip], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_67_20_34_19_23_26_41_45_49_53] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_41_20_34_19_23_26_45_49_53_57_67] ON [dbo].[" + StateName + "_Right]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_" + StateName + "_23_20_34_19_26_41_45_49_53_57_67] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";


            // Right side 2010 stats
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_20_34_19_23_26_45_53_61_69_77] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_45_53_61_69] ON [dbo].[" + StateName + "_Right]([zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_45_53_61_69_77] ON [dbo].[" + StateName + "_Right]([zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_45_53_61_69_77_90] ON [dbo].[" + StateName + "_Right]([zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_20_34_19_23_90_45_53_61_69_77_1_2_3_4_5] ON [dbo].[" + StateName + "_Right]([zip], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [tlid], [fromLon], [fromLat], [toLon], [toLat]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_45_20_34_19_23_90] ON [dbo].[" + StateName + "_Right]([placeName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_53_20_34_19_23_90_26] ON [dbo].[" + StateName + "_Right]([conCtyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_61_20_34_19_23_90_26_45] ON [dbo].[" + StateName + "_Right]([subMcdName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_61_20_34_19_23_90_26_45_53_69_77_1_2_3_4_5] ON [dbo].[" + StateName + "_Right]([subMcdName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [tlid], [fromLon], [fromLat], [toLon], [toLat]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_69_77_26_45_61_53] ON [dbo].[" + StateName + "_Right]([couSubName10_Soundex], [countyName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [conCtyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_69_20_34_19_23_90_26_45_53] ON [dbo].[" + StateName + "_Right]([couSubName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_77_69_26_45_61_53_90_20_34_19] ON [dbo].[" + StateName + "_Right]([countyName10_Soundex], [couSubName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [conCtyName10_Soundex], [UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_77_20_34_19_23_90_26_45_53_61] ON [dbo].[" + StateName + "_Right]([countyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_1_2_3_4_5_7_11_18_19_21_22_23_25_26_27] ON [dbo].[" + StateName + "_Right]([UniqueId], [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Number], [fromHN_Unit], [toHN], [toHN_Number], [toHN_Unit], [zip], [plus4]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_1_2_3_4_5_7_11_18_21_22] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_45_53_61_69_77_1_2_3_4_5] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [tlid], [fromLon], [fromLat], [toLon], [toLat]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_45_53_61_69_77] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_45_53_61_69] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_23_19_26_34] ON [dbo].[" + StateName + "_Right]([UniqueId], [toHN_Number], [fromHN_Number], [zip], [name_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_26_45_53_61_69] ON [dbo].[" + StateName + "_Right]([UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_26_69] ON [dbo].[" + StateName + "_Right]([UniqueId], [zip], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_34_26_23_19] ON [dbo].[" + StateName + "_Right]([UniqueId], [name_Soundex], [zip], [toHN_Number], [fromHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_69_77_26_45_61_53_20_34_19] ON [dbo].[" + StateName + "_Right]([UniqueId], [couSubName10_Soundex], [countyName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [conCtyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_77_69_26_45_61] ON [dbo].[" + StateName + "_Right]([UniqueId], [countyName10_Soundex], [couSubName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_19_69_77_23_34_26_45_53_20] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [couSubName10_Soundex], [countyName10_Soundex], [toHN_Number], [name_Soundex], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [fromHN_Number_Even]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_19_69_77_23_26_45_61_34_20] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [couSubName10_Soundex], [countyName10_Soundex], [toHN_Number], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [name_Soundex], [fromHN_Number_Even]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_53_20_34_19_23_26] ON [dbo].[" + StateName + "_Right]([conCtyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_77_20_34_19_23_26_45_53_61] ON [dbo].[" + StateName + "_Right]([countyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_69_20_34_19_23_26_45_53] ON [dbo].[" + StateName + "_Right]([couSubName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex]) ; ";



            // Left side 2010 stats
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_20_34_19_23_26_45_53_61_69_77] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_45_53_61_69] ON [dbo].[" + StateName + "_Left]([zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_45_53_61_69_77] ON [dbo].[" + StateName + "_Left]([zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_45_53_61_69_77_90] ON [dbo].[" + StateName + "_Left]([zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_26_20_34_19_23_90_45_53_61_69_77_1_2_3_4_5] ON [dbo].[" + StateName + "_Left]([zip], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [tlid], [fromLon], [fromLat], [toLon], [toLat]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_45_20_34_19_23_90] ON [dbo].[" + StateName + "_Left]([placeName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_53_20_34_19_23_90_26] ON [dbo].[" + StateName + "_Left]([conCtyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_61_20_34_19_23_90_26_45] ON [dbo].[" + StateName + "_Left]([subMcdName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_61_20_34_19_23_90_26_45_53_69_77_1_2_3_4_5] ON [dbo].[" + StateName + "_Left]([subMcdName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [tlid], [fromLon], [fromLat], [toLon], [toLat]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_69_77_26_45_61_53] ON [dbo].[" + StateName + "_Left]([couSubName10_Soundex], [countyName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [conCtyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_69_20_34_19_23_90_26_45_53] ON [dbo].[" + StateName + "_Left]([couSubName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_77_69_26_45_61_53_90_20_34_19] ON [dbo].[" + StateName + "_Left]([countyName10_Soundex], [couSubName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [conCtyName10_Soundex], [UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_77_20_34_19_23_90_26_45_53_61] ON [dbo].[" + StateName + "_Left]([countyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_1_2_3_4_5_7_11_18_19_21_22_23_25_26_27] ON [dbo].[" + StateName + "_Left]([UniqueId], [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Number], [fromHN_Unit], [toHN], [toHN_Number], [toHN_Unit], [zip], [plus4]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_1_2_3_4_5_7_11_18_21_22] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_45_53_61_69_77_1_2_3_4_5] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex], [tlid], [fromLon], [fromLat], [toLon], [toLat]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_45_53_61_69_77] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex], [countyName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_20_34_19_23_26_45_53_61_69] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_23_19_26_34] ON [dbo].[" + StateName + "_Left]([UniqueId], [toHN_Number], [fromHN_Number], [zip], [name_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_26_45_53_61_69] ON [dbo].[" + StateName + "_Left]([UniqueId], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_26_69] ON [dbo].[" + StateName + "_Left]([UniqueId], [zip], [couSubName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_34_26_23_19] ON [dbo].[" + StateName + "_Left]([UniqueId], [name_Soundex], [zip], [toHN_Number], [fromHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_69_77_26_45_61_53_20_34_19] ON [dbo].[" + StateName + "_Left]([UniqueId], [couSubName10_Soundex], [countyName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [conCtyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_90_77_69_26_45_61] ON [dbo].[" + StateName + "_Left]([UniqueId], [countyName10_Soundex], [couSubName10_Soundex], [zip], [placeName10_Soundex], [subMcdName10_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_19_69_77_23_34_26_45_53_20] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [couSubName10_Soundex], [countyName10_Soundex], [toHN_Number], [name_Soundex], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [fromHN_Number_Even]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_19_69_77_23_26_45_61_34_20] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [couSubName10_Soundex], [countyName10_Soundex], [toHN_Number], [zip], [placeName10_Soundex], [subMcdName10_Soundex], [name_Soundex], [fromHN_Number_Even]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_53_20_34_19_23_26] ON [dbo].[" + StateName + "_Left]([conCtyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_77_20_34_19_23_26_45_53_61] ON [dbo].[" + StateName + "_Left]([countyName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex], [subMcdName10_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_" + StateName + "_69_20_34_19_23_26_45_53] ON [dbo].[" + StateName + "_Left]([couSubName10_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName10_Soundex], [conCtyName10_Soundex]) ; ";



            // these are base indexes required in all query scenarios
            string SQLPostInsertSingleTableUpdateBaseIndexes = "";
            //SQLPostInsertSingleTableUpdateBaseIndexes += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD UniqueId INT IDENTITY (1, 1); ";
            //SQLPostInsertSingleTableUpdateBaseIndexes += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD UniqueId INT IDENTITY (1, 1); ";


            // these queries are the spatial indexes required in all scenarios
            string SQLPostInsertSingleTableUpdateSpatialIndexes = "";
            SQLPostInsertSingleTableUpdateSpatialIndexes += " CREATE SPATIAL INDEX [idx_geog] ON [dbo].[" + StateName + "_Left]   (  [shapeGeog]   )USING  GEOGRAPHY_GRID   WITH (  GRIDS =(LEVEL_1 = MEDIUM,LEVEL_2 = MEDIUM,LEVEL_3 = MEDIUM,LEVEL_4 = MEDIUM),  CELLS_PER_OBJECT = 16, PAD_INDEX  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            SQLPostInsertSingleTableUpdateSpatialIndexes += " CREATE SPATIAL INDEX [idx_geog] ON [dbo].[" + StateName + "_Right]   (  [shapeGeog]   )USING  GEOGRAPHY_GRID   WITH (  GRIDS =(LEVEL_1 = MEDIUM,LEVEL_2 = MEDIUM,LEVEL_3 = MEDIUM,LEVEL_4 = MEDIUM),  CELLS_PER_OBJECT = 16, PAD_INDEX  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";


            // these indexes are queries that use the clustered index for the whole row
            string SQLPostInsertSingleTableUpdateIndexesAllClusteredTogether = "";
            SQLPostInsertSingleTableUpdateIndexesAllClusteredTogether += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_even-name-from-to-zip-place-conCity-mcd-couSub-Uniqueid] PRIMARY KEY CLUSTERED ([fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC,	[UniqueId] ASC); ";
            SQLPostInsertSingleTableUpdateIndexesAllClusteredTogether += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_even-name-from-to-zip-place-conCity-mcd-couSub-Uniqueid] PRIMARY KEY CLUSTERED ([fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC,	[UniqueId] ASC); ";
            //SQLPostInsertSingleTableUpdateIndexesAllClusteredTogether += " CREATE CLUSTERED INDEX [_dta_index_" + StateName + "_Left_even-name-from-to-zip-place-conCity-mcd-couSub-Uniqueid] ON [dbo].[" + StateName + "_Left] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC,	[UniqueId] ASC)  WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            //SQLPostInsertSingleTableUpdateIndexesAllClusteredTogether += " CREATE CLUSTERED INDEX [_dta_index_" + StateName + "_Right_even-name-from-to-zip-place-conCity-mcd-couSub-Uniqueid] ON [dbo].[" + StateName + "_Right] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC,	[UniqueId] ASC)  WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";


            // these indexes are for queries that only look at the name+zip, name+city,conCity,countySub,county and name+zip+city,conCity,countySub,county (no odd even and no stret numbers)
            string SQLPostInsertSingleTableUpdateIndexesNoNumbers = "";
            // name + zip
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name-zip] ON [dbo].[" + StateName + "_Left] ([name_Soundex],[zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidL],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lFromAdd_Number_Even],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name-zip] ON [dbo].[" + StateName + "_Right] ([name_Soundex],[zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidR],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rFromAdd_Number_Even],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            // name only
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Left] ([name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[zip],[tfidL],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lFromAdd_Number_Even],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Right] ([name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[zip],[tfidR],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rFromAdd_Number_Even],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            // zip only
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_zip] ON [dbo].[" + StateName + "_Left] ([zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidL],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lFromAdd_Number_Even],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_zip] ON [dbo].[" + StateName + "_Right] ([zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidR],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rFromAdd_Number_Even],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";



            // these indexes are queries that look for name + (zip or city or conCity or mcd or countySub or county) all at once so only one covering index is needed
            string SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether = "";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_even-Name-From-To-Zip-Place-Con-Mcd-Cousub-County] ON [dbo].[" + StateName + "_Left] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_even-Name-From-To-Zip-Place-Con-Mcd-Cousub-County] ON [dbo].[" + StateName + "_Right] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";

            // Right side 2010 indexes
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K19_K23_K26_K41_K49_K57_K65_K73_1_2_3_4_5_7_8_9_11_12_13_14_18_21_22_25_27_29_30_31_] ON [dbo].[" + StateName + "_Right] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC) INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_SoundexDM],[placeFp10],[placeName10],[placeName10_Soundex],[placeName10_SoundexDM],[conCtyFp00],[conCtyName00_SoundexDM],[conCtyFp10],[conCtyName10],[conCtyName10_Soundex],[conCtyName10_SoundexDM],[subMcdFp00],[subMcdName00_SoundexDM],[subMcdFp10],[subMcdName10],[subMcdName10_Soundex],[subMcdName10_SoundexDM],[couSubFp00],[couSubName00_SoundexDM],[couSubFp10],[couSubName10],[couSubName10_Soundex],[couSubName10_SoundexDM],[countyFp00],[countyName00_SoundexDM],[countyFp10],[countyName10],[countyName10_Soundex],[countyName10_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[stateFp10],[tractCe10],[blkGrpCe10],[blockCe10],[shapeGeog],[shapeGeom],[UniqueId]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K19_K23_K26_K90_K45_K53_K61_K69_K77_1_2_3_4_5_7_8_9_11_12_13_14_18_21_22_25_27_29_30_] ON [dbo].[" + StateName + "_Right] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[UniqueId] ASC,	[placeName10_Soundex] ASC,	[conCtyName10_Soundex] ASC,	[subMcdName10_Soundex] ASC,	[couSubName10_Soundex] ASC,	[countyName10_Soundex] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp10],[placeName10],[placeName10_SoundexDM],[conCtyFp10],[conCtyName10],[conCtyName10_SoundexDM],[subMcdFp10],[subMcdName10],[subMcdName10_SoundexDM],[couSubFp10],[couSubName10],[couSubName10_SoundexDM],[countyFp10],[countyName10],[countyName10_SoundexDM],[stateFp10],[tractCe10],[blkGrpCe10],[blockCe10],[shapeGeog],[shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K19_K23_K90_K26_K45_K53_K61_K69_K77_K1_K2_K3_K4_K5_7_8_9_11_12_13_14_18_21_22_25_27_] ON [dbo].[" + StateName + "_Right] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[UniqueId] ASC,	[zip] ASC,	[placeName10_Soundex] ASC,	[conCtyName10_Soundex] ASC,	[subMcdName10_Soundex] ASC,	[couSubName10_Soundex] ASC,	[countyName10_Soundex] ASC,	[tlid] ASC,	[fromLon] ASC,	[fromLat] ASC,	[toLon] ASC,	[toLat] ASC)INCLUDE ( [rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp10],[placeName10],[placeName10_SoundexDM],[conCtyFp10],[conCtyName10],[conCtyName10_SoundexDM],[subMcdFp10],[subMcdName10],[subMcdName10_SoundexDM],[couSubFp10],[couSubName10],[couSubName10_SoundexDM],[countyFp10],[countyName10],[countyName10_SoundexDM],[stateFp10],[tractCe10],[blkGrpCe10],[blockCe10],[shapeGeog],[shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]; ";

            // Left side 2010 indexes
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K19_K23_K26_K41_K49_K57_K65_K73_1_2_3_4_5_7_8_9_11_12_13_14_18_21_22_25_27_29_30_31_] ON [dbo].[" + StateName + "_Left] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC) INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_SoundexDM],[placeFp10],[placeName10],[placeName10_Soundex],[placeName10_SoundexDM],[conCtyFp00],[conCtyName00_SoundexDM],[conCtyFp10],[conCtyName10],[conCtyName10_Soundex],[conCtyName10_SoundexDM],[subMcdFp00],[subMcdName00_SoundexDM],[subMcdFp10],[subMcdName10],[subMcdName10_Soundex],[subMcdName10_SoundexDM],[couSubFp00],[couSubName00_SoundexDM],[couSubFp10],[couSubName10],[couSubName10_Soundex],[couSubName10_SoundexDM],[countyFp00],[countyName00_SoundexDM],[countyFp10],[countyName10],[countyName10_Soundex],[countyName10_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[stateFp10],[tractCe10],[blkGrpCe10],[blockCe10],[shapeGeog],[shapeGeom],[UniqueId]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K19_K23_K26_K90_K45_K53_K61_K69_K77_1_2_3_4_5_7_8_9_11_12_13_14_18_21_22_25_27_29_30_] ON [dbo].[" + StateName + "_Left] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[UniqueId] ASC,	[placeName10_Soundex] ASC,	[conCtyName10_Soundex] ASC,	[subMcdName10_Soundex] ASC,	[couSubName10_Soundex] ASC,	[countyName10_Soundex] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp10],[placeName10],[placeName10_SoundexDM],[conCtyFp10],[conCtyName10],[conCtyName10_SoundexDM],[subMcdFp10],[subMcdName10],[subMcdName10_SoundexDM],[couSubFp10],[couSubName10],[couSubName10_SoundexDM],[countyFp10],[countyName10],[countyName10_SoundexDM],[stateFp10],[tractCe10],[blkGrpCe10],[blockCe10],[shapeGeog],[shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K19_K23_K90_K26_K45_K53_K61_K69_K77_K1_K2_K3_K4_K5_7_8_9_11_12_13_14_18_21_22_25_27_] ON [dbo].[" + StateName + "_Left] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[UniqueId] ASC,	[zip] ASC,	[placeName10_Soundex] ASC,	[conCtyName10_Soundex] ASC,	[subMcdName10_Soundex] ASC,	[couSubName10_Soundex] ASC,	[countyName10_Soundex] ASC,	[tlid] ASC,	[fromLon] ASC,	[fromLat] ASC,	[toLon] ASC,	[toLat] ASC)INCLUDE ( [lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp10],[placeName10],[placeName10_SoundexDM],[conCtyFp10],[conCtyName10],[conCtyName10_SoundexDM],[subMcdFp10],[subMcdName10],[subMcdName10_SoundexDM],[couSubFp10],[couSubName10],[couSubName10_SoundexDM],[countyFp10],[countyName10],[countyName10_SoundexDM],[stateFp10],[tractCe10],[blkGrpCe10],[blockCe10],[shapeGeog],[shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]; ";





            // these indexes are queries that look for name + (zip or city) or (zip or conCity or mcd or countySub or county) seperately so a whole bunchh of indexes are needed
            string SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether = "";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";

            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_zip_place_from_to_even] ON [dbo].[" + StateName + "_Left] (	[name_Soundex] ASC,	[zip] ASC,	[placeName10] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[fromHN_Number_Even] ASC)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_place_even_nameSdx_zip_from_to] ON [dbo].[" + StateName + "_Left] (	[placeName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[zip] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_zip_even_nameSdx_from_to_conCity_mcd_couSub_county] ON [dbo].[" + StateName + "_Left] (	[zip] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[conCtyName10] ASC,	[subMcdName10] ASC,	[couSubName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_mcd_even_nameSdx_from_to_zip_concity_countySub_county] ON [dbo].[" + StateName + "_Left] (	[subMcdName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName10] ASC,	[couSubName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_couSub_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Left] (	[couSubName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName10] ASC,	[subMcdName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_concity_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Left] (	[conCtyName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[subMcdName10] ASC,	[couSubName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_county_even_nameSdx_from_to_zip_conCity_mcd_couSub] ON [dbo].[" + StateName + "_Left] (	[countyName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName10] ASC,	[subMcdName10] ASC,	[couSubName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_even_from_to_zip] ON [dbo].[" + StateName + "_Left] (	[name_Soundex] ASC,	[fromHN_Number_Even] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[UniqueId] ASC)INCLUDE ( [placeName10]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";

            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_zip_place_from_to_even] ON [dbo].[" + StateName + "_Right] (	[name_Soundex] ASC,	[zip] ASC,	[placeName10] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[fromHN_Number_Even] ASC)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_place_even_nameSdx_zip_from_to] ON [dbo].[" + StateName + "_Right] (	[placeName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[zip] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_zip_even_nameSdx_from_to_conCity_mcd_couSub_county] ON [dbo].[" + StateName + "_Right] (	[zip] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[conCtyName10] ASC,	[subMcdName10] ASC,	[couSubName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_mcd_even_nameSdx_from_to_zip_concity_countySub_county] ON [dbo].[" + StateName + "_Right] (	[subMcdName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName10] ASC,	[couSubName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_couSub_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Right] (	[couSubName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName10] ASC,	[subMcdName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_concity_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Right] (	[conCtyName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[subMcdName10] ASC,	[couSubName10] ASC,	[countyName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_county_even_nameSdx_from_to_zip_conCity_mcd_couSub] ON [dbo].[" + StateName + "_Right] (	[countyName10] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName10] ASC,	[subMcdName10] ASC,	[couSubName10] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_even_from_to_zip] ON [dbo].[" + StateName + "_Right] (	[name_Soundex] ASC,	[fromHN_Number_Even] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[UniqueId] ASC)INCLUDE ( [placeName10]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";




            // these indexes are queries that look for exact and soundex versions seperately
            string SQLPostInsertSingleTableUpdateIndexesExactAndSoundex = "";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";

            // Left side exact

            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name_placename] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[zip],[name],[placeName10])INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]) ; ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name_placename] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[name],[placeName10]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[zip],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";

            // Right side exact
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name_placename] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[zip],[name],[placeName10]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name_placename] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[name],[placeName10]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[zip],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";

            // Left side soundex
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_nameSdx] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";

            // Right side soundex
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_nameSdx] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName10],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName10],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName10],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName10],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName10],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00], [shapeGeog], [shapeGeom]); ";



            // the following will create stored procedures for the soundex queries
            string SQLPostInsertSingleTableUpdateStoredProcedures = "";
            SQLPostInsertSingleTableUpdateStoredProcedures += " CREATE PROCEDURE " + StateName + "_Left ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- Add the parameters for the stored procedure here ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " @param1 VarChar (4)  -- nameSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param2 VarChar (5)  -- zip ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param3 VarChar (4)  -- placeSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param4 VarChar (4)  -- concitySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param5 VarChar (4)  -- mcdSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param6 VarChar (4)  -- countySubSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param7 VarChar (4)  -- countySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param8 bit          -- even  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param9 int          -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param10 int         -- >= number    ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param11 int         -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param12 int         -- >= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " AS ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " BEGIN ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- SET NOCOUNT ON added to prevent extra result sets from ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- interfering with SELECT statements. ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SET NOCOUNT ON; ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SELECT ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon  , fromLat  , toLon  , toLat  , fullName  , preDirAbrv  , preTypAbrv  , preQualAbr  , name , name_Soundex  , name_SoundexDM  , sufDirAbrv  , sufTypAbrv  , sufQualAbr  ,  shapeGeog  ,  shapeGeom  , lFromAdd   , lToAdd   , fromHn as lFromHn   , fromHN_Number as lfromHN_Number  , fromHN_Unit as lfromHN_Unit  , toHn as lToHn   , toHN_Number as ltoHN_Number  , toHN_Unit as ltoHN_Unit  , zip as lZip   , plus4 as lZipPlus4   , placeFp00 as lplaceFp00   , placeName00 as lplaceName00  , placeName10_Soundex as lplaceName10_Soundex   , placeName10_SoundexDM as lplaceName10_SoundexDM  , conCtyFp00 as lconCtyFp00   , conCtyName00 as lconCtyName00   , conCtyName10_Soundex as lconCtyName10_Soundex   , conCtyName10_SoundexDM as lconCtyName10_SoundexDM  , subMcdFp00 as lsubMcdFp00   , subMcdName00 as lsubMcdName00  , subMcdName10_Soundex as lsubMcdName10_Soundex   , subMcdName10_SoundexDM as lsubMcdName10_SoundexDM  , couSubFp00 as lcouSubFp00   , couSubName00 as lcouSubName00  , couSubName10_Soundex as lcouSubName10_Soundex   , couSubName10_SoundexDM as lcouSubName10_SoundexDM  , countyFp00 as lcountyFp00   , countyName00 as lcountyName00  , countyName10_Soundex as lcountyName10_Soundex   , countyName10_SoundexDM as lcountyName10_SoundexDM  , stateFp00 as lstateFp00   , tractCe00 as ltractCe00   , blkGrpCe00 as lblkGrpCe00   , blockCe00 as lblockCe00   , suffix1Ce as lsuffix1Ce ";
            SQLPostInsertSingleTableUpdateStoredProcedures += "  , '' as rFromAdd   , '' as rToAdd   , '' as rFromHn   , '' as rfromHN_Number  , '' as rfromHN_Unit  , '' as rToHn   , '' as rtoHN_Number , '' as rtoHN_Unit  , '' as rZip   , '' as rZipPlus4   , '' as rplaceFp00   , '' as rplaceName00   , '' as rplaceName10_Soundex   , '' as rplaceName10_SoundexDM   , '' as rconCtyFp00   , '' as rconCtyName00   , '' as rconCtyName10_Soundex   , '' as rconCtyName10_SoundexDM   , '' as rsubMcdFp00   , '' as rsubMcdName00   , '' as rsubMcdName10_Soundex   , '' as rsubMcdName10_SoundexDM   , '' as rcouSubFp00   , '' as rcouSubName00   , '' as rcouSubName10_Soundex   , '' as rcouSubName10_SoundexDM   , '' as rcountyFp00   , '' as rcountyName00   , '' as rcountyName10_Soundex   , '' as rcountyName10_SoundexDM   , '' as rstateFp00   , '' as rtractCe00   , '' as rblkGrpCe00   , '' as rblockCe00   , '' as rsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " FROM ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " WHERE ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param1     ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " (  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " zip=@param2 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " placeName10_Soundex=@param3 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " conCtyName10_Soundex=@param4 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " subMcdName10_Soundex=@param5 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " couSubName10_Soundex=@param6 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " countyName10_Soundex=@param7 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " )  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " fromHn_Number_Even = @param8 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number >=@param9 and toHn_Number <=@param10 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " or  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number <=@param11 and toHn_Number >=@param12 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " END; ";

            SQLPostInsertSingleTableUpdateStoredProcedures += " CREATE PROCEDURE " + StateName + "_Right ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- Add the parameters for the stored procedure here ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " @param1 VarChar (4)  -- nameSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param2 VarChar (5)  -- zip ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param3 VarChar (4)  -- placeSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param4 VarChar (4)  -- concitySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param5 VarChar (4)  -- mcdSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param6 VarChar (4)  -- countySubSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param7 VarChar (4)  -- countySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param8 bit          -- even  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param9 int          -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param10 int         -- >= number    ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param11 int         -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param12 int         -- >= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " AS ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " BEGIN ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- SET NOCOUNT ON added to prevent extra result sets from ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- interfering with SELECT statements. ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SET NOCOUNT ON; ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SELECT ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon ,fromLat ,toLon ,toLat ,fullName ,preDirAbrv ,preTypAbrv ,preQualAbr ,name ,name_Soundex ,name_SoundexDM ,sufDirAbrv ,sufTypAbrv ,sufQualAbr , shapeGeog , shapeGeom ,rFromAdd  ,rToAdd  ,fromHn as rFromHn  ,fromHN_Number as rfromHN_Number ,fromHN_Unit as rfromHN_Unit ,toHn as rToHn  ,toHN_Number as rtoHN_Number ,toHN_Unit as rtoHN_Unit ,zip as rZip ,plus4 as rZipPlus4  ,placeFp00 as rplaceFp00  ,placeName00 as rplaceName00 ,placeName10_Soundex as rplaceName10_Soundex  ,placeName10_SoundexDM as rplaceName10_SoundexDM ,conCtyFp00 as rconCtyFp00  ,conCtyName00 as rconCtyName00  ,conCtyName10_Soundex as rconCtyName10_Soundex  ,conCtyName10_SoundexDM as rconCtyName10_SoundexDM ,subMcdFp00 as rsubMcdFp00  ,subMcdName00 as rsubMcdName00 ,subMcdName10_Soundex as rsubMcdName10_Soundex  ,subMcdName10_SoundexDM as rsubMcdName10_SoundexDM ,couSubFp00 as rcouSubFp00  ,couSubName00 as rcouSubName00 ,couSubName10_Soundex as rcouSubName10_Soundex  ,couSubName10_SoundexDM as rcouSubName10_SoundexDM ,countyFp00 as rcountyFp00  ,countyName00 as rcountyName00 ,countyName10_Soundex as rcountyName10_Soundex ,countyName10_SoundexDM as rcountyName10_SoundexDM  ,stateFp00 as rstateFp00 ,tractCe00 as rtractCe00 ,blkGrpCe00 as rblkGrpCe00 ,blockCe00 as rblockCe00 ,suffix1Ce as rsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " , '' as lFromAdd , '' as lToAdd , '' as lFromHn , '' as lfromHN_Number  , '' as lfromHN_Unit  , '' as lToHn , '' as ltoHN_Number  , '' as ltoHN_Unit  , '' as lZip , '' as lZipPlus4 , '' as lplaceFp00 , '' as lplaceName00 , '' as lplaceName10_Soundex , '' as lplaceName10_SoundexDM , '' as lconCtyFp00 , '' as lconCtyName00  , '' as lconCtyName10_Soundex , '' as lconCtyName10_SoundexDM , '' as lsubMcdFp00 , '' as lsubMcdName00 , '' as lsubMcdName10_Soundex , '' as lsubMcdName10_SoundexDM , '' as lcouSubFp00 , '' as lcouSubName00 , '' as lcouSubName10_Soundex , '' as lcouSubName10_SoundexDM , '' as lcountyFp00 , '' as lcountyName00 , '' as lcountyName10_Soundex , '' as lcountyName10_SoundexDM , '' as lstateFp00 , '' as ltractCe00 , '' as lblkGrpCe00 , '' as lblockCe00 , '' as lsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " FROM ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " WHERE ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param1     ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " (  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " zip=@param2 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " placeName10_Soundex=@param3 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " conCtyName10_Soundex=@param4 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " subMcdName10_Soundex=@param5 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " couSubName10_Soundex=@param6 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " countyName10_Soundex=@param7 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " )  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " fromHn_Number_Even = @param8 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number >=@param9 and toHn_Number <=@param10 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " or  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number <=@param11 and toHn_Number >=@param12 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " END; ";


            SQLPostInsertSingleTableUpdateStoredProcedures += " CREATE PROCEDURE " + StateName + "_Left_WithNumberName ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- Add the parameters for the stored procedure here ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " @param1 VarChar (4)  -- nameSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param2 VarChar (5)  -- zip ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param3 VarChar (4)  -- placeSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param4 VarChar (4)  -- concitySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param5 VarChar (4)  -- mcdSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param6 VarChar (4)  -- countySubSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param7 VarChar (4)  -- countySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param8 bit          -- even  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param9 int          -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param10 int         -- >= number    ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param11 int         -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param12 int         -- >= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param13 VarChar (4) -- nameSoundexNumberAbbreviation ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " AS ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " BEGIN ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- SET NOCOUNT ON added to prevent extra result sets from ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- interfering with SELECT statements. ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SET NOCOUNT ON; ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SELECT ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon  , fromLat  , toLon  , toLat  , fullName  , preDirAbrv  , preTypAbrv  , preQualAbr  , name , name_Soundex  , name_SoundexDM  , sufDirAbrv  , sufTypAbrv  , sufQualAbr  ,  shapeGeog  ,  shapeGeom  , lFromAdd   , lToAdd   , fromHn as lFromHn   , fromHN_Number as lfromHN_Number  , fromHN_Unit as lfromHN_Unit  , toHn as lToHn   , toHN_Number as ltoHN_Number  , toHN_Unit as ltoHN_Unit  , zip as lZip   , plus4 as lZipPlus4   , placeFp00 as lplaceFp00   , placeName00 as lplaceName00  , placeName10_Soundex as lplaceName10_Soundex   , placeName10_SoundexDM as lplaceName10_SoundexDM  , conCtyFp00 as lconCtyFp00   , conCtyName00 as lconCtyName00   , conCtyName10_Soundex as lconCtyName10_Soundex   , conCtyName10_SoundexDM as lconCtyName10_SoundexDM  , subMcdFp00 as lsubMcdFp00   , subMcdName00 as lsubMcdName00  , subMcdName10_Soundex as lsubMcdName10_Soundex   , subMcdName10_SoundexDM as lsubMcdName10_SoundexDM  , couSubFp00 as lcouSubFp00   , couSubName00 as lcouSubName00  , couSubName10_Soundex as lcouSubName10_Soundex   , couSubName10_SoundexDM as lcouSubName10_SoundexDM  , countyFp00 as lcountyFp00   , countyName00 as lcountyName00  , countyName10_Soundex as lcountyName10_Soundex   , countyName10_SoundexDM as lcountyName10_SoundexDM  , stateFp00 as lstateFp00   , tractCe00 as ltractCe00   , blkGrpCe00 as lblkGrpCe00   , blockCe00 as lblockCe00   , suffix1Ce as lsuffix1Ce ";
            SQLPostInsertSingleTableUpdateStoredProcedures += "  , '' as rFromAdd   , '' as rToAdd   , '' as rFromHn   , '' as rfromHN_Number  , '' as rfromHN_Unit  , '' as rToHn   , '' as rtoHN_Number , '' as rtoHN_Unit  , '' as rZip   , '' as rZipPlus4   , '' as rplaceFp00   , '' as rplaceName00   , '' as rplaceName10_Soundex   , '' as rplaceName10_SoundexDM   , '' as rconCtyFp00   , '' as rconCtyName00   , '' as rconCtyName10_Soundex   , '' as rconCtyName10_SoundexDM   , '' as rsubMcdFp00   , '' as rsubMcdName00   , '' as rsubMcdName10_Soundex   , '' as rsubMcdName10_SoundexDM   , '' as rcouSubFp00   , '' as rcouSubName00   , '' as rcouSubName10_Soundex   , '' as rcouSubName10_SoundexDM   , '' as rcountyFp00   , '' as rcountyName00   , '' as rcountyName10_Soundex   , '' as rcountyName10_SoundexDM   , '' as rstateFp00   , '' as rtractCe00   , '' as rblkGrpCe00   , '' as rblockCe00   , '' as rsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " FROM ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " WHERE ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param1     ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param13 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " (  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " zip=@param2 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " placeName10_Soundex=@param3 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " conCtyName10_Soundex=@param4 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " subMcdName10_Soundex=@param5 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " couSubName10_Soundex=@param6 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " countyName10_Soundex=@param7 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " )  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " fromHn_Number_Even = @param8 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number >=@param9 and toHn_Number <=@param10 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " or  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number <=@param11 and toHn_Number >=@param12 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " END; ";

            SQLPostInsertSingleTableUpdateStoredProcedures += " CREATE PROCEDURE " + StateName + "_Right_WithNumberName ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- Add the parameters for the stored procedure here ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " @param1 VarChar (4)  -- nameSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param2 VarChar (5)  -- zip ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param3 VarChar (4)  -- placeSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param4 VarChar (4)  -- concitySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param5 VarChar (4)  -- mcdSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param6 VarChar (4)  -- countySubSoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param7 VarChar (4)  -- countySoundex ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param8 bit          -- even  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param9 int          -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param10 int         -- >= number    ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param11 int         -- <= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param12 int         -- >= number ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ,@param13 VarChar (4) -- nameSoundexNumberAbbreviation ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " AS ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " BEGIN ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- SET NOCOUNT ON added to prevent extra result sets from ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " -- interfering with SELECT statements. ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SET NOCOUNT ON; ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " SELECT ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon ,fromLat ,toLon ,toLat ,fullName ,preDirAbrv ,preTypAbrv ,preQualAbr ,name ,name_Soundex ,name_SoundexDM ,sufDirAbrv ,sufTypAbrv ,sufQualAbr , shapeGeog , shapeGeom ,rFromAdd  ,rToAdd  ,fromHn as rFromHn  ,fromHN_Number as rfromHN_Number ,fromHN_Unit as rfromHN_Unit ,toHn as rToHn  ,toHN_Number as rtoHN_Number ,toHN_Unit as rtoHN_Unit ,zip as rZip ,plus4 as rZipPlus4  ,placeFp00 as rplaceFp00  ,placeName00 as rplaceName00 ,placeName10_Soundex as rplaceName00_Soundex  ,placeName10_SoundexDM as rplaceName00_SoundexDM ,conCtyFp00 as rconCtyFp00  ,conCtyName00 as rconCtyName00  ,conCtyName10_Soundex as rconCtyName00_Soundex  ,conCtyName10_SoundexDM as rconCtyName00_SoundexDM ,subMcdFp00 as rsubMcdFp00  ,subMcdName00 as rsubMcdName00 ,subMcdName10_Soundex as rsubMcdName00_Soundex  ,subMcdName10_SoundexDM as rsubMcdName00_SoundexDM ,couSubFp00 as rcouSubFp00  ,couSubName00 as rcouSubName00 ,couSubName10_Soundex as rcouSubName00_Soundex  ,couSubName10_SoundexDM as rcouSubName00_SoundexDM ,countyFp00 as rcountyFp00  ,countyName00 as rcountyName00 ,countyName10_Soundex as rcountyName00_Soundex ,countyName10_SoundexDM as rcountyName00_SoundexDM  ,stateFp00 as rstateFp00 ,tractCe00 as rtractCe00 ,blkGrpCe00 as rblkGrpCe00 ,blockCe00 as rblockCe00 ,suffix1Ce as rsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " , '' as lFromAdd , '' as lToAdd , '' as lFromHn , '' as lfromHN_Number  , '' as lfromHN_Unit  , '' as lToHn , '' as ltoHN_Number  , '' as ltoHN_Unit  , '' as lZip , '' as lZipPlus4 , '' as lplaceFp00 , '' as lplaceName00 , '' as lplaceName00_Soundex , '' as lplaceName00_SoundexDM , '' as lconCtyFp00 , '' as lconCtyName00  , '' as lconCtyName00_Soundex , '' as lconCtyName00_SoundexDM , '' as lsubMcdFp00 , '' as lsubMcdName00 , '' as lsubMcdName00_Soundex , '' as lsubMcdName00_SoundexDM , '' as lcouSubFp00 , '' as lcouSubName00 , '' as lcouSubName00_Soundex , '' as lcouSubName00_SoundexDM , '' as lcountyFp00 , '' as lcountyName00 , '' as lcountyName00_Soundex , '' as lcountyName00_SoundexDM , '' as lstateFp00 , '' as ltractCe00 , '' as lblkGrpCe00 , '' as lblockCe00 , '' as lsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " FROM ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " WHERE ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param1     ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param13 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " (  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " zip=@param2 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " placeName00_Soundex=@param3 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " conCtyName00_Soundex=@param4 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " subMcdName00_Soundex=@param5 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " couSubName00_Soundex=@param6 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " OR ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " countyName00_Soundex=@param7 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " )  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " fromHn_Number_Even = @param8 ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " and  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number >=@param9 and toHn_Number <=@param10 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " or  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ( fromHn_Number <=@param11 and toHn_Number >=@param12 ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " ) ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " END; ";

            SQLPostInsertSingleTableUpdate += SQLPostInsertSingleTableUpdateBaseIndexes;
            SQLPostInsertSingleTableUpdate += SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether;
            SQLPostInsertSingleTableUpdate += SQLPostInsertSingleTableUpdateSpatialIndexes;
            SQLPostInsertSingleTableUpdate += SQLPostInsertSingleTableUpdateStatistics;
            //SQLPostInsertSingleTableUpdate += SQLPostInsertSingleTableUpdateStoredProcedures;

        }


    }
}