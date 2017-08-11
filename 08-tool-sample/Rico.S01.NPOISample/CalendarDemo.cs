using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Rico.S01.NPOISample
{
    [TestClass]
    public class CalendarDemo
    {
        private static readonly string[] days =
        {
            "Sunday", "Monday", "Tuesday",
            "Wednesday", "Thursday", "Friday", "Saturday"
        };

        private static readonly string[] months =
        {
            "January", "February", "March", "April", "May", "June", "July", "August",
            "September", "October", "November", "December"
        };

        [TestMethod]
        public void CalendarDemoTest()
        {
            string[] args = {"-"};
            //Calendar calendar = Calendar.getInstance();
            var dt = DateTime.Now;
            var xlsx = false;
            for (var i = 0; i < args.Length; i++)
                if (args[i][0] == '-')
                    xlsx = args[i].Equals("-xlsx");
                else
                    dt = new DateTime(dt.Year, int.Parse(args[i]), dt.Day);
            var year = dt.Year;

            var wb = xlsx ? new XSSFWorkbook() : new HSSFWorkbook() as IWorkbook;

            var styles = createStyles(wb);
            DateTime dtM;
            for (var month = 0; month < 12; month++)
            {
                dtM = new DateTime(dt.Year, month + 1, 1);
                //calendar.set(Calendar.MONTH, month);
                //calendar.set(Calendar.DAY_OF_MONTH, 1);
                //create a sheet for each month
                var sheet = wb.CreateSheet(months[month]);

                //turn off gridlines
                sheet.DisplayGridlines = false;
                sheet.IsPrintGridlines = false;
                sheet.FitToPage = true;
                sheet.HorizontallyCenter = true;
                var printSetup = sheet.PrintSetup;
                printSetup.Landscape = true;

                //the following three statements are required only for HSSF
                sheet.Autobreaks = true;
                printSetup.FitHeight = 1;
                printSetup.FitWidth = 1;

                //the header row: centered text in 48pt font
                var headerRow = sheet.CreateRow(0);
                headerRow.HeightInPoints = 80;
                var titleCell = headerRow.CreateCell(0);
                titleCell.SetCellValue(months[month] + " " + year);
                titleCell.CellStyle = styles["title"];
                sheet.AddMergedRegion(CellRangeAddress.ValueOf("$A$1:$N$1"));

                //header with month titles
                var monthRow = sheet.CreateRow(1);
                for (var i = 0; i < days.Length; i++)
                {
                    //set column widths, the width is measured in units of 1/256th of a character width
                    sheet.SetColumnWidth(i * 2, 5 * 256); //the column is 5 characters wide
                    sheet.SetColumnWidth(i * 2 + 1, 13 * 256); //the column is 13 characters wide
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, i * 2, i * 2 + 1));
                    var monthCell = monthRow.CreateCell(i * 2);
                    monthCell.SetCellValue(days[i]);
                    monthCell.CellStyle = styles["month"];
                }

                int cnt = 1, day = 1;
                var rownum = 2;
                for (var j = 0; j < 6; j++)
                {
                    var row = sheet.CreateRow(rownum++);
                    row.HeightInPoints = 100;
                    for (var i = 0; i < days.Length; i++)
                    {
                        var dayCell_1 = row.CreateCell(i * 2);
                        var dayCell_2 = row.CreateCell(i * 2 + 1);

                        var day_of_week = (int) dtM.DayOfWeek;
                        if (cnt >= day_of_week && dtM.Month == month + 1)
                        {
                            dayCell_1.SetCellValue(day);
                            //calendar.set(Calendar.DAY_OF_MONTH, ++day);
                            dtM.AddDays(++day);

                            if (i == 0 || i == days.Length - 1)
                            {
                                dayCell_1.CellStyle = styles["weekend_left"];
                                dayCell_2.CellStyle = styles["weekend_right"];
                            }
                            else
                            {
                                dayCell_1.CellStyle = styles["workday_left"];
                                dayCell_2.CellStyle = styles["workday_right"];
                            }
                        }
                        else
                        {
                            dayCell_1.CellStyle = styles["grey_left"];
                            dayCell_2.CellStyle = styles["grey_right"];
                        }
                        cnt++;
                    }
                    if (dtM.Month > month + 1) break;
                }
            }

            // Write the output to a file
            var file = "CalendarDemo.xls";
            if (wb is XSSFWorkbook) file += "x";
            var out1 = new FileStream(file, FileMode.Create);
            wb.Write(out1);
            out1.Close();
        }

        /**
     * cell styles used for formatting calendar sheets
     */
        private static Dictionary<string, ICellStyle> createStyles(IWorkbook wb)
        {
            var styles = new Dictionary<string, ICellStyle>();

            var borderColor = IndexedColors.Grey50Percent.Index;

            ICellStyle style;
            var titleFont = wb.CreateFont();
            titleFont.FontHeightInPoints = 48;
            titleFont.Color = IndexedColors.DarkBlue.Index;
            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            style.SetFont(titleFont);
            styles.Add("title", style);

            var monthFont = wb.CreateFont();
            monthFont.FontHeightInPoints = 12;
            monthFont.Color = IndexedColors.White.Index;
            monthFont.Boldweight = (short) FontBoldWeight.Bold;
            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            style.FillForegroundColor = IndexedColors.DarkBlue.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(monthFont);
            styles.Add("month", style);

            var dayFont = wb.CreateFont();
            dayFont.FontHeightInPoints = 14;
            dayFont.Boldweight = (short) FontBoldWeight.Bold;
            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Left;
            style.VerticalAlignment = VerticalAlignment.Top;
            style.FillForegroundColor = IndexedColors.LightCornflowerBlue.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.BorderLeft = BorderStyle.Thin;
            style.LeftBorderColor = borderColor;
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = borderColor;
            style.SetFont(dayFont);
            styles.Add("weekend_left", style);

            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Top;
            style.FillForegroundColor = IndexedColors.LightCornflowerBlue.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.BorderRight = BorderStyle.Thin;
            style.RightBorderColor = borderColor;
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = borderColor;
            styles.Add("weekend_right", style);

            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Left;
            style.VerticalAlignment = VerticalAlignment.Top;
            style.BorderLeft = BorderStyle.Thin;
            style.FillForegroundColor = IndexedColors.White.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.LeftBorderColor = borderColor;
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = borderColor;
            style.SetFont(dayFont);
            styles.Add("workday_left", style);

            style = wb.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Top;
            style.FillForegroundColor = IndexedColors.White.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.BorderRight = BorderStyle.Thin;
            style.RightBorderColor = borderColor;
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = borderColor;
            styles.Add("workday_right", style);

            style = wb.CreateCellStyle();
            style.BorderLeft = BorderStyle.Thin;
            style.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = borderColor;
            styles.Add("grey_left", style);

            style = wb.CreateCellStyle();
            style.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.BorderRight = BorderStyle.Thin;
            style.RightBorderColor = borderColor;
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = borderColor;
            styles.Add("grey_right", style);

            return styles;
        }
    }
}