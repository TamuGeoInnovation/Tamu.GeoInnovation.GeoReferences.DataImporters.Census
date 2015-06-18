using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountyFiles.Implementations
{
    public class EdgesFile : AbstractTiger2008ShapefileCountyFileLayout
    {

        public EdgesFile(string stateName, bool shouldDoOnlyStreets, bool shouldDoOnlyNamedStreets)
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

            SQLCreateTableIndexes += "CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_tfidL] ON [dbo].[" + OutputTableName + "](tfidL ASC) INCLUDE (tlid, shapeGeog, shapeGeom, lToAdd, lFromAdd) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
            SQLCreateTableIndexes += "CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_tfidR] ON [dbo].[" + OutputTableName + "](tfidR ASC) INCLUDE (tlid, shapeGeog, shapeGeom, rToAdd, rFromAdd) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";


            SQLCreateViews = new string[4];

            string sqlCreateView = "";
            sqlCreateView += " CREATE VIEW [dbo].[" + StateName + "_View_FacesLeft] ";
            sqlCreateView += " WITH SCHEMABINDING ";
            sqlCreateView += " AS ";
            sqlCreateView += " SELECT ";

            sqlCreateView += "  dbo." + StateName + "_edges.tlid,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.fromLon,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.fromLat,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.toLon,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.toLat,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.tfidL,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lFromAdd,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lFromAdd_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lFromAdd_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lFromAdd_Number_Even,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lToAdd,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lToAdd_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.lToAdd_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.fullname as edges_fullname,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.zipl as edges_zip,  ";

            sqlCreateView += "  dbo." + StateName + "_addr.arid,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.side,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN_Number_Even,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN_Number_Even,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.zip,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.plus4,  ";

            sqlCreateView += "  dbo." + StateName + "_featnames.lineArid,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.fullName,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.preDirAbrv,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.preTypAbrv,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.preQualAbr,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.name,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.name_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.name_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.sufDirAbrv,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.sufTypAbrv, ";
            sqlCreateView += "  dbo." + StateName + "_featnames.sufQualAbr, ";

            sqlCreateView += "  dbo." + StateName + "_faces.placeFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.placeName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.placeName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.placeName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.stateFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.tractCe00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.blkGrpCe00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.blockCe00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.suffix1Ce,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.tfid,  ";

            sqlCreateView += "  dbo." + StateName + "_edges.shapeGeog,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.shapeGeom  ";

            sqlCreateView += " FROM          ";
            sqlCreateView += "  dbo." + StateName + "_edges ";
            sqlCreateView += "  LEFT JOIN ";
            sqlCreateView += "  dbo." + StateName + "_addr ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_addr.tlid ";
            sqlCreateView += "  LEFT JOIN ";
            sqlCreateView += "  dbo." + StateName + "_featnames ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_featnames.tlid ";
            sqlCreateView += "  LEFT JOIN ";
            sqlCreateView += "  dbo." + StateName + "_faces ON dbo." + StateName + "_edges.tfidL = dbo." + StateName + "_faces.tfid ";

            sqlCreateView += "; ";

            SQLCreateViews[0] = sqlCreateView;

            sqlCreateView = "";
            sqlCreateView += " CREATE VIEW [dbo].[" + StateName + "_View_FacesRight] ";
            sqlCreateView += " WITH SCHEMABINDING ";
            sqlCreateView += " AS ";
            sqlCreateView += " SELECT ";
            sqlCreateView += "  dbo." + StateName + "_edges.tlid,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.fromLon,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.fromLat,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.toLon,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.toLat,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.tfidR,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RFromAdd,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RFromAdd_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RFromAdd_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RFromAdd_Number_Even,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RToAdd,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RToAdd_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.RToAdd_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.fullname as edges_fullname,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.zipr as edges_zip,  ";

            sqlCreateView += "  dbo." + StateName + "_addr.arid,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.side,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN_Number_Even,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.fromHN_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN_Number,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN_Number_Even,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.toHN_Unit,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.zip,  ";
            sqlCreateView += "  dbo." + StateName + "_addr.plus4,  ";

            sqlCreateView += "  dbo." + StateName + "_featnames.lineArid,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.fullName,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.preDirAbrv,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.preTypAbrv,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.preQualAbr,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.name,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.name_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.name_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.sufDirAbrv,  ";
            sqlCreateView += "  dbo." + StateName + "_featnames.sufTypAbrv, ";
            sqlCreateView += "  dbo." + StateName + "_featnames.sufQualAbr, ";

            sqlCreateView += "  dbo." + StateName + "_faces.placeFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.placeName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.placeName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.placeName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.conCtyName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.subMcdName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.couSubName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyName00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyName00_Soundex,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.countyName00_SoundexDM,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.stateFp00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.tractCe00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.blkGrpCe00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.blockCe00,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.suffix1Ce,  ";
            sqlCreateView += "  dbo." + StateName + "_faces.tfid,  ";

            sqlCreateView += "  dbo." + StateName + "_edges.shapeGeog,  ";
            sqlCreateView += "  dbo." + StateName + "_edges.shapeGeom  ";

            sqlCreateView += " FROM          ";
            sqlCreateView += "  dbo." + StateName + "_edges ";
            sqlCreateView += "  LEFT JOIN ";
            sqlCreateView += "  dbo." + StateName + "_addr ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_addr.tlid ";
            sqlCreateView += "  LEFT JOIN ";
            sqlCreateView += "  dbo." + StateName + "_featnames ON dbo." + StateName + "_edges.tlid = dbo." + StateName + "_featnames.tlid ";
            sqlCreateView += "  LEFT JOIN ";
            sqlCreateView += "  dbo." + StateName + "_faces ON dbo." + StateName + "_edges.tfidR = dbo." + StateName + "_faces.tfid ";

            sqlCreateView += "; ";

            SQLCreateViews[1] = sqlCreateView;


            //sqlCreateView = "";
            //sqlCreateView += " CREATE UNIQUE CLUSTERED INDEX [" + StateName + "_idx_lineArid_Arid_left] ON [dbo].[" + StateName + "_View_FacesLeft]  ";
            //sqlCreateView += " ( ";
            //sqlCreateView += " [arid] ASC, ";
            //sqlCreateView += " [linearid] ASC ";
            //sqlCreateView += " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ";

            //SQLCreateViews[2] = sqlCreateView;

            //sqlCreateView = "";
            //sqlCreateView += " CREATE UNIQUE CLUSTERED INDEX [" + StateName + "_idx_lineArid_Arid_right] ON [dbo].[" + StateName + "_View_FacesRight]  ";
            //sqlCreateView += " ( ";
            //sqlCreateView += " [arid] ASC, ";
            //sqlCreateView += " [linearid] ASC ";
            //sqlCreateView += " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ";

            //SQLCreateViews[3] = sqlCreateView;


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
            SQLPostProcessOutputToSingleTable += " [conCtyFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyFp00] [varchar](3) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [stateFp00] [varchar](2) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tractCe00] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blkGrpCe00] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blockCe00] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [suffix1Ce] [varchar](1) NOT NULL DEFAULT '', ";
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
            SQLPostProcessOutputToSingleTable += " [conCtyFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [conCtyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [subMcdName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubFp00] [varchar](5) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [couSubName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyFp00] [varchar](3) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00] [varchar](100) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_Soundex] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [countyName00_SoundexDM] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [stateFp00] [varchar](2) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [tractCe00] [varchar](6) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blkGrpCe00] [varchar](1) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [blockCe00] [varchar](4) NOT NULL DEFAULT '', ";
            SQLPostProcessOutputToSingleTable += " [suffix1Ce] [varchar](1) NOT NULL DEFAULT '', ";
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
            SQLPostProcessOutputToSingleTable += " ,[conCtyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdFp00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[couSubFp00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[countyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[stateFp00]";
            SQLPostProcessOutputToSingleTable += " ,[tractCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blkGrpCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blockCe00]";
            SQLPostProcessOutputToSingleTable += " ,[suffix1Ce]";
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
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.stateFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tractCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blkGrpCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blockCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.suffix1Ce, '' ),  ";
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

            if (shouldDoOnlyStreets)
            {
                sqlCreateView += " WHERE      ";
                sqlCreateView += "  (dbo." + StateName + "_edges.roadFlg = 'Y') ";
            }

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
            SQLPostProcessOutputToSingleTable += " ,[conCtyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[conCtyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdFp00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[subMcdName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[couSubFp00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[couSubName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[countyFp00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_Soundex]";
            SQLPostProcessOutputToSingleTable += " ,[countyName00_SoundexDM]";
            SQLPostProcessOutputToSingleTable += " ,[stateFp00]";
            SQLPostProcessOutputToSingleTable += " ,[tractCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blkGrpCe00]";
            SQLPostProcessOutputToSingleTable += " ,[blockCe00]";
            SQLPostProcessOutputToSingleTable += " ,[suffix1Ce]";
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
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.conCtyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.subMcdName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.couSubName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_Soundex, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.countyName00_SoundexDM, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.stateFp00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.tractCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blkGrpCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.blockCe00, '' ),  ";
            SQLPostProcessOutputToSingleTable += " ISNULL(  dbo." + StateName + "_faces.suffix1Ce, '' ),  ";
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

            if (shouldDoOnlyStreets)
            {
                sqlCreateView += " WHERE      ";
                sqlCreateView += "  (dbo." + StateName + "_edges.roadFlg = 'Y') ";
            }

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



            //// all columns indexed for per-query relaxation
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K56_K33_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[countyName00] ASC, 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K53_K20_K34_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[couSubName00_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K49_K20_K34_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[subMcdName00_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K48_K33_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[subMcdName00] ASC, 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K48_K26_K20_K33_K37_K30_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_38_39_40_41_] ON [dbo].[" + StateName + "_Left]  ( 	[subMcdName00] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[sufTypAbrv] ASC, 	[preDirAbrv] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K44_K33_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[conCtyName00] ASC, 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K41_K20_K34_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_42_43_] ON [dbo].[" + StateName + "_Left]  ( 	[placeName00_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K40_K26_K20_K33_K36_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_34_35_37_38_39_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[placeName00] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[sufDirAbrv] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K26_K20_K57_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[countyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K20_K45_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[conCtyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K20_K41_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_42_43_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[placeName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K20_K37_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[sufTypAbrv] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K20_K30_K26_K57_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_33_35_36_37_38_39_40_41_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[preDirAbrv] ASC, 	[zip] ASC, 	[countyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K20_K26_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[zip] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K34_K20_K26_K45_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[zip] ASC, 	[conCtyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K33_K26_K20_K52_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left] (	[name] ASC,	[zip] ASC,	[fromHN_Number_Even] ASC,	[couSubName00] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K33_K26_K20_K37_K30_K56_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_38_39_40_41_] ON [dbo].[" + StateName + "_Left]  ( 	[name] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[sufTypAbrv] ASC, 	[preDirAbrv] ASC, 	[countyName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K33_K26_K20_K30_K40_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_37_38_39_41_42_43_] ON [dbo].[" + StateName + "_Left]  ( 	[name] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[preDirAbrv] ASC, 	[placeName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K33_K20_K44_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[conCtyName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K33_K20_K40_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_41_42_43_] ON [dbo].[" + StateName + "_Left]  ( 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[placeName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K30_K34_K20_K37_K49_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_33_35_36_38_39_40_41_] ON [dbo].[" + StateName + "_Left]  ( 	[preDirAbrv] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[sufTypAbrv] ASC, 	[subMcdName00_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K30_K34_K20_K26_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_33_35_36_37_38_39_40_41_] ON [dbo].[" + StateName + "_Left]  ( 	[preDirAbrv] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[zip] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K26_K34_K20_K53_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[zip] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[couSubName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K26_K34_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_43_] ON [dbo].[" + StateName + "_Left]  ( 	[zip] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K26_K20_K34_K45_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[conCtyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K26_K20_K33_K37_K30_K40_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_38_39_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[sufTypAbrv] ASC, 	[preDirAbrv] ASC, 	[placeName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K57_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[countyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K53_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[couSubName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K34_K41_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_42_43_] ON [dbo].[" + StateName + "_Left]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[placeName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K33_K56_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[countyName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_K20_K33_K48_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Left]  ( 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[subMcdName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [lFromAdd], [lToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";

            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K56_K33_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[countyName00] ASC, 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K53_K20_K34_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[couSubName00_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K49_K20_K34_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[subMcdName00_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K48_K33_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[subMcdName00] ASC, 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K48_K26_K20_K33_K37_K30_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_38_39_40_41_] ON [dbo].[" + StateName + "_Right]  ( 	[subMcdName00] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[sufTypAbrv] ASC, 	[preDirAbrv] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K44_K33_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[conCtyName00] ASC, 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K41_K20_K34_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_42_43_] ON [dbo].[" + StateName + "_Right]  ( 	[placeName00_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K40_K26_K20_K33_K36_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_34_35_37_38_39_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[placeName00] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[sufDirAbrv] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K26_K20_K57_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[countyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K20_K45_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[conCtyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K20_K41_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_42_43_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[placeName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K20_K37_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[sufTypAbrv] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K20_K30_K26_K57_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_33_35_36_37_38_39_40_41_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[preDirAbrv] ASC, 	[zip] ASC, 	[countyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K20_K26_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[zip] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K34_K20_K26_K45_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[zip] ASC, 	[conCtyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K33_K26_K20_K52_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right] (	[name] ASC,	[zip] ASC,	[fromHN_Number_Even] ASC,	[couSubName00] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K33_K26_K20_K37_K30_K56_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_38_39_40_41_] ON [dbo].[" + StateName + "_Right]  ( 	[name] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[sufTypAbrv] ASC, 	[preDirAbrv] ASC, 	[countyName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K33_K26_K20_K30_K40_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_37_38_39_41_42_43_] ON [dbo].[" + StateName + "_Right]  ( 	[name] ASC, 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[preDirAbrv] ASC, 	[placeName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K33_K20_K44_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[conCtyName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K33_K20_K40_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_41_42_43_] ON [dbo].[" + StateName + "_Right]  ( 	[name] ASC, 	[fromHN_Number_Even] ASC, 	[placeName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K30_K34_K20_K37_K49_K26_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_33_35_36_38_39_40_41_] ON [dbo].[" + StateName + "_Right]  ( 	[preDirAbrv] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[sufTypAbrv] ASC, 	[subMcdName00_Soundex] ASC, 	[zip] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K30_K34_K20_K26_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_33_35_36_37_38_39_40_41_] ON [dbo].[" + StateName + "_Right]  ( 	[preDirAbrv] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[zip] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K26_K34_K20_K53_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[zip] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[couSubName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K26_K34_K20_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_43_] ON [dbo].[" + StateName + "_Right]  ( 	[zip] ASC, 	[name_Soundex] ASC, 	[fromHN_Number_Even] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K26_K20_K34_K45_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[conCtyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K26_K20_K33_K37_K30_K40_K19_K23_1_2_3_4_5_7_11_18_21_22_25_27_29_31_32_34_35_36_38_39_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[zip] ASC, 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[sufTypAbrv] ASC, 	[preDirAbrv] ASC, 	[placeName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [plus4], [fullName], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufQualAbr], [placeFp00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K57_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[countyName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K53_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[couSubName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K49_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[subMcdName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K34_K41_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_33_35_36_37_38_39_40_42_43_] ON [dbo].[" + StateName + "_Right]  ( 	[fromHN_Number_Even] ASC, 	[name_Soundex] ASC, 	[placeName00_Soundex] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K33_K56_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[countyName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";
            //SQLPostInsertSingleTableUpdate += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_K20_K33_K48_K19_K23_1_2_3_4_5_7_11_18_21_22_25_26_27_29_30_31_32_34_35_36_37_38_39_40_41_42_] ON [dbo].[" + StateName + "_Right]  ( 	[fromHN_Number_Even] ASC, 	[name] ASC, 	[subMcdName00] ASC, 	[fromHN_Number] ASC, 	[toHN_Number] ASC ) INCLUDE ( [tlid], [fromLon], [fromLat], [toLon], [toLat], [rFromAdd], [rToAdd], [fromHN], [fromHN_Unit], [toHN], [toHN_Unit], [zip], [plus4], [fullName], [preDirAbrv], [preTypAbrv], [preQualAbr], [name_Soundex], [name_SoundexDM], [sufDirAbrv], [sufTypAbrv], [sufQualAbr], [placeFp00], [placeName00], [placeName00_Soundex], [placeName00_SoundexDM], [conCtyFp00], [conCtyName00], [conCtyName00_Soundex], [conCtyName00_SoundexDM], [subMcdFp00], [subMcdName00_Soundex], [subMcdName00_SoundexDM], [couSubFp00], [couSubName00], [couSubName00_Soundex], [couSubName00_SoundexDM], [countyFp00], [countyName00], [countyName00_Soundex], [countyName00_SoundexDM], [stateFp00], [tractCe00], [blkGrpCe00], [blockCe00], [suffix1Ce]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]; ";

            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_56_33_20_26_19] ON [dbo].[" + StateName + "_Left]([countyName00], [name], [fromHN_Number_Even], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_52_33_26_20] ON [dbo].[" + StateName + "_Left]([couSubName00], [name], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_44_33_20_37_26_19] ON [dbo].[" + StateName + "_Left]([conCtyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_40_33] ON [dbo].[" + StateName + "_Left]([placeName00], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_56_33_20_26_19_23] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [countyName00], [name], [fromHN_Number_Even], [zip], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_56_33] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [countyName00], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_48_26_20] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [subMcdName00], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_44_33] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [conCtyName00], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_40_26_20_33_19_23] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [placeName00], [zip], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_33_26_20_52_19_23] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [name], [zip], [fromHN_Number_Even], [couSubName00], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_37_33_26] ON [dbo].[" + StateName + "_Left]([sufTypAbrv], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_56_20_26_19_23] ON [dbo].[" + StateName + "_Left]([name], [countyName00], [fromHN_Number_Even], [zip], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_56_20_37] ON [dbo].[" + StateName + "_Left]([name], [countyName00], [fromHN_Number_Even], [sufTypAbrv]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_48_26_20_37_19] ON [dbo].[" + StateName + "_Left]([name], [subMcdName00], [zip], [fromHN_Number_Even], [sufTypAbrv], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_48_26_20_19_23] ON [dbo].[" + StateName + "_Left]([name], [subMcdName00], [zip], [fromHN_Number_Even], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_44_20_26_19_23] ON [dbo].[" + StateName + "_Left]([name], [conCtyName00], [fromHN_Number_Even], [zip], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_44_20_37_26_19] ON [dbo].[" + StateName + "_Left]([name], [conCtyName00], [fromHN_Number_Even], [sufTypAbrv], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_40_26_20_19_23] ON [dbo].[" + StateName + "_Left]([name], [placeName00], [zip], [fromHN_Number_Even], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_40_26] ON [dbo].[" + StateName + "_Left]([name], [placeName00], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_33_26_20_37_52_19_23] ON [dbo].[" + StateName + "_Left]([name], [zip], [fromHN_Number_Even], [sufTypAbrv], [couSubName00], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_26_56_33_20] ON [dbo].[" + StateName + "_Left]([zip], [countyName00], [name], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_26_56_33_20_37_19_23] ON [dbo].[" + StateName + "_Left]([zip], [countyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_26_48_20_33_37_19_23] ON [dbo].[" + StateName + "_Left]([zip], [subMcdName00], [fromHN_Number_Even], [name], [sufTypAbrv], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_26_44_33_20] ON [dbo].[" + StateName + "_Left]([zip], [conCtyName00], [name], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_26_33_20_52_19_23] ON [dbo].[" + StateName + "_Left]([zip], [name], [fromHN_Number_Even], [couSubName00], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_56_33_20_37_26] ON [dbo].[" + StateName + "_Left]([toHN_Number], [countyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_56_33_20_26] ON [dbo].[" + StateName + "_Left]([toHN_Number], [countyName00], [name], [fromHN_Number_Even], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_48_26_20_33_37] ON [dbo].[" + StateName + "_Left]([toHN_Number], [subMcdName00], [zip], [fromHN_Number_Even], [name], [sufTypAbrv]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_48_26_20_33_37_19] ON [dbo].[" + StateName + "_Left]([toHN_Number], [subMcdName00], [zip], [fromHN_Number_Even], [name], [sufTypAbrv], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_44_33_20_37_26] ON [dbo].[" + StateName + "_Left]([toHN_Number], [conCtyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_44_33_20_37_26_19] ON [dbo].[" + StateName + "_Left]([toHN_Number], [conCtyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_44_33_20_26] ON [dbo].[" + StateName + "_Left]([toHN_Number], [conCtyName00], [name], [fromHN_Number_Even], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_33_26_20_52] ON [dbo].[" + StateName + "_Left]([toHN_Number], [name], [zip], [fromHN_Number_Even], [couSubName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_33_26_20_37_52] ON [dbo].[" + StateName + "_Left]([toHN_Number], [name], [zip], [fromHN_Number_Even], [sufTypAbrv], [couSubName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_19_37_33_26_40] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number], [sufTypAbrv], [name], [zip], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_19_33_40] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number], [name], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_19_33_26_40_20] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number], [name], [zip], [placeName00], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_23_19_33_26_40] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number], [name], [zip], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_20_56] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [countyName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_20_48] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [subMcdName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_20_48_26_33_19_23] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [subMcdName00], [zip], [name], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_20_44] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [conCtyName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_20_40] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_40_26_20_33] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [placeName00], [zip], [fromHN_Number_Even], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_33_20] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [name], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_56_33_26_20] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [countyName00], [name], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_56_33_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [countyName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_48_37_33_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [subMcdName00], [sufTypAbrv], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_48_33_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [subMcdName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_44_37_33_26_20] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [conCtyName00], [sufTypAbrv], [name], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_44_33_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [conCtyName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_37_56_33_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [sufTypAbrv], [countyName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_37_33_26_52] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [sufTypAbrv], [name], [zip], [couSubName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_44_37_33_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [conCtyName00], [sufTypAbrv], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Left_19_23_33_26_52] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [name], [zip], [couSubName00]) ; ";    

            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_56_33_20_26_19] ON [dbo].[" + StateName + "_Right]([countyName00], [name], [fromHN_Number_Even], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_52_33_26_20] ON [dbo].[" + StateName + "_Right]([couSubName00], [name], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_44_33_20_37_26_19] ON [dbo].[" + StateName + "_Right]([conCtyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_40_33] ON [dbo].[" + StateName + "_Right]([placeName00], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_56_33_20_26_19_23] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [countyName00], [name], [fromHN_Number_Even], [zip], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_56_33] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [countyName00], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_48_26_20] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [subMcdName00], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_44_33] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [conCtyName00], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_40_26_20_33_19_23] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [placeName00], [zip], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_33_26_20_52_19_23] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [name], [zip], [fromHN_Number_Even], [couSubName00], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_37_33_26] ON [dbo].[" + StateName + "_Right]([sufTypAbrv], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_56_20_26_19_23] ON [dbo].[" + StateName + "_Right]([name], [countyName00], [fromHN_Number_Even], [zip], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_56_20_37] ON [dbo].[" + StateName + "_Right]([name], [countyName00], [fromHN_Number_Even], [sufTypAbrv]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_48_26_20_37_19] ON [dbo].[" + StateName + "_Right]([name], [subMcdName00], [zip], [fromHN_Number_Even], [sufTypAbrv], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_48_26_20_19_23] ON [dbo].[" + StateName + "_Right]([name], [subMcdName00], [zip], [fromHN_Number_Even], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_44_20_26_19_23] ON [dbo].[" + StateName + "_Right]([name], [conCtyName00], [fromHN_Number_Even], [zip], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_44_20_37_26_19] ON [dbo].[" + StateName + "_Right]([name], [conCtyName00], [fromHN_Number_Even], [sufTypAbrv], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_40_26_20_19_23] ON [dbo].[" + StateName + "_Right]([name], [placeName00], [zip], [fromHN_Number_Even], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_40_26] ON [dbo].[" + StateName + "_Right]([name], [placeName00], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_33_26_20_37_52_19_23] ON [dbo].[" + StateName + "_Right]([name], [zip], [fromHN_Number_Even], [sufTypAbrv], [couSubName00], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_26_56_33_20] ON [dbo].[" + StateName + "_Right]([zip], [countyName00], [name], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_26_56_33_20_37_19_23] ON [dbo].[" + StateName + "_Right]([zip], [countyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_26_48_20_33_37_19_23] ON [dbo].[" + StateName + "_Right]([zip], [subMcdName00], [fromHN_Number_Even], [name], [sufTypAbrv], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_26_44_33_20] ON [dbo].[" + StateName + "_Right]([zip], [conCtyName00], [name], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_26_33_20_52_19_23] ON [dbo].[" + StateName + "_Right]([zip], [name], [fromHN_Number_Even], [couSubName00], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_56_33_20_37_26] ON [dbo].[" + StateName + "_Right]([toHN_Number], [countyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_56_33_20_26] ON [dbo].[" + StateName + "_Right]([toHN_Number], [countyName00], [name], [fromHN_Number_Even], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_48_26_20_33_37] ON [dbo].[" + StateName + "_Right]([toHN_Number], [subMcdName00], [zip], [fromHN_Number_Even], [name], [sufTypAbrv]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_48_26_20_33_37_19] ON [dbo].[" + StateName + "_Right]([toHN_Number], [subMcdName00], [zip], [fromHN_Number_Even], [name], [sufTypAbrv], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_44_33_20_37_26] ON [dbo].[" + StateName + "_Right]([toHN_Number], [conCtyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_44_33_20_37_26_19] ON [dbo].[" + StateName + "_Right]([toHN_Number], [conCtyName00], [name], [fromHN_Number_Even], [sufTypAbrv], [zip], [fromHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_44_33_20_26] ON [dbo].[" + StateName + "_Right]([toHN_Number], [conCtyName00], [name], [fromHN_Number_Even], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_33_26_20_52] ON [dbo].[" + StateName + "_Right]([toHN_Number], [name], [zip], [fromHN_Number_Even], [couSubName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_33_26_20_37_52] ON [dbo].[" + StateName + "_Right]([toHN_Number], [name], [zip], [fromHN_Number_Even], [sufTypAbrv], [couSubName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_19_37_33_26_40] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number], [sufTypAbrv], [name], [zip], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_19_33_40] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number], [name], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_19_33_26_40_20] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number], [name], [zip], [placeName00], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_23_19_33_26_40] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number], [name], [zip], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_20_56] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [countyName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_20_48] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [subMcdName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_20_48_26_33_19_23] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [subMcdName00], [zip], [name], [fromHN_Number], [toHN_Number]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_20_44] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [conCtyName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_20_40] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [placeName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_40_26_20_33] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [placeName00], [zip], [fromHN_Number_Even], [name]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_33_20] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [name], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_56_33_26_20] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [countyName00], [name], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_56_33_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [countyName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_48_37_33_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [subMcdName00], [sufTypAbrv], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_48_33_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [subMcdName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_44_37_33_26_20] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [conCtyName00], [sufTypAbrv], [name], [zip], [fromHN_Number_Even]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_44_33_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [conCtyName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_37_56_33_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [sufTypAbrv], [countyName00], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_37_33_26_52] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [sufTypAbrv], [name], [zip], [couSubName00]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_44_37_33_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [conCtyName00], [sufTypAbrv], [name], [zip]) ; ";
            //SQLPostInsertSingleTableUpdate += " CREATE STATISTICS [_dta_stat_" + StateName + "_Right_19_23_33_26_52] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [name], [zip], [couSubName00]) ; ";    


            // left side statistics
            string SQLPostInsertSingleTableUpdateStatistics = "";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_26_20_33_19_23_44_48_52_56] ON [dbo].[" + StateName + "_Left]([zip], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [conCtyName00], [subMcdName00], [couSubName00], [countyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_34_20_19_23_26_44_48_52_56] ON [dbo].[" + StateName + "_Left]([name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [zip], [conCtyName00], [subMcdName00], [couSubName00], [countyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_34_20_26_40_19_23] ON [dbo].[" + StateName + "_Left]([name_Soundex], [fromHN_Number_Even], [zip], [placeName00], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_20_34_26_40] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [zip], [placeName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_40_26_19_34] ON [dbo].[" + StateName + "_Left]([toHN_Number], [placeName00], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_48_44_52_56_26_19_34] ON [dbo].[" + StateName + "_Left]([toHN_Number], [subMcdName00], [conCtyName00], [couSubName00], [countyName00], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_40_20_26] ON [dbo].[" + StateName + "_Left]([placeName00], [fromHN_Number_Even], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_52_20_33_19_23_26_44] ON [dbo].[" + StateName + "_Left]([couSubName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_56_20_33_19_23_26_44_48] ON [dbo].[" + StateName + "_Left]([countyName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName00], [subMcdName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_19_23_33_40_26] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number], [toHN_Number], [name], [placeName00], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_44_20_33_19_23] ON [dbo].[" + StateName + "_Left]([conCtyName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_48_19_23_52_44_56_33_26] ON [dbo].[" + StateName + "_Left]([subMcdName00], [fromHN_Number], [toHN_Number], [couSubName00], [conCtyName00], [countyName00], [name], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_48_20_33_19_23_26] ON [dbo].[" + StateName + "_Left]([subMcdName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_20_33_26_40_19] ON [dbo].[" + StateName + "_Left]([fromHN_Number_Even], [name], [zip], [placeName00], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_20_26_33_40_19_67] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [zip], [name], [placeName00], [fromHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_20_33_26_40_19] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [name], [zip], [placeName00], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_20_33_23] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [fromHN_Number_Even], [name], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_20_34_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [fromHN_Number_Even], [name_Soundex], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_23_33_40_26] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [toHN_Number], [name], [placeName00], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_56_34_20_19_23_67_26_44_48] ON [dbo].[" + StateName + "_Left]([countyName00], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName00], [subMcdName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_52_34_20_19_23_67_26_44] ON [dbo].[" + StateName + "_Left]([couSubName00], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_48_34_20_19_23_67_26] ON [dbo].[" + StateName + "_Left]([subMcdName00], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_34_20_26_40_19] ON [dbo].[" + StateName + "_Left]([UniqueId], [name_Soundex], [fromHN_Number_Even], [zip], [placeName00], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_34_20_19] ON [dbo].[" + StateName + "_Left]([UniqueId], [name_Soundex], [fromHN_Number_Even], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_26_44_48_52] ON [dbo].[" + StateName + "_Left]([UniqueId], [zip], [conCtyName00], [subMcdName00], [couSubName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_34_20_26_40_23_67] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [zip], [placeName00], [toHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_34_20_23_67_26_44_48_52_56] ON [dbo].[" + StateName + "_Left]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [toHN_Number], [UniqueId], [zip], [conCtyName00], [subMcdName00], [couSubName00], [countyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_49_20_34_19_23_26_41] ON [dbo].[" + StateName + "_Left]([subMcdName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_45_20_34_19_23_26] ON [dbo].[" + StateName + "_Left]([conCtyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_57_20_34_19_23_26_41_45_49] ON [dbo].[" + StateName + "_Left]([countyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_53_20_34_19_23_26_41_45] ON [dbo].[" + StateName + "_Left]([couSubName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_41_53_19_23_26_57_45_49_34] ON [dbo].[" + StateName + "_Left]([placeName00_Soundex], [couSubName00_Soundex], [fromHN_Number], [toHN_Number], [zip], [countyName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [name_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_23_19_26_34_53_57_41_45_20] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number], [zip], [name_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [placeName00_Soundex], [conCtyName00_Soundex], [fromHN_Number_Even]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_41_20_34_19_23] ON [dbo].[" + StateName + "_Left]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_26_20_34_19_23_41_45_49_53_57] ON [dbo].[" + StateName + "_Left]([zip], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_215671816_67_20_34_19_23_26_41_45_49_53] ON [dbo].[" + StateName + "_Left]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_215671816_41_20_34_19_23_26_45_49_53_57_67] ON [dbo].[" + StateName + "_Left]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_231671873_23_20_34_19_26_41_45_49_53_57_67] ON [dbo].[" + StateName + "_Left]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";

            // right side statistics
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_26_20_33_19_23_44_48_52_56] ON [dbo].[" + StateName + "_Right]([zip], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [conCtyName00], [subMcdName00], [couSubName00], [countyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_34_20_19_23_26_44_48_52_56] ON [dbo].[" + StateName + "_Right]([name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [zip], [conCtyName00], [subMcdName00], [couSubName00], [countyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_34_20_26_40_19_23] ON [dbo].[" + StateName + "_Right]([name_Soundex], [fromHN_Number_Even], [zip], [placeName00], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_20_34_26_40] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [zip], [placeName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_40_26_19_34] ON [dbo].[" + StateName + "_Right]([toHN_Number], [placeName00], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_48_44_52_56_26_19_34] ON [dbo].[" + StateName + "_Right]([toHN_Number], [subMcdName00], [conCtyName00], [couSubName00], [countyName00], [zip], [fromHN_Number], [name_Soundex]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_40_20_26] ON [dbo].[" + StateName + "_Right]([placeName00], [fromHN_Number_Even], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_52_20_33_19_23_26_44] ON [dbo].[" + StateName + "_Right]([couSubName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_56_20_33_19_23_26_44_48] ON [dbo].[" + StateName + "_Right]([countyName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip], [conCtyName00], [subMcdName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_19_23_33_40_26] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number], [toHN_Number], [name], [placeName00], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_44_20_33_19_23] ON [dbo].[" + StateName + "_Right]([conCtyName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_48_19_23_52_44_56_33_26] ON [dbo].[" + StateName + "_Right]([subMcdName00], [fromHN_Number], [toHN_Number], [couSubName00], [conCtyName00], [countyName00], [name], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_48_20_33_19_23_26] ON [dbo].[" + StateName + "_Right]([subMcdName00], [fromHN_Number_Even], [name], [fromHN_Number], [toHN_Number], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_20_33_26_40_19] ON [dbo].[" + StateName + "_Right]([fromHN_Number_Even], [name], [zip], [placeName00], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_20_26_33_40_19_67] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [zip], [name], [placeName00], [fromHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_23_20_33_26_40_19] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [name], [zip], [placeName00], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_20_33_23] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [fromHN_Number_Even], [name], [toHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_20_34_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [fromHN_Number_Even], [name_Soundex], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_23_33_40_26] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [toHN_Number], [name], [placeName00], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_56_34_20_19_23_67_26_44_48] ON [dbo].[" + StateName + "_Right]([countyName00], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName00], [subMcdName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_52_34_20_19_23_67_26_44] ON [dbo].[" + StateName + "_Right]([couSubName00], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip], [conCtyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_48_34_20_19_23_67_26] ON [dbo].[" + StateName + "_Right]([subMcdName00], [name_Soundex], [fromHN_Number_Even], [fromHN_Number], [toHN_Number], [UniqueId], [zip]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_34_20_26_40_19] ON [dbo].[" + StateName + "_Right]([UniqueId], [name_Soundex], [fromHN_Number_Even], [zip], [placeName00], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_34_20_19] ON [dbo].[" + StateName + "_Right]([UniqueId], [name_Soundex], [fromHN_Number_Even], [fromHN_Number]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_67_26_44_48_52] ON [dbo].[" + StateName + "_Right]([UniqueId], [zip], [conCtyName00], [subMcdName00], [couSubName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_34_20_26_40_23_67] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [zip], [placeName00], [toHN_Number], [UniqueId]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += "  CREATE STATISTICS [_dta_stat_649821427_19_34_20_23_67_26_44_48_52_56] ON [dbo].[" + StateName + "_Right]([fromHN_Number], [name_Soundex], [fromHN_Number_Even], [toHN_Number], [UniqueId], [zip], [conCtyName00], [subMcdName00], [couSubName00], [countyName00]) ; ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_49_20_34_19_23_26_41] ON [dbo].[" + StateName + "_Right]([subMcdName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_45_20_34_19_23_26] ON [dbo].[" + StateName + "_Right]([conCtyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_57_20_34_19_23_26_41_45_49] ON [dbo].[" + StateName + "_Right]([countyName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_53_20_34_19_23_26_41_45] ON [dbo].[" + StateName + "_Right]([couSubName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_41_53_19_23_26_57_45_49_34] ON [dbo].[" + StateName + "_Right]([placeName00_Soundex], [couSubName00_Soundex], [fromHN_Number], [toHN_Number], [zip], [countyName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [name_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_23_19_26_34_53_57_41_45_20] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number], [zip], [name_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [placeName00_Soundex], [conCtyName00_Soundex], [fromHN_Number_Even]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_41_20_34_19_23] ON [dbo].[" + StateName + "_Right]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_866102126_26_20_34_19_23_41_45_49_53_57] ON [dbo].[" + StateName + "_Right]([zip], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_215671816_67_20_34_19_23_26_41_45_49_53] ON [dbo].[" + StateName + "_Right]([UniqueId], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_215671816_41_20_34_19_23_26_45_49_53_57_67] ON [dbo].[" + StateName + "_Right]([placeName00_Soundex], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [toHN_Number], [zip], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";
            SQLPostInsertSingleTableUpdateStatistics += " CREATE STATISTICS [_dta_stat_231671873_23_20_34_19_26_41_45_49_53_57_67] ON [dbo].[" + StateName + "_Right]([toHN_Number], [fromHN_Number_Even], [name_Soundex], [fromHN_Number], [zip], [placeName00_Soundex], [conCtyName00_Soundex], [subMcdName00_Soundex], [couSubName00_Soundex], [countyName00_Soundex], [UniqueId]); ";



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
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name-zip] ON [dbo].[" + StateName + "_Left] ([name_Soundex],[zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidL],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lFromAdd_Number_Even],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name-zip] ON [dbo].[" + StateName + "_Right] ([name_Soundex],[zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidR],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rFromAdd_Number_Even],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            // name only
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Left] ([name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[zip],[tfidL],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lFromAdd_Number_Even],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Right] ([name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[zip],[tfidR],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rFromAdd_Number_Even],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            // zip only
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_zip] ON [dbo].[" + StateName + "_Left] ([zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidL],[lFromAdd],[lFromAdd_Number],[lFromAdd_Unit],[lFromAdd_Number_Even],[lToAdd],[lToAdd_Number],[lToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";
            SQLPostInsertSingleTableUpdateIndexesNoNumbers += " CREATE NONCLUSTERED INDEX [idx_zip] ON [dbo].[" + StateName + "_Right] ([zip]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[tfidR],[rFromAdd],[rFromAdd_Number],[rFromAdd_Unit],[rFromAdd_Number_Even],[rToAdd],[rToAdd_Number],[rToAdd_Unit],[edges_fullname],[edges_zip],[arid],[side],[fromHN],[fromHN_Number],[fromHN_Number_Even],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Number_Even],[toHN_Unit],[plus4],[lineArid],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce],[tfid],[shapeGeog],[shapeGeom],[UniqueId]); ";



            // these indexes are queries that look for name + (zip or city or conCity or mcd or countySub or county) all at once so only one covering index is needed
            string SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether = "";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Left_even-Name-From-To-Zip-Place-Con-Mcd-Cousub-County] ON [dbo].[" + StateName + "_Left] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesTogether += " CREATE NONCLUSTERED INDEX [_dta_index_" + StateName + "_Right_even-Name-From-To-Zip-Place-Con-Mcd-Cousub-County] ON [dbo].[" + StateName + "_Right] (	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[placeName00_Soundex] ASC,	[conCtyName00_Soundex] ASC,	[subMcdName00_Soundex] ASC,	[couSubName00_Soundex] ASC,	[countyName00_Soundex] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";


            // these indexes are queries that look for name + (zip or city) or (zip or conCity or mcd or countySub or county) seperately so a whole bunchh of indexes are needed
            string SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether = "";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";

            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_zip_place_from_to_even] ON [dbo].[" + StateName + "_Left] (	[name_Soundex] ASC,	[zip] ASC,	[placeName00] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[fromHN_Number_Even] ASC)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_place_even_nameSdx_zip_from_to] ON [dbo].[" + StateName + "_Left] (	[placeName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[zip] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_zip_even_nameSdx_from_to_conCity_mcd_couSub_county] ON [dbo].[" + StateName + "_Left] (	[zip] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[conCtyName00] ASC,	[subMcdName00] ASC,	[couSubName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_mcd_even_nameSdx_from_to_zip_concity_countySub_county] ON [dbo].[" + StateName + "_Left] (	[subMcdName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName00] ASC,	[couSubName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_couSub_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Left] (	[couSubName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName00] ASC,	[subMcdName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_concity_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Left] (	[conCtyName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[subMcdName00] ASC,	[couSubName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_county_even_nameSdx_from_to_zip_conCity_mcd_couSub] ON [dbo].[" + StateName + "_Left] (	[countyName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName00] ASC,	[subMcdName00] ASC,	[couSubName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_even_from_to_zip] ON [dbo].[" + StateName + "_Left] (	[name_Soundex] ASC,	[fromHN_Number_Even] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[UniqueId] ASC)INCLUDE ( [placeName00]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";

            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_zip_place_from_to_even] ON [dbo].[" + StateName + "_Right] (	[name_Soundex] ASC,	[zip] ASC,	[placeName00] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[fromHN_Number_Even] ASC)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_place_even_nameSdx_zip_from_to] ON [dbo].[" + StateName + "_Right] (	[placeName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[zip] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_zip_even_nameSdx_from_to_conCity_mcd_couSub_county] ON [dbo].[" + StateName + "_Right] (	[zip] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[conCtyName00] ASC,	[subMcdName00] ASC,	[couSubName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_mcd_even_nameSdx_from_to_zip_concity_countySub_county] ON [dbo].[" + StateName + "_Right] (	[subMcdName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName00] ASC,	[couSubName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_couSub_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Right] (	[couSubName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName00] ASC,	[subMcdName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_concity_even_nameSdx_from_to_zip_conCity_mcd_county] ON [dbo].[" + StateName + "_Right] (	[conCtyName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[subMcdName00] ASC,	[couSubName00] ASC,	[countyName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_county_even_nameSdx_from_to_zip_conCity_mcd_couSub] ON [dbo].[" + StateName + "_Right] (	[countyName00] ASC,	[fromHN_Number_Even] ASC,	[name_Soundex] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[conCtyName00] ASC,	[subMcdName00] ASC,	[couSubName00] ASC)INCLUDE ( [tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Unit],[toHN],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";
            SQLPostInsertSingleTableUpdateIndexesAllPlacesAndThenAllOthersTogether += "  CREATE NONCLUSTERED INDEX [idx_name_even_from_to_zip] ON [dbo].[" + StateName + "_Right] (	[name_Soundex] ASC,	[fromHN_Number_Even] ASC,	[fromHN_Number] ASC,	[toHN_Number] ASC,	[zip] ASC,	[UniqueId] ASC)INCLUDE ( [placeName00]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ; ";




            // these indexes are queries that look for exact and soundex versions seperately
            string SQLPostInsertSingleTableUpdateIndexesExactAndSoundex = "";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " ALTER TABLE [dbo].[" + StateName + "_Left] ADD CONSTRAINT [PK_" + StateName + "_Left_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " ALTER TABLE [dbo].[" + StateName + "_Right] ADD CONSTRAINT [PK_" + StateName + "_Right_UniqueId] PRIMARY KEY CLUSTERED (UniqueId); ";

            // Left side exact

            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name_placename] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[zip],[name],[placeName00])INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]) ; ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name_placename] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[name],[placeName00]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[zip],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";

            // Right side exact
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name_placename] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[zip],[name],[placeName00]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name_placename] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[name],[placeName00]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_zip_name] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[zip],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_name] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[name]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name_Soundex],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";

            // Left side soundex
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_nameSdx] ON [dbo].[" + StateName + "_Left] ([fromHN_Number_Even],[name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[lFromAdd],[lToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";

            // Right side soundex
            SQLPostInsertSingleTableUpdateIndexesExactAndSoundex += " CREATE NONCLUSTERED INDEX [idx_nameSdx] ON [dbo].[" + StateName + "_Right] ([fromHN_Number_Even],[name_Soundex]) INCLUDE ([tlid],[fromLon],[fromLat],[toLon],[toLat],[rFromAdd],[rToAdd],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[zip],[plus4],[fullName],[preDirAbrv],[preTypAbrv],[preQualAbr],[name],[name_SoundexDM],[sufDirAbrv],[sufTypAbrv],[sufQualAbr],[placeFp00],[placeName00],[placeName00_Soundex],[placeName00_SoundexDM],[conCtyFp00],[conCtyName00],[conCtyName00_Soundex],[conCtyName00_SoundexDM],[subMcdFp00],[subMcdName00],[subMcdName00_Soundex],[subMcdName00_SoundexDM],[couSubFp00],[couSubName00],[couSubName00_Soundex],[couSubName00_SoundexDM],[countyFp00],[countyName00],[countyName00_Soundex],[countyName00_SoundexDM],[stateFp00],[tractCe00],[blkGrpCe00],[blockCe00],[suffix1Ce], [shapeGeog], [shapeGeom]); ";



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
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon  , fromLat  , toLon  , toLat  , fullName  , preDirAbrv  , preTypAbrv  , preQualAbr  , name , name_Soundex  , name_SoundexDM  , sufDirAbrv  , sufTypAbrv  , sufQualAbr  ,  shapeGeog  ,  shapeGeom  , lFromAdd   , lToAdd   , fromHn as lFromHn   , fromHN_Number as lfromHN_Number  , fromHN_Unit as lfromHN_Unit  , toHn as lToHn   , toHN_Number as ltoHN_Number  , toHN_Unit as ltoHN_Unit  , zip as lZip   , plus4 as lZipPlus4   , placeFp00 as lplaceFp00   , placeName00 as lplaceName00  , placeName00_Soundex as lplaceName00_Soundex   , placeName00_SoundexDM as lplaceName00_SoundexDM  , conCtyFp00 as lconCtyFp00   , conCtyName00 as lconCtyName00   , conCtyName00_Soundex as lconCtyName00_Soundex   , conCtyName00_SoundexDM as lconCtyName00_SoundexDM  , subMcdFp00 as lsubMcdFp00   , subMcdName00 as lsubMcdName00  , subMcdName00_Soundex as lsubMcdName00_Soundex   , subMcdName00_SoundexDM as lsubMcdName00_SoundexDM  , couSubFp00 as lcouSubFp00   , couSubName00 as lcouSubName00  , couSubName00_Soundex as lcouSubName00_Soundex   , couSubName00_SoundexDM as lcouSubName00_SoundexDM  , countyFp00 as lcountyFp00   , countyName00 as lcountyName00  , countyName00_Soundex as lcountyName00_Soundex   , countyName00_SoundexDM as lcountyName00_SoundexDM  , stateFp00 as lstateFp00   , tractCe00 as ltractCe00   , blkGrpCe00 as lblkGrpCe00   , blockCe00 as lblockCe00   , suffix1Ce as lsuffix1Ce ";
            SQLPostInsertSingleTableUpdateStoredProcedures += "  , '' as rFromAdd   , '' as rToAdd   , '' as rFromHn   , '' as rfromHN_Number  , '' as rfromHN_Unit  , '' as rToHn   , '' as rtoHN_Number , '' as rtoHN_Unit  , '' as rZip   , '' as rZipPlus4   , '' as rplaceFp00   , '' as rplaceName00   , '' as rplaceName00_Soundex   , '' as rplaceName00_SoundexDM   , '' as rconCtyFp00   , '' as rconCtyName00   , '' as rconCtyName00_Soundex   , '' as rconCtyName00_SoundexDM   , '' as rsubMcdFp00   , '' as rsubMcdName00   , '' as rsubMcdName00_Soundex   , '' as rsubMcdName00_SoundexDM   , '' as rcouSubFp00   , '' as rcouSubName00   , '' as rcouSubName00_Soundex   , '' as rcouSubName00_SoundexDM   , '' as rcountyFp00   , '' as rcountyName00   , '' as rcountyName00_Soundex   , '' as rcountyName00_SoundexDM   , '' as rstateFp00   , '' as rtractCe00   , '' as rblkGrpCe00   , '' as rblockCe00   , '' as rsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " FROM ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " [dbo].[" + StateName + "_Left] ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " WHERE ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param1     ";
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
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon ,fromLat ,toLon ,toLat ,fullName ,preDirAbrv ,preTypAbrv ,preQualAbr ,name ,name_Soundex ,name_SoundexDM ,sufDirAbrv ,sufTypAbrv ,sufQualAbr , shapeGeog , shapeGeom ,rFromAdd  ,rToAdd  ,fromHn as rFromHn  ,fromHN_Number as rfromHN_Number ,fromHN_Unit as rfromHN_Unit ,toHn as rToHn  ,toHN_Number as rtoHN_Number ,toHN_Unit as rtoHN_Unit ,zip as rZip ,plus4 as rZipPlus4  ,placeFp00 as rplaceFp00  ,placeName00 as rplaceName00 ,placeName00_Soundex as rplaceName00_Soundex  ,placeName00_SoundexDM as rplaceName00_SoundexDM ,conCtyFp00 as rconCtyFp00  ,conCtyName00 as rconCtyName00  ,conCtyName00_Soundex as rconCtyName00_Soundex  ,conCtyName00_SoundexDM as rconCtyName00_SoundexDM ,subMcdFp00 as rsubMcdFp00  ,subMcdName00 as rsubMcdName00 ,subMcdName00_Soundex as rsubMcdName00_Soundex  ,subMcdName00_SoundexDM as rsubMcdName00_SoundexDM ,couSubFp00 as rcouSubFp00  ,couSubName00 as rcouSubName00 ,couSubName00_Soundex as rcouSubName00_Soundex  ,couSubName00_SoundexDM as rcouSubName00_SoundexDM ,countyFp00 as rcountyFp00  ,countyName00 as rcountyName00 ,countyName00_Soundex as rcountyName00_Soundex ,countyName00_SoundexDM as rcountyName00_SoundexDM  ,stateFp00 as rstateFp00 ,tractCe00 as rtractCe00 ,blkGrpCe00 as rblkGrpCe00 ,blockCe00 as rblockCe00 ,suffix1Ce as rsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " , '' as lFromAdd , '' as lToAdd , '' as lFromHn , '' as lfromHN_Number  , '' as lfromHN_Unit  , '' as lToHn , '' as ltoHN_Number  , '' as ltoHN_Unit  , '' as lZip , '' as lZipPlus4 , '' as lplaceFp00 , '' as lplaceName00 , '' as lplaceName00_Soundex , '' as lplaceName00_SoundexDM , '' as lconCtyFp00 , '' as lconCtyName00  , '' as lconCtyName00_Soundex , '' as lconCtyName00_SoundexDM , '' as lsubMcdFp00 , '' as lsubMcdName00 , '' as lsubMcdName00_Soundex , '' as lsubMcdName00_SoundexDM , '' as lcouSubFp00 , '' as lcouSubName00 , '' as lcouSubName00_Soundex , '' as lcouSubName00_SoundexDM , '' as lcountyFp00 , '' as lcountyName00 , '' as lcountyName00_Soundex , '' as lcountyName00_SoundexDM , '' as lstateFp00 , '' as ltractCe00 , '' as lblkGrpCe00 , '' as lblockCe00 , '' as lsuffix1Ce  ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " FROM ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " [dbo].[" + StateName + "_Right] ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " WHERE ";
            SQLPostInsertSingleTableUpdateStoredProcedures += " Name_Soundex=@param1     ";
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
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon  , fromLat  , toLon  , toLat  , fullName  , preDirAbrv  , preTypAbrv  , preQualAbr  , name , name_Soundex  , name_SoundexDM  , sufDirAbrv  , sufTypAbrv  , sufQualAbr  ,  shapeGeog  ,  shapeGeom  , lFromAdd   , lToAdd   , fromHn as lFromHn   , fromHN_Number as lfromHN_Number  , fromHN_Unit as lfromHN_Unit  , toHn as lToHn   , toHN_Number as ltoHN_Number  , toHN_Unit as ltoHN_Unit  , zip as lZip   , plus4 as lZipPlus4   , placeFp00 as lplaceFp00   , placeName00 as lplaceName00  , placeName00_Soundex as lplaceName00_Soundex   , placeName00_SoundexDM as lplaceName00_SoundexDM  , conCtyFp00 as lconCtyFp00   , conCtyName00 as lconCtyName00   , conCtyName00_Soundex as lconCtyName00_Soundex   , conCtyName00_SoundexDM as lconCtyName00_SoundexDM  , subMcdFp00 as lsubMcdFp00   , subMcdName00 as lsubMcdName00  , subMcdName00_Soundex as lsubMcdName00_Soundex   , subMcdName00_SoundexDM as lsubMcdName00_SoundexDM  , couSubFp00 as lcouSubFp00   , couSubName00 as lcouSubName00  , couSubName00_Soundex as lcouSubName00_Soundex   , couSubName00_SoundexDM as lcouSubName00_SoundexDM  , countyFp00 as lcountyFp00   , countyName00 as lcountyName00  , countyName00_Soundex as lcountyName00_Soundex   , countyName00_SoundexDM as lcountyName00_SoundexDM  , stateFp00 as lstateFp00   , tractCe00 as ltractCe00   , blkGrpCe00 as lblkGrpCe00   , blockCe00 as lblockCe00   , suffix1Ce as lsuffix1Ce ";
            SQLPostInsertSingleTableUpdateStoredProcedures += "  , '' as rFromAdd   , '' as rToAdd   , '' as rFromHn   , '' as rfromHN_Number  , '' as rfromHN_Unit  , '' as rToHn   , '' as rtoHN_Number , '' as rtoHN_Unit  , '' as rZip   , '' as rZipPlus4   , '' as rplaceFp00   , '' as rplaceName00   , '' as rplaceName00_Soundex   , '' as rplaceName00_SoundexDM   , '' as rconCtyFp00   , '' as rconCtyName00   , '' as rconCtyName00_Soundex   , '' as rconCtyName00_SoundexDM   , '' as rsubMcdFp00   , '' as rsubMcdName00   , '' as rsubMcdName00_Soundex   , '' as rsubMcdName00_SoundexDM   , '' as rcouSubFp00   , '' as rcouSubName00   , '' as rcouSubName00_Soundex   , '' as rcouSubName00_SoundexDM   , '' as rcountyFp00   , '' as rcountyName00   , '' as rcountyName00_Soundex   , '' as rcountyName00_SoundexDM   , '' as rstateFp00   , '' as rtractCe00   , '' as rblkGrpCe00   , '' as rblockCe00   , '' as rsuffix1Ce  ";
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
            SQLPostInsertSingleTableUpdateStoredProcedures += " tlid ,fromLon ,fromLat ,toLon ,toLat ,fullName ,preDirAbrv ,preTypAbrv ,preQualAbr ,name ,name_Soundex ,name_SoundexDM ,sufDirAbrv ,sufTypAbrv ,sufQualAbr , shapeGeog , shapeGeom ,rFromAdd  ,rToAdd  ,fromHn as rFromHn  ,fromHN_Number as rfromHN_Number ,fromHN_Unit as rfromHN_Unit ,toHn as rToHn  ,toHN_Number as rtoHN_Number ,toHN_Unit as rtoHN_Unit ,zip as rZip ,plus4 as rZipPlus4  ,placeFp00 as rplaceFp00  ,placeName00 as rplaceName00 ,placeName00_Soundex as rplaceName00_Soundex  ,placeName00_SoundexDM as rplaceName00_SoundexDM ,conCtyFp00 as rconCtyFp00  ,conCtyName00 as rconCtyName00  ,conCtyName00_Soundex as rconCtyName00_Soundex  ,conCtyName00_SoundexDM as rconCtyName00_SoundexDM ,subMcdFp00 as rsubMcdFp00  ,subMcdName00 as rsubMcdName00 ,subMcdName00_Soundex as rsubMcdName00_Soundex  ,subMcdName00_SoundexDM as rsubMcdName00_SoundexDM ,couSubFp00 as rcouSubFp00  ,couSubName00 as rcouSubName00 ,couSubName00_Soundex as rcouSubName00_Soundex  ,couSubName00_SoundexDM as rcouSubName00_SoundexDM ,countyFp00 as rcountyFp00  ,countyName00 as rcountyName00 ,countyName00_Soundex as rcountyName00_Soundex ,countyName00_SoundexDM as rcountyName00_SoundexDM  ,stateFp00 as rstateFp00 ,tractCe00 as rtractCe00 ,blkGrpCe00 as rblkGrpCe00 ,blockCe00 as rblockCe00 ,suffix1Ce as rsuffix1Ce  ";
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
