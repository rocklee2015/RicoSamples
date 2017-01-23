using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HPSF;
using NPOI.HSSF.Extractor;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Rico.NPOISample.Common;

namespace Rico.NPOISample
{
    [TestClass]
    public  class CellAndTextTest:BaseTest
    {
        public CellAndTextTest()
        {
            _testResultDirectory = "CellAndTextTestResult";
        }

        [TestMethod]
        public void AddHyperLinkInXls()
        {
            InitializeWorkbook();

            ////cell style for hyperlinks
            ////by default hyperlinks are blue and underlined
            ICellStyle hlink_style = hssfworkbook.CreateCellStyle();
            IFont hlink_font = hssfworkbook.CreateFont();
            hlink_font.Underline = FontUnderlineType.Single;
            hlink_font.Color = HSSFColor.Blue.Index;
            hlink_style.SetFont(hlink_font);

            ICell cell;
            ISheet sheet = hssfworkbook.CreateSheet("Hyperlinks");

            //URL
            cell = sheet.CreateRow(0).CreateCell(0);
            cell.SetCellValue("URL Link");
            HSSFHyperlink link = new HSSFHyperlink(HyperlinkType.Url);
            link.Address = ("http://poi.apache.org/");
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);

            //link to a file in the current directory
            cell = sheet.CreateRow(1).CreateCell(0);
            cell.SetCellValue("File Link");
            link = new HSSFHyperlink(HyperlinkType.File);
            link.Address = ("link1.xls");
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);

