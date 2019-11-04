﻿using USC.GISResearchLab.Common.Census.Tiger2015.FileLayouts.StateFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2015.FileLayouts.StateFiles.Implementations
{
    public class CensusBlock2015File : AbstractTiger2015ShapefileStateFileLayout
    {


        public CensusBlock2015File(string stateName)
            : base(stateName)
        {

            ExcludeColumns = new string[]
            {
                "uniqueId",
            };

            FileName = "tabblock10.zip";

            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "uniqueId int identity(1,1) NOT NULL,";
            SQLCreateTable += "stateFp10 varchar(2) DEFAULT NULL,";
            SQLCreateTable += "countyFp10 varchar(3) DEFAULT NULL,";
            SQLCreateTable += "TractCe10 varchar(6) DEFAULT NULL,";
            SQLCreateTable += "BlockCe10 varchar(4) DEFAULT NULL,";
            SQLCreateTable += "GeoId10 varchar(15) DEFAULT NULL,";
            SQLCreateTable += "Name10 varchar(10) DEFAULT NULL,";
            SQLCreateTable += "Mtfcc10 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "UR10 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "UAce10 varchar(5) DEFAULT NULL,";
            SQLCreateTable += "FuncStat10 varchar(1) DEFAULT NULL,";
            SQLCreateTable += "aLand10 varchar(14) DEFAULT NULL,";
            SQLCreateTable += "aWater10 varchar(14) DEFAULT NULL,";
            SQLCreateTable += "intPtLat10 varchar(11) DEFAULT NULL,";
            SQLCreateTable += "intPtLon10 varchar(12) DEFAULT NULL,";
            SQLCreateTable += "shapeType varchar(55), ";
            SQLCreateTable += "shapeGeog geography,";
            SQLCreateTable += "shapeGeom geometry,";
            SQLCreateTable += "PRIMARY KEY  (uniqueId)";
            SQLCreateTable += ");";

        }
    }
}
