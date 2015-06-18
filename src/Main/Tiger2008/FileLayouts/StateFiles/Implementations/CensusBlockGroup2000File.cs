using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.Implementations
{
    public class CensusBlockGroup2000File : AbstractTiger2008ShapefileStateFileLayout
    {

        public CensusBlockGroup2000File(string stateName)
            : base(stateName)
        {

            FileName = "bg00.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "id int IDENTITY(1,1) NOT NULL,";
            SQLCreateTable += "stateFp00 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp00 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "TractCe00 varchar(6) DEFAULT NULL,";
            SQLCreateTable += "BlkGrpCe00 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "bkgpIdFp00 varchar(12) DEFAULT NULL,";
            SQLCreateTable += "NameLsad00 varchar(13) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc00 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat00 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography, ";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (id)";
            SQLCreateTable += ");";

            ExcludeColumns = new string[] { "id" };

        }
    }
}
