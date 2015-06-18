using USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.Implementations
{
    public class CensusTract2000File : AbstractTiger2010ShapefileStateFileLayout
    {

        public CensusTract2000File(string stateName)
            : base(stateName)
        {

            FileName = "tract00.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "stateFp00 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp00 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "TractCe00 varchar(6) DEFAULT NULL,";
            SQLCreateTable += "CtidFp00 varchar(11) DEFAULT NULL,";
            SQLCreateTable += "Name00 varchar(7) DEFAULT NULL,";
            SQLCreateTable += "NameLsad00 varchar(20) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc00 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat00 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (CtidFp00)";
            SQLCreateTable += ");";

        }
    }
}
