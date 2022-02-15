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
    public interface IExcelService
    {
        void ExportExcel(string path, string worksheetName, DataTable source);
    }
}
