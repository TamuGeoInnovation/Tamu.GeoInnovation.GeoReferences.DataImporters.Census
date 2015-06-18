using USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2008.FileLayouts.StateFiles.Implementations
{
    public class CensusBlock20008File : AbstractTiger2008ShapefileStateFileLayout
    {

        public CensusBlock20008File(string stateName)
            : base(stateName)
        {

            FileName = "tabblock.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "stateFp varchar(2) DEFAULT NULL,";
            SQLCreateTable += "stateNs varchar(8) DEFAULT NULL,";
            SQLCreateTable += "countyFp varchar(3) DEFAULT NULL,";
            SQLCreateTable += "stateFp00 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp00 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "TractCe00 varchar(6) DEFAULT NULL,";
            SQLCreateTable += "BlockCe00 varchar(4) DEFAULT NULL,";
            SQLCreateTable += "suffix1Ce varchar(1) DEFAULT NULL,";
            SQLCreateTable += "blkIdFp varchar(15) DEFAULT NULL,";
            SQLCreateTable += "Name varchar(10) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc varchar(5) DEFAULT NULL,";
            SQLCreateTable += "UR varchar(1) DEFAULT NULL,";
            SQLCreateTable += "UAce varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat varchar(1) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (blkIdFp)";
            SQLCreateTable += ");";

        }
    }
}
