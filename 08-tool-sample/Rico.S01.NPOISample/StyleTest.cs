using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace Rico.S01.NPOISample
{
    /// <summary>
    ///     设置EXCEL 字体，字体颜色，背景颜色，边框，对齐等
    /// </summary>
    [TestClass]
    public class StyleTest : BaseTest
    {
        public StyleTest()
        {
            _testResultDirectory = "StyleTestResult";
        }

        [TestMethod]
        public void Style()
        {
            SetBorderStyleInXls();

            ApplyFontInXls();

            ColorfulMatrixTable();

            CustomColorInXls();

            DisplayGridlinesInXls();

            FillBackgroundInXls();

            SetAlignmentInXls();

            SetBordersOfRegion();

            SetBorderStyleInXls();
            Assert.IsTrue(true);
        }

        #region======= ApplyFontInXls=========

        private void ApplyFontInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            //font style1: underlined, italic, red color, fontsize=20
            IFont font1 = hssfworkbook.CreateFont();
            font1.Color = HSSFColor.Red.Index;
            font1.IsItalic = true;
            font1.Underline = FontUnderlineType.Double;
            font1.FontHeightInPoints = 20;

            //bind font with style 1
            ICellStyle style1 = hssfworkbook.CreateCellStyle();
            style1.SetFont(font1);

            //font style2: strikeout line, green color, fontsize=15, fontname='宋体'
            IFont font2 = hssfworkbook.CreateFont();
            font2.Color = HSSFColor.OliveGreen.Index;
            font2.IsStrikeout = true;
            font2.FontHeightInPoints = 15;
            font2.FontName = "宋体";

            //bind font with style 2
            ICellStyle style2 = hssfworkbook.CreateCellStyle();
            style2.SetFont(font2);

            //apply font styles
            ICell cell1 = HSSFCellUtil.CreateCell(sheet1.CreateRow(1), 1, "Hello World!");
            cell1.CellStyle = style1;
            ICell cell2 = HSSFCellUtil.CreateCell(sheet1.CreateRow(3), 1, "早上好！");
            cell2.CellStyle = style2;

            //cell with rich text 
            ICell cell3 = sheet1.CreateRow(5).CreateCell(1);
            HSSFRichTextString richtext = new HSSFRichTextString("Microsoft OfficeTM");

            //apply font to "Microsoft Office"
            IFont font4 = hssfworkbook.CreateFont();
            font4.FontHeightInPoints = 12;
            richtext.ApplyFont(0, 16, font4);
            //apply font to "TM"
            IFont font3 = hssfworkbook.CreateFont();
            font3.TypeOffset = FontSuperScript.Super;
            font3.IsItalic = true;
            font3.Color = HSSFColor.Blue.Index;
            font3.FontHeightInPoints = 8;
            richtext.ApplyFont(16, 18, font3);

            cell3.SetCellValue(richtext);

            WriteToFile("ApplyFontInXls");
        }

        #endregion

        #region======= ColorfulMatrixTable=========

        private void ColorfulMatrixTable()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            var x = 1;
            for (var i = 0; i < 15; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (var j = 0; j < 15; j++)
                {
                    ICell cell = row.CreateCell(j);
                    if (x % 2 == 0)
                    {
                        //fill background with blue
                        ICellStyle style1 = hssfworkbook.CreateCellStyle();
                        style1.FillForegroundColor = HSSFColor.Blue.Index2;
                        style1.FillPattern = FillPattern.SolidForeground;
                        cell.CellStyle = style1;
                    }
                    else
                    {
                        //fill background with yellow
                        ICellStyle style1 = hssfworkbook.CreateCellStyle();
                        style1.FillForegroundColor = HSSFColor.Yellow.Index2;
                        style1.FillPattern = FillPattern.SolidForeground;
                        cell.CellStyle = style1;
                    }
                    x++;
                }
            }

            WriteToFile("ColorfulMatrixTable");
        }

        #endregion

        #region======= CustomColorInXls=========

        private void CustomColorInXls()
        {
            InitializeWorkbook();


            HSSFPalette palette = hssfworkbook.GetCustomPalette();
            palette.SetColorAtIndex(HSSFColor.Pink.Index, (byte) 255, (byte) 234, (byte) 222);
            //HSSFColor myColor = palette.AddColor((byte)253, (byte)0, (byte)0);

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            ICellStyle style1 = hssfworkbook.CreateCellStyle();
            style1.FillForegroundColor = HSSFColor.Pink.Index;
            style1.FillPattern = FillPattern.SolidForeground;
            sheet1.CreateRow(0).CreateCell(0).CellStyle = style1;

            WriteToFile("CustomColorInXls");
        }

        #endregion

        #region======= DisplayGridlinesInXls=========

        private void DisplayGridlinesInXls()
        {
            InitializeWorkbook();

            //sheet1 disables gridline
            ISheet s1 = hssfworkbook.CreateSheet("Sheet1");
            s1.DisplayGridlines = false;

            //sheet2 enables gridline
            ISheet s2 = hssfworkbook.CreateSheet("Sheet2");
            s2.DisplayGridlines = true;

            WriteToFile("DisplayGridlinesInXls");
        }

        #endregion

        #region======= FillBackgroundInXls=========

        private void FillBackgroundInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            //fill background
            ICellStyle style1 = hssfworkbook.CreateCellStyle();
            style1.FillForegroundColor = HSSFColor.Blue.Index;
            style1.FillPattern = FillPattern.BigSpots;
            style1.FillBackgroundColor = HSSFColor.Pink.Index;
            sheet1.CreateRow(0).CreateCell(0).CellStyle = style1;

            //fill background
            ICellStyle style2 = hssfworkbook.CreateCellStyle();
            style2.FillForegroundColor = HSSFColor.Yellow.Index;
            style2.FillPattern = FillPattern.AltBars;
            style2.FillBackgroundColor = HSSFColor.Rose.Index;
            sheet1.CreateRow(1).CreateCell(0).CellStyle = style2;

            //fill background
            ICellStyle style3 = hssfworkbook.CreateCellStyle();
            style3.FillForegroundColor = HSSFColor.Lime.Index;
            style3.FillPattern = FillPattern.LessDots;
            style3.FillBackgroundColor = HSSFColor.LightGreen.Index;
            sheet1.CreateRow(2).CreateCell(0).CellStyle = style3;

            //fill background
            ICellStyle style4 = hssfworkbook.CreateCellStyle();
            style4.FillForegroundColor = HSSFColor.Yellow.Index;
            style4.FillPattern = FillPattern.LeastDots;
            style4.FillBackgroundColor = HSSFColor.Rose.Index;
            sheet1.CreateRow(3).CreateCell(0).CellStyle = style4;

            //fill background
            ICellStyle style5 = hssfworkbook.CreateCellStyle();
            style5.FillForegroundColor = HSSFColor.LightBlue.Index;
            style5.FillPattern = FillPattern.Bricks;
            style5.FillBackgroundColor = HSSFColor.Plum.Index;
            sheet1.CreateRow(4).CreateCell(0).CellStyle = style5;

            //fill background
            ICellStyle style6 = hssfworkbook.CreateCellStyle();
            style6.FillForegroundColor = HSSFColor.SeaGreen.Index;
            style6.FillPattern = FillPattern.FineDots;
            style6.FillBackgroundColor = HSSFColor.White.Index;
            sheet1.CreateRow(5).CreateCell(0).CellStyle = style6;

            //fill background
            ICellStyle style7 = hssfworkbook.CreateCellStyle();
            style7.FillForegroundColor = HSSFColor.Orange.Index;
            style7.FillPattern = FillPattern.Diamonds;
            style7.FillBackgroundColor = HSSFColor.Orchid.Index;
            sheet1.CreateRow(6).CreateCell(0).CellStyle = style7;

            //fill background
            ICellStyle style8 = hssfworkbook.CreateCellStyle();
            style8.FillForegroundColor = HSSFColor.White.Index;
            style8.FillPattern = FillPattern.Squares;
            style8.FillBackgroundColor = HSSFColor.Red.Index;
            sheet1.CreateRow(7).CreateCell(0).CellStyle = style8;

            //fill background
            ICellStyle style9 = hssfworkbook.CreateCellStyle();
            style9.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style9.FillPattern = FillPattern.SparseDots;
            style9.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(8).CreateCell(0).CellStyle = style9;

            //fill background
            ICellStyle style10 = hssfworkbook.CreateCellStyle();
            style10.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style10.FillPattern = FillPattern.ThickBackwardDiagonals;
            style10.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(9).CreateCell(0).CellStyle = style10;

            //fill background
            ICellStyle style11 = hssfworkbook.CreateCellStyle();
            style11.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style11.FillPattern = FillPattern.ThickForwardDiagonals;
            style11.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(10).CreateCell(0).CellStyle = style11;

            //fill background
            ICellStyle style12 = hssfworkbook.CreateCellStyle();
            style12.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style12.FillPattern = FillPattern.ThickHorizontalBands;
            style12.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(11).CreateCell(0).CellStyle = style12;


            //fill background
            ICellStyle style13 = hssfworkbook.CreateCellStyle();
            style13.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style13.FillPattern = FillPattern.ThickVerticalBands;
            style13.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(12).CreateCell(0).CellStyle = style13;

            //fill background
            ICellStyle style14 = hssfworkbook.CreateCellStyle();
            style14.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style14.FillPattern = FillPattern.ThinBackwardDiagonals;
            style14.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(13).CreateCell(0).CellStyle = style14;

            //fill background
            ICellStyle style15 = hssfworkbook.CreateCellStyle();
            style15.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style15.FillPattern = FillPattern.ThinForwardDiagonals;
            style15.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(14).CreateCell(0).CellStyle = style15;

            //fill background
            ICellStyle style16 = hssfworkbook.CreateCellStyle();
            style16.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style16.FillPattern = FillPattern.ThinHorizontalBands;
            style16.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(15).CreateCell(0).CellStyle = style16;

            //fill background
            ICellStyle style17 = hssfworkbook.CreateCellStyle();
            style17.FillForegroundColor = HSSFColor.RoyalBlue.Index;
            style17.FillPattern = FillPattern.ThinVerticalBands;
            style17.FillBackgroundColor = HSSFColor.Yellow.Index;
            sheet1.CreateRow(16).CreateCell(0).CellStyle = style17;


            WriteToFile("FillBackgroundInXls");
        }

        #endregion

        #region======= SetAlignmentInXls=========

        private void SetAlignmentInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            //set the column width respectively
            sheet1.SetColumnWidth(0, 3000);
            sheet1.SetColumnWidth(1, 3000);
            sheet1.SetColumnWidth(2, 3000);

            for (var i = 1; i <= 10; i++)
            {
                //create the row
                IRow row = sheet1.CreateRow(i);
                //set height of the row
                row.HeightInPoints = 100;

                //create the first cell
                row.CreateCell(0).SetCellValue("Left");
                ICellStyle styleLeft = hssfworkbook.CreateCellStyle();
                styleLeft.Alignment = HorizontalAlignment.Left;
                styleLeft.VerticalAlignment = VerticalAlignment.Top;
                row.GetCell(0).CellStyle = styleLeft;
                //set indention for the text in the cell
                styleLeft.Indention = 3;

                //create the second cell
                row.CreateCell(1)
                    .SetCellValue("Center Hello World Hello WorldHello WorldHello WorldHello WorldHello World");
                ICellStyle styleMiddle = hssfworkbook.CreateCellStyle();
                styleMiddle.Alignment = HorizontalAlignment.Center;
                styleMiddle.VerticalAlignment = VerticalAlignment.Center;
                row.GetCell(1).CellStyle = styleMiddle;
                //wrap the text in the cell
                styleMiddle.WrapText = true;


                //create the third cell
                row.CreateCell(2).SetCellValue("Right");
                ICellStyle styleRight = hssfworkbook.CreateCellStyle();
                styleRight.Alignment = HorizontalAlignment.Justify;
                styleRight.VerticalAlignment = VerticalAlignment.Bottom;
                row.GetCell(2).CellStyle = styleRight;
            }

            WriteToFile("SetAlignmentInXls");
        }

        #endregion

        #region======= SetBorderStyleInXls=========

        private void SetBorderStyleInXls()
        {
            InitializeWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("new sheet");

            // Create a row and put some cells in it. Rows are 0 based.
            IRow row = sheet.CreateRow(1);

            // Create a cell and put a value in it.
            ICell cell = row.CreateCell(1);
            cell.SetCellValue(4);

            // Style the cell with borders all around.
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = HSSFColor.Black.Index;
            style.BorderLeft = BorderStyle.DashDotDot;
            style.LeftBorderColor = HSSFColor.Green.Index;
            style.BorderRight = BorderStyle.Hair;
            style.RightBorderColor = HSSFColor.Blue.Index;
            style.BorderTop = BorderStyle.MediumDashed;
            style.TopBorderColor = HSSFColor.Orange.Index;

            style.BorderDiagonal = BorderDiagonal.Forward;
            style.BorderDiagonalColor = HSSFColor.Gold.Index;
            style.BorderDiagonalLineStyle = BorderStyle.Medium;

            cell.CellStyle = style;
            // Create a cell and put a value in it.
            ICell cell2 = row.CreateCell(2);
            cell2.SetCellValue(5);
            ICellStyle style2 = hssfworkbook.CreateCellStyle();
            style2.BorderDiagonal = BorderDiagonal.Backward;
            style2.BorderDiagonalColor = HSSFColor.Red.Index;
            style2.BorderDiagonalLineStyle = BorderStyle.Medium;
            cell2.CellStyle = style2;

            WriteToFile("SetBorderStyleInXls");
        }

        #endregion

        #region======= SetBordersOfRegion=========

        private void SetBordersOfRegion()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            //create a common style
            ICellStyle blackBorder = hssfworkbook.CreateCellStyle();
            blackBorder.BorderBottom = BorderStyle.Thin;
            blackBorder.BorderLeft = BorderStyle.Thin;
            blackBorder.BorderRight = BorderStyle.Thin;
            blackBorder.BorderTop = BorderStyle.Thin;
            blackBorder.BottomBorderColor = HSSFColor.Black.Index;
            blackBorder.LeftBorderColor = HSSFColor.Black.Index;
            blackBorder.RightBorderColor = HSSFColor.Black.Index;
            blackBorder.TopBorderColor = HSSFColor.Black.Index;

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
                    ICell cell = row.CreateCell(iCol);
                    cell.CellFormula = formula;
                    //set the cellstyle to the cell
                    cell.CellStyle = blackBorder;
                }
            }

            WriteToFile("SetBordersOfRegion");
        }

        private static string GetCellPosition(int row, int col)
        {
            col = Convert.ToInt32('A') + col;
            row = row + 1;
            return (char) col + row.ToString();
        }

        #endregion
    }
}