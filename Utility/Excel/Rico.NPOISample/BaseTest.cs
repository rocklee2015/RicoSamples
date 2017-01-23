using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;

namespace Rico.NPOISample
{
    public abstract class BaseTest
    {
        protected string _testResultDirectory = "TestResult";
        protected static HSSFWorkbook hssfworkbook;

        protected string _saveResultPath
        {
            get
            {
                if (!Directory.Exists(_testResultDirectory))
                {
                    Directory.CreateDirectory(_testResultDirectory);
                }
                return System.IO.Directory.GetCurrentDirectory() + $"\\{_testResultDirectory}\\";
            }
        }

        protected void InitializeWorkbook(string filePath = "")
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                using (var fs = File.OpenRead(filePath))
                {
                    hssfworkbook = new HSSFWorkbook(fs);
                }
            }
            else
            {
                hssfworkbook = new HSSFWorkbook();
            }
            //Create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //Create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;
        }
        protected void WriteToFile(string fileName, string fileExtension = "xls")
        {
            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(_saveResultPath + $"\\{fileName}.{fileExtension}", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }

        protected string GetTestFile(string fileName)
        {
            return System.IO.Directory.GetParent("../../").FullName + $@"\TestData\{fileName}";
        }
    }
}
