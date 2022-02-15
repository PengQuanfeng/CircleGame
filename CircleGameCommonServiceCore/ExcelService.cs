using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CircleGameCommonServiceCore
{
    public class ExcelService : IExcelService
    {
        public void ExportExcel(string path, string worksheetName, DataTable source)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet findedWorksheet = package.Workbook.Worksheets.FirstOrDefault(w => w.Name.Equals(worksheetName));
                    if (findedWorksheet != null)
                    {
                        package.Workbook.Worksheets.Delete(worksheetName);
                    }
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetName);
                    worksheet.Cells.LoadFromDataTable(source, true);

                    package.Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
