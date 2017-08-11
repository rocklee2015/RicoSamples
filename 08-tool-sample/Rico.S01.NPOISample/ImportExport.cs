using System;
using System.Collections;
using System.Data;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.SS.Converter;
using NPOI.SS.UserModel;
using Rico.S01.NPOISample.Common;

namespace Rico.S01.NPOISample
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
            var fileName = "19599-1.xls";
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
            excelToHtmlConverter.Document.Save(Path.ChangeExtension(_saveResultPath + fileName, "html"));
            //excelToHtmlConverter.Document.Save(Path.ChangeExtension(fileName, "html"));
        }

        [TestMethod]
        public void ImportXlsToDataTable()
        {
            var path = GetTestFile("ImportXlsToDataTable.xls");
            InitializeWorkbook(path);
            var dt = ConvertToDataTable();

            ExcelHelper.ExportDataTableToExcel(dt, "ImportXlsToDataTable",
                "ImportExportResult\\ImportXlsToDataTable.xls");
        }

        private DataTable ConvertToDataTable()
        {
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();

            var dt = new DataTable();
            for (var j = 0; j < 5; j++)
                dt.Columns.Add(Convert.ToChar('A' + j).ToString());

            while (rows.MoveNext())
            {
                IRow row = (HSSFRow) rows.Current;
                var dr = dt.NewRow();

                for (var i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);


                    if (cell == null)
                        dr[i] = null;
                    else
                        dr[i] = cell.ToString();
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

        private void GenerateData()
        {
            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("This is a Sample");
            var x = 1;
            for (var i = 1; i <= 15; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (var j = 0; j < 15; j++)
                    row.CreateCell(j).SetCellValue(x++);
            }
        }

        private MemoryStream GetExcelStream()
        {
            //Write the stream data of workbook to the root directory
            var file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
    }
}