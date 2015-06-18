using USC.GISResearchLab.Common.Census.Tiger1990.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger1990.FileLayouts.StateFiles.Implementations
{
    public class CensusTract1990File : AbstractTiger1990ShapefileStateFileLayout
    {

        public CensusTract1990File(string stateName, string stateFips)
            : base(stateName)
        {

            ExcludeColumns = new string[] 
            { 
                "uniqueId",
                "tr" + stateFips + "_d90_",
                "tr" + stateFips + "_d90_I",
            };

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "uniqueId int NOT NULL IDENTITY (1,1),";
            SQLCreateTable += "st varchar(2) DEFAULT NULL,";
            SQLCreateTable += "co varchar(3) DEFAULT NULL,";
            SQLCreateTable += "tractBase varchar(4) DEFAULT NULL,";
            SQLCreateTable += "tractSuf varchar(2) DEFAULT '00',";
            SQLCreateTable += "tract_Name varchar(7) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (uniqueId)";
            SQLCreateTable += ");";

        }
    }
}
