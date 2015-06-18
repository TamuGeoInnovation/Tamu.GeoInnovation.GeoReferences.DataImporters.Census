using USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountyFiles.AbstractClasses;

namespace USC.GISResearchLab.Common.Census.Tiger2010.FileLayouts.CountyFiles.Implementations
{
    public class Tiger2010AddressRangesFeatureNamesFile : AbstractTiger2010CountyFileLayout
    {
        public Tiger2010AddressRangesFeatureNamesFile(string stateName)
            : base(stateName)
        {

            FileName = "addrfn.zip";


            SQLCreateTable += "CREATE TABLE [" + OutputTableName + "] (";
            SQLCreateTable += "arid varchar(22), ";
            SQLCreateTable += "lineArid varchar(22), ";
            SQLCreateTable += "CONSTRAINT [PK_" + OutputTableName + "_arid_lineArid] PRIMARY KEY CLUSTERED ([arid], [lineArid] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";
            SQLCreateTable += ");";

            SQLAlterTableAddForeignKeys += " ALTER TABLE [" + OutputTableName + "] ";
            SQLAlterTableAddForeignKeys += " ADD ";
            SQLAlterTableAddForeignKeys += " CONSTRAINT [FK" + OutputTableName + "__addr_arid] FOREIGN KEY (arid) REFERENCES " + stateName + "_addr (arid) ";
            SQLAlterTableAddForeignKeys += " ;";

        }
    }
}
