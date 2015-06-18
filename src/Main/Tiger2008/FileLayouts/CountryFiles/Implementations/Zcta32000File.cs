using USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountryFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.CountryFiles.Implementations
{
    public class Zcta32000File : AbstractTiger2010ShapefileCountryFileLayout
    {

        public Zcta32000File(string stateName)
            : base(stateName)
        {

            FileName = "zcta300.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "zcta3ce00 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "classFp00 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc00 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat00 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (zcta3ce00)";
            SQLCreateTable += ");";

            SQLCreateTableIndexes += " CREATE NONCLUSTERED INDEX [IDX_" + OutputTableName + "zcta3ce00] ON [dbo].[" + OutputTableName + "] (zcta3ce00) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];";

        }
    }
}
