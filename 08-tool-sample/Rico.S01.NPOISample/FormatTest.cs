using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace Rico.S01.NPOISample
{
    [TestClass]
    public class FormatTest : BaseTest
    {
        public FormatTest()
        {
            _testResultDirectory = "FormatTestResult";
        }

        [TestMethod]
        public void ConditionalFormattingInXls()
        {
            InitializeWorkbook();

            HSSFSheet sheet1 = (HSSFSheet) hssfworkbook.CreateSheet("Sheet1");

            ISheetConditionalFormatting hscf = sheet1.SheetConditionalFormatting;


            // Define a Conditional Formatting rule, which triggers formatting
            // when cell's value is bigger than 55 and smaller than 500
            // applies patternFormatting defined below.
            IConditionalFormattingRule rule = hscf.CreateConditionalFormattingRule(
                ComparisonOperator.Between,
                "55", // 1st formula 
                "500" // 2nd formula 
            );

            // Create pattern with red background
            IPatternFormatting patternFmt = rule.CreatePatternFormatting();
            patternFmt.FillBackgroundColor = HSSFColor.Red.Index;

            //// Define a region containing first column
            CellRangeAddress[] regions =
            {
                new CellRangeAddress(0, 65535, 0, 1)
            };
            // Apply Conditional Formatting rule defined above to the regions  
            hscf.AddConditionalFormatting(regions, rule);

            //fill cell with numeric values
            sheet1.CreateRow(0).CreateCell(0).SetCellValue(50);
            sheet1.CreateRow(0).CreateCell(1).SetCellValue(101);
            sheet1.CreateRow(1).CreateCell(1).SetCellValue(25);
            sheet1.CreateRow(1).CreateCell(0).SetCellValue(150);

            WriteToFile("ConditionalFormattingInXls");
        }

        #region NumberFormatInXls

        [TestMethod]
        public void NumberFormatInXls()
        {
            InitializeWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("new sheet");
            //increase the width of Column A
            sheet.SetColumnWidth(0, 5000);
            //create the format instance
            IDataFormat format = hssfworkbook.CreateDataFormat();

            // Create a row and put some cells in it. Rows are 0 based.
            ICell cell = sheet.CreateRow(0).CreateCell(0);
            //set value for the cell
            cell.SetCellValue(1.2);
            //number format with 2 digits after the decimal point - "1.20"
            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            cell.CellStyle = cellStyle;

            //RMB currency format with comma    -   "¥20,000"
            ICell cell2 = sheet.CreateRow(1).CreateCell(0);
            cell2.SetCellValue(20000);
            ICellStyle cellStyle2 = hssfworkbook.CreateCellStyle();
            cellStyle2.DataFormat = format.GetFormat("¥#,##0");
            cell2.CellStyle = cellStyle2;

            //scentific number format   -   "3.15E+00"
            ICell cell3 = sheet.CreateRow(2).CreateCell(0);
            cell3.SetCellValue(3.151234);
            ICellStyle cellStyle3 = hssfworkbook.CreateCellStyle();
            cellStyle3.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
            cell3.CellStyle = cellStyle3;

            //percent format, 2 digits after the decimal point    -  "99.33%"
            ICell cell4 = sheet.CreateRow(3).CreateCell(0);
            cell4.SetCellValue(0.99333);
            ICellStyle cellStyle4 = hssfworkbook.CreateCellStyle();
            cellStyle4.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
            cell4.CellStyle = cellStyle4;

            //phone number format - "021-65881234"
            ICell cell5 = sheet.CreateRow(4).CreateCell(0);
            cell5.SetCellValue(02165881234);
            ICellStyle cellStyle5 = hssfworkbook.CreateCellStyle();
            cellStyle5.DataFormat = format.GetFormat("000-00000000");
            cell5.CellStyle = cellStyle5;

            //Chinese capitalized character number - 壹贰叁 元
            ICell cell6 = sheet.CreateRow(5).CreateCell(0);
            cell6.SetCellValue(123);
            ICellStyle cellStyle6 = hssfworkbook.CreateCellStyle();
            cellStyle6.DataFormat = format.GetFormat("[DbNum2][$-804]0 元");
            cell6.CellStyle = cellStyle6;

            //Chinese date string
            ICell cell7 = sheet.CreateRow(6).CreateCell(0);
            cell7.SetCellValue(new DateTime(2004, 5, 6));
            ICellStyle cellStyle7 = hssfworkbook.CreateCellStyle();
            cellStyle7.DataFormat = format.GetFormat("yyyy年m月d日");
            cell7.CellStyle = cellStyle7;


            //Chinese date string
            ICell cell8 = sheet.CreateRow(7).CreateCell(0);
            cell8.SetCellValue(new DateTime(2005, 11, 6));
            ICellStyle cellStyle8 = hssfworkbook.CreateCellStyle();
            cellStyle8.DataFormat = format.GetFormat("yyyy年m月d日");
            cell8.CellStyle = cellStyle8;

            WriteToFile("NumberFormatInXls");
        }

        #endregion
    }
}