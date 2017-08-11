using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.UserModel;

namespace Rico.S01.NPOISample
{
    [TestClass]
    public class AutoSizeColumnInXlsTest : BaseTest
    {
        public AutoSizeColumnInXlsTest()
        {
            _testResultDirectory = "AutoSizeColumnInXlsTestResult";
        }

        [TestMethod]
        public void AutoSizeColumnInXls()
        {
            GroupRowAndColumnInXls();

            HideColumnAndRowInXls();

            RepeatingRowsAndColumns();

            SetWidthAndHeightInXls();

            ShrinkToFitColumnInXls();

            SplitAndFreezePanes();

            Assert.IsTrue(true);
        }

        #region======= GroupRowAndColumnInXls=========

        private void GroupRowAndColumnInXls()
        {
            InitializeWorkbook();

            ISheet s = hssfworkbook.CreateSheet("Sheet1");
            IRow r1 = s.CreateRow(0);
            IRow r2 = s.CreateRow(1);
            IRow r3 = s.CreateRow(2);
            IRow r4 = s.CreateRow(3);
            IRow r5 = s.CreateRow(4);

            //group row 2 to row 4
            s.GroupRow(1, 3);

            //group row 2 to row 3
            s.GroupRow(1, 2);

            //group column 1-3
            s.GroupColumn(1, 3);

            WriteToFile("GroupRowAndColumnInXls");
        }

        #endregion

        #region======= HideColumnAndRowInXls=========

        private void HideColumnAndRowInXls()
        {
            InitializeWorkbook();

            ISheet s = hssfworkbook.CreateSheet("Sheet1");
            IRow r1 = s.CreateRow(0);
            IRow r2 = s.CreateRow(1);
            IRow r3 = s.CreateRow(2);
            IRow r4 = s.CreateRow(3);
            IRow r5 = s.CreateRow(4);

            //hide IRow 2
            r2.ZeroHeight = true;

            //hide column C
            s.SetColumnHidden(2, true);

            WriteToFile("HideColumnAndRowInXls");
        }

        #endregion

        #region======= RepeatingRowsAndColumns=========

        private void RepeatingRowsAndColumns()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("first sheet");
            hssfworkbook.CreateSheet("second sheet");
            hssfworkbook.CreateSheet("third sheet");

            IFont boldFont = hssfworkbook.CreateFont();
            boldFont.FontHeightInPoints = 22;
            boldFont.Boldweight = (short) FontBoldWeight.Bold;

            ICellStyle boldStyle = hssfworkbook.CreateCellStyle();
            boldStyle.SetFont(boldFont);

            IRow row = sheet1.CreateRow(1);
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("This quick brown fox");
            cell.CellStyle = boldStyle;

            // Set the columns to repeat from column 0 to 2 on the first sheet
            hssfworkbook.SetRepeatingRowsAndColumns(0, 0, 2, -1, -1);
            // Set the rows to repeat from row 0 to 2 on the second sheet.
            hssfworkbook.SetRepeatingRowsAndColumns(1, -1, -1, 0, 2);
            // Set the the repeating rows and columns on the third sheet.
            hssfworkbook.SetRepeatingRowsAndColumns(2, 4, 5, 1, 2);

            WriteToFile("RepeatingRowsAndColumns");
        }

        #endregion

        #region======= SetWidthAndHeightInXls=========

        private void SetWidthAndHeightInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            //set the width of columns
            sheet1.SetColumnWidth(0, 50 * 256);
            sheet1.SetColumnWidth(1, 100 * 256);
            sheet1.SetColumnWidth(2, 150 * 256);

            //set the width of height
            sheet1.CreateRow(0).Height = 100 * 20;
            sheet1.CreateRow(1).Height = 200 * 20;
            sheet1.CreateRow(2).Height = 300 * 20;

            sheet1.DefaultRowHeightInPoints = 50;

            WriteToFile("SetWidthAndHeightInXls");
        }

        #endregion

        #region======= ShrinkToFitColumnInXls=========

        private void ShrinkToFitColumnInXls()
        {
            InitializeWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("Sheet1");
            IRow row = sheet.CreateRow(0);
            //create cell value
            ICell cell1 = row.CreateCell(0);
            cell1.SetCellValue("This is a test");
            //apply ShrinkToFit to cellstyle
            ICellStyle cellstyle1 = hssfworkbook.CreateCellStyle();
            cellstyle1.ShrinkToFit = true;
            cell1.CellStyle = cellstyle1;
            //create cell value
            row.CreateCell(1).SetCellValue("Hello World");
            row.GetCell(1).CellStyle = cellstyle1;

            WriteToFile("ShrinkToFitColumnInXls");
        }

        #endregion

        #region======= SplitAndFreezePanes=========

        private void SplitAndFreezePanes()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("new sheet");
            ISheet sheet2 = hssfworkbook.CreateSheet("second sheet");
            ISheet sheet3 = hssfworkbook.CreateSheet("third sheet");
            ISheet sheet4 = hssfworkbook.CreateSheet("fourth sheet");

            // Freeze just one row
            sheet1.CreateFreezePane(0, 1, 0, 1);
            // Freeze just one column
            sheet2.CreateFreezePane(1, 0, 1, 0);
            // Freeze the columns and rows (forget about scrolling position of the lower right quadrant).
            sheet3.CreateFreezePane(2, 2);
            // Create a split with the lower left side being the active quadrant
            sheet4.CreateSplitPane(2000, 2000, 0, 0, PanePosition.LowerLeft);

            WriteToFile("SplitAndFreezePanes");
        }

        #endregion
    }
}