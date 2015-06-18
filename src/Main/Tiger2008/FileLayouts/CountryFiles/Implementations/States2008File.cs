using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.Implementations
{
    public class States2008File : AbstractTiger2008ShapefileCountryFileLayout
    {

        public States2008File(string stateName)
            : base(stateName)
        {

            FileName = "state.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "stateFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "stateNs varchar(8) DEFAULT NULL,";
            SQLCreateTable += "stUsPs varchar(2) DEFAULT NULL,";
            SQLCreateTable += "name varchar(100) DEFAULT NULL,";
            SQLCreateTable += "lsad varchar(2) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (name)";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "Name] ON [dbo].[" + OutputTableName + "] (Name) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";
            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "stUsPs] ON [dbo].[" + OutputTableName + "] (stUsPs) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

        }
    }
}
