using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace Rico.S01.NPOISample
{
    [TestClass]
    public class WorkbookAndSheetTest : BaseTest
    {
        public WorkbookAndSheetTest()
        {
            _testResultDirectory = "WorkbookAndSheetTestResult";
        }

        [TestMethod]
        public void MergeCellsInXls()
        {
            InitializeWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("new sheet");

            IRow row = sheet.CreateRow(0);
            row.HeightInPoints = 30;

            ICell cell = row.CreateCell(0);
            //set the title of the sheet
            cell.SetCellValue("Sales Report");

            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            //create a font style
            IFont font = hssfworkbook.CreateFont();
            font.FontHeight = 20 * 20;
            style.SetFont(font);
            cell.CellStyle = style;

            //merged cells on single row
            //ATTENTION: don't use Region class, which is obsolete
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));

            //merged cells on mutiple rows
            CellRangeAddress region = new CellRangeAddress(2, 4, 2, 4);
            sheet.AddMergedRegion(region);

            //set enclosed border for the merged region
            ((HSSFSheet) sheet).SetEnclosedBorderOfRegion(region, BorderStyle.Dotted, HSSFColor.Red.Index);

            WriteToFile("MergeCellsInXls");
        }

        [TestMethod]
        public void ChangeSheetTabColorInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            sheet1.TabColorIndex = HSSFColor.Red.Index;
            ISheet sheet2 = hssfworkbook.CreateSheet("Sheet2");
            sheet2.TabColorIndex = HSSFColor.Blue.Index;
            ISheet sheet3 = hssfworkbook.CreateSheet("Sheet3");
            sheet3.TabColorIndex = HSSFColor.Aqua.Index;

            WriteToFile("ChangeSheetTabColorInXls");
        }

        [TestMethod]
        public void MultplicationTableInXls()
        {
            InitializeWorkbook();

            //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
            //So we insert three sheet just like what Excel does
            ISheet sheet1 = hssfworkbook.CreateSheet("Multiple Table");

            //create horizontal 1-9
            for (var i = 1; i <= 9; i++)
                sheet1.CreateRow(0).CreateCell(i).SetCellValue(i);
            //create vertical 1-9
            for (var i = 1; i <= 9; i++)
                sheet1.CreateRow(i).CreateCell(0).SetCellValue(i);
            //create the cell formula
            for (var iRow = 1; iRow <= 9; iRow++)
            {
                IRow row = sheet1.GetRow(iRow);
                for (var iCol = 1; iCol <= 9; iCol++)
                {
                    //the first cell of each row * the first cell of each column
                    var formula = GetCellPosition(iRow, 0) + "*" + GetCellPosition(0, iCol);
                    row.CreateCell(iCol).CellFormula = formula;
                }
            }

            WriteToFile("MultplicationTableInXls");
        }

        private static string GetCellPosition(int row, int col)
        {
            col = Convert.ToInt32('A') + col;
            row = row + 1;
            return (char) col + row.ToString();
        }
    }
}