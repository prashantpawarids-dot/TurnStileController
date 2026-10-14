using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;


namespace Demo_CSharp
{
    public class ExcelImport
    {
        public List<clsCommon> ImportFromExcelFile(string _FilePath)
        {
            List<clsCommon> dataList = new List<clsCommon>();
            string _filePath = _FilePath;
            string _extension = Path.GetExtension(_filePath);
            DataTable dt = new DataTable();
            if (_extension == ".xlsx")
            {
                IXLWorkbook xLWorkbook = new XLWorkbook();
                try
                {
                    using (var excelWorkbook = new XLWorkbook(_FilePath))
                    {
                        clsCommon asst = null;
                        var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed().Skip(1);
                        int cnt = nonEmptyDataRows.Count();
                        foreach (var dataRow in nonEmptyDataRows)
                        {
                            asst = new clsCommon();
                            asst.UserId =Convert.ToUInt32(dataRow.Cell(1)?.Value.ToString());
                            asst.UserName = dataRow.Cell(2)?.Value.ToString();
                            asst.CardNo = dataRow.Cell(3)?.Value.ToString();
                            asst.EmployeeID = dataRow.Cell(4)?.Value.ToString();
                            dataList.Add(asst);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return dataList;
        }
    }
}