            //e-mail link
            cell = sheet.CreateRow(2).CreateCell(0);
            cell.SetCellValue("Email Link");
            link = new HSSFHyperlink(HyperlinkType.Email);
            //note, if subject contains white spaces, make sure they are url-encoded
            link.Address = ("mailto:poi@apache.org?subject=Hyperlinks");
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);

            //link to a place in this workbook

            //Create a target sheet and cell
            ISheet sheet2 = hssfworkbook.CreateSheet("Target ISheet");
            sheet2.CreateRow(0).CreateCell(0).SetCellValue("Target ICell");

            cell = sheet.CreateRow(3).CreateCell(0);
            cell.SetCellValue("Worksheet Link");
            link = new HSSFHyperlink(HyperlinkType.Document);
            link.Address = ("'Target ISheet'!A1");
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);

            WriteToFile("AddHyperLinkInXls");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void CopyRowsAndCellsInXls()
        {
            var copyFilePath = GetTestFile("CopyRowsAndCellsInXls-Source.xls");

            InitializeWorkbook(copyFilePath);

            ISheet s = hssfworkbook.GetSheetAt(0);

            ICell cell = s.GetRow(4).GetCell(1);
            cell.CopyCellTo(3); //copy B5 to D5

            IRow c = s.GetRow(3);
            c.CopyCell(0, 1);   //copy A4 to B4

            s.CopyRow(0, 1);     //copy row A to row B, original row B will be moved to row C automatically
            WriteToFile("CopyRowsAndCellsInXls");
        }
        [TestMethod]
        public void CreateDropDownListCellInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            ISheet sheet2 = hssfworkbook.CreateSheet("Sheet2");
            //create three items in Sheet2
            IRow row0 = sheet2.CreateRow(0);
            ICell cell0 = row0.CreateCell(4);
            cell0.SetCellValue("Product1");

            row0 = sheet2.CreateRow(1);
            cell0 = row0.CreateCell(4);
            cell0.SetCellValue("Product2");

            row0 = sheet2.CreateRow(2);
            cell0 = row0.CreateCell(4);
            cell0.SetCellValue("Product3");


            CellRangeAddressList rangeList = new CellRangeAddressList();

            //add the data validation to the first column (1-100 rows) 
            rangeList.AddCellRangeAddress(new CellRangeAddress(1, 100, 0, 0));
            DVConstraint dvconstraint = DVConstraint.CreateFormulaListConstraint("Sheet2!$E1:$E3");
            HSSFDataValidation dataValidation = new
                    HSSFDataValidation(rangeList, dvconstraint);
            //add the data validation to sheet1
            ((HSSFSheet)sheet1).AddValidationData(dataValidation);

            WriteToFile("CreateDropDownListCellInXls");
        }
        [TestMethod]
        public void ExtractStringsFromXls()
        {
            HSSFWorkbook workbook = HSSFTestDataSamples.OpenSampleWorkbook(GetTestFile("ExtractStringsFromXls.xls"));
            ExcelExtractor extractor = new ExcelExtractor(workbook);
            Console.Write(extractor.Text);
        }
        [TestMethod]
        public void RotateTextInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            //a valid rotate value is from -90 - 90
            int x = -90;
            for (int i = 1; i <= 13; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < 13; j++)
                {
                    //set the value
                    row.CreateCell(j).SetCellValue(x);
                    //set the style
                    ICellStyle style = hssfworkbook.CreateCellStyle();
                    style.Rotation = (short)x;
                    row.GetCell(j).CellStyle = style;
                    //increase x
                    x++;
                }
            }

            WriteToFile("RotateTextInXls");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void SetActiveCellRangeInXls()
        {
            InitializeWorkbook();
            //use HSSFCell.SetAsActiveCell() to select B6 as the active column
            ISheet sheet1 = hssfworkbook.CreateSheet("ISheet A");
            CreateCellArray(sheet1);
            sheet1.GetRow(5).GetCell(1).SetAsActiveCell();
            //set TopRow and LeftCol to make B6 the first cell in the visible area
            sheet1.TopRow = 5;
            sheet1.LeftCol = 1;

            //use ISheet.SetActiveCell(), the sheet can be empty
            ISheet sheet2 = hssfworkbook.CreateSheet("ISheet B");
            sheet2.SetActiveCell(1, 5);

            //use ISheet.SetActiveCellRange to select a cell range
            ISheet sheet3 = hssfworkbook.CreateSheet("ISheet C");
            CreateCellArray(sheet3);
            sheet3.SetActiveCellRange(2, 20, 1, 50);
            //set the ISheet C as the active sheet
            hssfworkbook.SetActiveSheet(2);

            //use ISheet.SetActiveCellRange to select multiple cell ranges
            ISheet sheet4 = hssfworkbook.CreateSheet("ISheet D");
            CreateCellArray(sheet4);
            List<CellRangeAddress8Bit> cellranges = new List<CellRangeAddress8Bit>();
            cellranges.Add(new CellRangeAddress8Bit(1, 5, 10, 100));
            cellranges.Add(new CellRangeAddress8Bit(6, 7, 8, 9));
            sheet4.SetActiveCellRange(cellranges, 1, 6, 9);

            WriteToFile("SetActiveCellRangeInXls");
            Assert.IsTrue(true);

        }
        static void CreateCellArray(ISheet sheet)
        {
            for (int i = 0; i < 300; i++)
            {
                IRow row = sheet.CreateRow(i);
                for (int j = 0; j < 150; j++)
                {
                    ICell cell = row.CreateCell(j);
                    cell.SetCellValue(i * j);
                }
            }
        }
        [TestMethod]
        public void SetCellCommentInXls()
        {
            InitializeWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("ICell comments in POI HSSF");

            // Create the drawing patriarch. This is the top level container for all shapes including cell comments.
            IDrawing patr = (HSSFPatriarch)sheet.CreateDrawingPatriarch();

            //Create a cell in row 3
            ICell cell1 = sheet.CreateRow(3).CreateCell(1);
            cell1.SetCellValue(new HSSFRichTextString("Hello, World"));

            //anchor defines size and position of the comment in worksheet
            IComment comment1 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 4, 2, 6, 5));

            // set text in the comment
            comment1.String = (new HSSFRichTextString("We can set comments in POI"));

            //set comment author.
            //you can see it in the status bar when moving mouse over the commented cell
            comment1.Author = ("Apache Software Foundation");

            // The first way to assign comment to a cell is via HSSFCell.SetCellComment method
            cell1.CellComment = (comment1);

            //Create another cell in row 6
            ICell cell2 = sheet.CreateRow(6).CreateCell(1);
            cell2.SetCellValue(36.6);


            HSSFComment comment2 = (HSSFComment)patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 4, 8, 6, 11));
            //modify background color of the comment
            comment2.SetFillColor(204, 236, 255);

            HSSFRichTextString str = new HSSFRichTextString("Normal body temperature");

            //apply custom font to the text in the comment
            IFont font = hssfworkbook.CreateFont();
            font.FontName = ("Arial");
            font.FontHeightInPoints = 10;
            font.Boldweight = (short)FontBoldWeight.Bold;
            font.Color = HSSFColor.Red.Index;
            str.ApplyFont(font);

            comment2.String = str;
            comment2.Visible = true; //by default comments are hidden. This one is always visible.

            comment2.Author = "Bill Gates";

            /**
             * The second way to assign comment to a cell is to implicitly specify its row and column.
             * Note, it is possible to set row and column of a non-existing cell.
             * It works, the commnet is visible.
             */
            comment2.Row = 6;
            comment2.Column = 1;

            WriteToFile("SetCellCommentInXls");
            Assert.IsTrue(true);

        }
        [TestMethod]
        public void SetCellValuesInXls()
        {
            InitializeWorkbook();

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

            WriteToFile("SetCellValuesInXls");
            Assert.IsTrue(true);

        }
        [TestMethod]
        public void SetDateCellInXls()
        {
            InitializeWorkbook();

            ISheet sheet = hssfworkbook.CreateSheet("new sheet");
            // Create a row and put some cells in it. Rows are 0 based.
            IRow row = sheet.CreateRow(0);

            // Create a cell and put a date value in it.  The first cell is not styled as a date.
            ICell cell = row.CreateCell(0);
            cell.SetCellValue(DateTime.Now);

            // we style the second cell as a date (and time).  It is important to Create a new cell style from the workbook
            // otherwise you can end up modifying the built in style and effecting not only this cell but other cells.
            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();

            // Perhaps this may only works for Chinese date, I don't have english office on hand
            cellStyle.DataFormat = hssfworkbook.CreateDataFormat().GetFormat("[$-409]h:mm:ss AM/PM;@");
            cell.CellStyle = cellStyle;

            //set chinese date format
            ICell cell2 = row.CreateCell(1);
            cell2.SetCellValue(new DateTime(2008, 5, 5));
            ICellStyle cellStyle2 = hssfworkbook.CreateCellStyle();
            IDataFormat format = hssfworkbook.CreateDataFormat();
            cellStyle2.DataFormat = format.GetFormat("yyyy年m月d日");
            cell2.CellStyle = cellStyle2;

            ICell cell3 = row.CreateCell(2);
            cell3.CellFormula = "DateValue(\"2005-11-11 11:11:11\")";
            ICellStyle cellStyle3 = hssfworkbook.CreateCellStyle();
            cellStyle3.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
            cell3.CellStyle = cellStyle3;

            WriteToFile("SetDateCellInXls");
            Assert.IsTrue(true);

        }
        [TestMethod]
        public void UseNewlinesInCellsInXls()
        {
            InitializeWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

            //use newlines in cell
            IRow row1 = sheet1.CreateRow(0);
            ICell cell1 = row1.CreateCell(0);

            //to enable newlines you need set a cell styles with wrap=true
            ICellStyle cs = hssfworkbook.CreateCellStyle();
            cs.WrapText = true;
            cell1.CellStyle = cs;

            //increase row height to accomodate two lines of text
            row1.HeightInPoints = 10 * sheet1.DefaultRowHeightInPoints;
            cell1.SetCellValue("This is a \n Hello \n World!");
            WriteToFile("UseNewlinesInCellsInXls");
            Assert.IsTrue(true);

        }
    }
}
