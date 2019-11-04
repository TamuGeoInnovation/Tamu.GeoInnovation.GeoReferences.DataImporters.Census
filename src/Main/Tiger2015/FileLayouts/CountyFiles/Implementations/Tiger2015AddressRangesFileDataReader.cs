using System;
using System.Data;
using USC.GISResearchLab.Common.Databases.Dbf;
using USC.GISResearchLab.Common.Utils.Numbers;

namespace USC.GISResearchLab.Common.Census.Tiger2015.FileLayouts.CountyFiles.Implementations
{
    public class Tiger2015AddressRangesFileDataReader : DbfDataReaderAddSoundex
    {

        #region Properties

        private bool _ShouldSplitAddressRanges;
        public bool ShouldSplitAddressRanges
        {
            get { return _ShouldSplitAddressRanges; }
            set { _ShouldSplitAddressRanges = value; }
        }

        private string[] _SplitAddressRangesColumns;
        public string[] SplitAddressRangesColumns
        {
            get { return _SplitAddressRangesColumns; }
            set { _SplitAddressRangesColumns = value; }
        }

        private bool _ShouldAddEvenOddFlag;
        public bool ShouldAddEvenOddFlag
        {
            get { return _ShouldAddEvenOddFlag; }
            set { _ShouldAddEvenOddFlag = value; }
        }

        private string[] _AddEvenOddFlagColumns;
        public string[] AddEvenOddFlagColumns
        {
            get { return _AddEvenOddFlagColumns; }
            set { _AddEvenOddFlagColumns = value; }
        }

        #endregion

        public Tiger2015AddressRangesFileDataReader(string fileName)
            : base(fileName) { }


        public override DataTable GetSchemaTable()
        {

            try
            {
                base.GetSchemaTable();

                if (SchemaTable != null)
                {

                    DataRow row = SchemaTable.NewRow();

                    if (ShouldSplitAddressRanges)
                    {
                        if (SplitAddressRangesColumns != null)
                        {
                            for (int i = 0; i < SplitAddressRangesColumns.Length; i++)
                            {
                                string column = SplitAddressRangesColumns[i];

                                row = SchemaTable.NewRow();
                                row["ColumnName"] = column + "_Number";
                                row["ColumnOrdinal"] = 0;
                                row["DataType"] = typeof(Int32);
                                row["IsReadOnly"] = true;
                                SchemaTable.Rows.Add(row);

                                row = SchemaTable.NewRow();
                                row["ColumnName"] = column + "_Unit";
                                row["ColumnOrdinal"] = 0;
                                row["DataType"] = typeof(String);
                                row["IsReadOnly"] = true;
                                SchemaTable.Rows.Add(row);
                            }
                        }
                    }

                    if (ShouldAddEvenOddFlag)
                    {
                        if (AddEvenOddFlagColumns != null)
                        {
                            for (int i = 0; i < AddEvenOddFlagColumns.Length; i++)
                            {
                                string column = AddEvenOddFlagColumns[i];

                                row = SchemaTable.NewRow();
                                row["ColumnName"] = column + "_Even";
                                row["ColumnOrdinal"] = 0;
                                row["DataType"] = typeof(Boolean);
                                row["IsReadOnly"] = true;
                                SchemaTable.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured GetSchemaTable: " + e.Message, e);
            }

            return SchemaTable;
        }


        public override bool NextFeature()
        {
            bool ret = true;
            try
            {

                if (base.NextFeature())
                {
                    if (ShouldSplitAddressRanges)
                    {
                        if (SplitAddressRangesColumns != null)
                        {
                            for (int i = 0; i < SplitAddressRangesColumns.Length; i++)
                            {
                                string column = SplitAddressRangesColumns[i];
                                string orig = (string)GetValue(GetOrdinal(column));

                                int numberRange = -1;
                                string unitRange = "";

                                if (NumberUtils.IsInt(orig))
                                {
                                    numberRange = Convert.ToInt32(orig);
                                }
                                else
                                {
                                    if (orig.IndexOf('-') >= 0)
                                    {
                                        string[] parts = orig.Split('-');
                                        if (parts.Length == 2)
                                        {
                                            if (NumberUtils.IsInt(parts[0]))
                                            {
                                                numberRange = Convert.ToInt32(parts[0]);

                                            }

                                            unitRange = parts[1];
                                        }
                                    }
                                }

                                object[] temp = new object[CurrentRow.Length + 2];
                                Array.Copy(CurrentRow, temp, CurrentRow.Length);

                                if (numberRange >= 0)
                                {
                                    temp[temp.Length - 2] = numberRange;
                                }

                                temp[temp.Length - 1] = unitRange;
                                CurrentRow = temp;
                            }
                        }
                    }

                    if (ShouldAddEvenOddFlag)
                    {
                        if (AddEvenOddFlagColumns != null)
                        {
                            for (int i = 0; i < AddEvenOddFlagColumns.Length; i++)
                            {

                                object[] temp = new object[CurrentRow.Length + 1];
                                Array.Copy(CurrentRow, temp, CurrentRow.Length);

                                string column = AddEvenOddFlagColumns[i];
                                int value = GetInt32(GetOrdinal(column));

                                if (value > 0)
                                {
                                    int evenOdd = value % 2;
                                    bool odd = Convert.ToBoolean(evenOdd);
                                    temp[temp.Length - 1] = !odd;
                                }

                                CurrentRow = temp;
                            }
                        }
                    }
                }
                else
                {
                    ret = false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured in NextFeature: " + e.Message, e);
            }
            return ret;
        }
    }
}
