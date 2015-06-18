using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.Implementations
{
    public class Zcta32008File : AbstractTiger2008ShapefileCountryFileLayout
    {

        public Zcta32008File(string stateName)
            : base(stateName)
        {

            FileName = "zcta3.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "zcta3ce varchar(3) DEFAULT NULL,";
            SQLCreateTable += "classFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (zcta3ce)";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "zcta3ce] ON [dbo].[" + OutputTableName + "] (zcta3ce) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

        }
    }
}
