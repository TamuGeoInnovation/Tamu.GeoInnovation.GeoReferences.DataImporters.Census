﻿using System;
using System.Data;
using USC.GISResearchLab.Common.Census.Tiger2015.FileLayouts.CountyFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2015.FileLayouts.CountyFiles.Implementations
{
    public class Tiger2015AddressRangesFile : AbstractTiger2015CountyFileLayout
    {
        public Tiger2015AddressRangesFile(string stateName)
            : base(stateName)
        {

            FileName = "addr.zip";


            ShouldSplitAddressRanges = true;
            SplitAddressRangesColumns = new string[] { "fromHN", "toHN" };

            ShouldAddEvenOddFlag = true;
            AddEvenOddFlagColumns = new string[] { "fromHN_Number", "toHN_Number" };


            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "tlid int NOT NULL,";
            SQLCreateTable += "fromHN varchar(12), ";
            SQLCreateTable += "fromHN_Number int, ";
            SQLCreateTable += "fromHN_Number_Even bit, ";
            SQLCreateTable += "fromHN_Unit varchar(12), ";
            SQLCreateTable += "toHN varchar(12), ";
            SQLCreateTable += "toHN_Number int, ";
            SQLCreateTable += "toHN_Number_Even bit, ";
            SQLCreateTable += "toHN_Unit varchar(12), ";
            SQLCreateTable += "side varchar(1), ";
            SQLCreateTable += "zip varchar(5), ";
            SQLCreateTable += "plus4 varchar(4), ";
            SQLCreateTable += "fromTyp varchar(1), ";
            SQLCreateTable += "toTyp varchar(1), ";
            SQLCreateTable += "arid varchar(22), ";
            SQLCreateTable += "mtFCC varchar(5) DEFAULT NULL, ";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_arid] PRIMARY KEY CLUSTERED ([arid] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLAlterTableAddForeignKeys += " ALTER TABLE [" + OutputTableName + "] ";
            SQLAlterTableAddForeignKeys += " ADD";
            SQLAlterTableAddForeignKeys += " CONSTRAINT [FK_" + OutputTableName + "_edges_tlid] FOREIGN KEY (tlid) REFERENCES " + stateName + "_edges (tlid) ";
            SQLAlterTableAddForeignKeys += " ;";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_tlid' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "_tlid] ON [dbo].[" + OutputTableName + "](	tlid ASC)INCLUDE ([fromHN],[toHN],[zip],[plus4]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_side' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [idx_" + OutputTableName + "_side] ON [dbo].[" + OutputTableName + "] ([side]) INCLUDE ([tlid],[fromHN],[toHN],[zip],[plus4]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_even_side' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [idx_" + OutputTableName + "_even_side] ON [dbo].[" + OutputTableName + "] ( [fromHN_Number_Even] ASC, [side] ASC ) INCLUDE ( [tlid], [fromHN], [fromHN_Number], [fromHN_Unit], [toHN], [toHN_Number], [toHN_Unit], [zip], [plus4]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

            SQLCreateTableIndexes += " IF  NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[" + OutputTableName + "]') AND name = N'IDX_" + OutputTableName + "_fromHN_Number_Even-zip' )";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [idx_" + OutputTableName + "_fromHN_Number_Even-zip] ON [dbo].[" + OutputTableName + "] ( [fromHN_Number_Even],[zip] ) INCLUDE ([tlid],[fromHN],[fromHN_Number],[fromHN_Unit],[toHN],[toHN_Number],[toHN_Unit],[plus4]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
        }

        public override IDataReader GetDataReader(string fileLocation)
        {
            Tiger2015AddressRangesFileDataReader ret = null;

            try
            {
                ret = new Tiger2015AddressRangesFileDataReader(fileLocation);
                ret.NotifyAfter = 10;
                ret.ShouldSplitAddressRanges = ShouldSplitAddressRanges;
                ret.SplitAddressRangesColumns = SplitAddressRangesColumns;
                ret.ShouldAddEvenOddFlag = ShouldAddEvenOddFlag;
                ret.AddEvenOddFlagColumns = AddEvenOddFlagColumns;

            }
            catch (Exception e)
            {
                throw new Exception("Error getting datatable: " + e.Message, e);
            }

            return ret;
        }
    }
}
