namespace Dumbi.Core
{
    using System.Data;
    using System.Data.OleDb;
    using System.IO;

    /// <summary>
    /// Class for reading Excel files
    /// </summary>
    public class ExcelReader
    {
        /// <summary>
        /// Read the specified Excel file and returns the content
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        public DataTable Read(string excelFile)
        {
            string connectionString = string.Empty;

            string fileExtension = Path.GetExtension(excelFile);
            if (fileExtension == ".xls")
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
            }
            else if (fileExtension == ".xlsx")
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            }

            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand command = conn.CreateCommand())
                {
                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = dtSheet.Rows[0]["TABLE_NAME"].ToString();

                    command.CommandText = string.Format("SELECT * FROM [{0}]", sheetName);

                    using (OleDbDataAdapter da = new OleDbDataAdapter(command))
                    {
                        var dt = new DataTable();

                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
