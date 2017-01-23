using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.Converter;
using System.Data;
using NPOI.SS.UserModel;
using Rico.NPOISample.Common;

namespace Rico.NPOISample
{
    [TestClass]
    public class ImportExport : BaseTest
    {
        public ImportExport()
        {
            _testResultDirectory = "ImportExportResult";
        }

        [TestMethod]
        public void ConvertExcelToHtml()
        {
            HSSFWorkbook workbook;
            //the excel file to convert
            string fileName = "19599-1.xls";
            string filePath = GetTestFile(fileName);
            //fileName = Path.Combine(Environment.CurrentDirectory, fileName);
            workbook = ExcelToHtmlUtils.LoadXls(filePath);


            ExcelToHtmlConverter excelToHtmlConverter = new ExcelToHtmlConverter();

            //set output parameter
            excelToHtmlConverter.OutputColumnHeaders = false;
            excelToHtmlConverter.OutputHiddenColumns = true;
            excelToHtmlConverter.OutputHiddenRows = true;
            excelToHtmlConverter.OutputLeadingSpacesAsNonBreaking = false;
            excelToHtmlConverter.OutputRowNumbers = true;
            excelToHtmlConverter.UseDivsToSpan = true;

            //process the excel file
            excelToHtmlConverter.ProcessWorkbook(workbook);

            //output the html file
            excelToHtmlConverter.Document.Save(Path.ChangeExtension(_saveResultPath+ fileName, "html"));
            //excelToHtmlConverter.Document.Save(Path.ChangeExtension(fileName, "html"));
        }
        [TestMethod]
        public void ImportXlsToDataTable()
        {
            var path = GetTestFile("ImportXlsToDataTable.xls");
            InitializeWorkbook(path);
            var dt = ConvertToDataTable();

            ExcelHelper.ExportDataTableToExcel(dt, "ImportXlsToDataTable", "ImportExportResult\\ImportXlsToDataTable.xls");
        }
        DataTable ConvertToDataTable()
        {
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            for (int j = 0; j < 5; j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }

            while (rows.MoveNext())
            {
                IRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);


                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        [TestMethod]
        public void ExportXlsToDownload()
        {
            //string filename = "test.xls";
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            //Response.Clear();

            //InitializeWorkbook();
            //GenerateData();
            //GetExcelStream().WriteTo(Response.OutputStream);
            //Response.End();
        }
        void GenerateData()
        {
            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("This is a Sample");
            int x = 1;
            for (int i = 1; i <= 15; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < 15; j++)
                {
                    row.CreateCell(j).SetCellValue(x++);
                }
            }
        }
        MemoryStream GetExcelStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
    }
}
