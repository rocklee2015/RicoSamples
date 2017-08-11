using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace Rico.S01.NPOISample.Common
{
    public class ExcelHelper
    {
        public static int GetSheetNumber(string outputFile)
        {
            var number = 0;
            try
            {
                var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
                number = hssfworkbook.NumberOfSheets;
            }
            catch (Exception exceptionMsg)
            {
                //wLog.Error(exceptionMsg.Message + "\r\n" + exceptionMsg.StackTrace.ToString() + "\r\n");
            }
            return number;
        }

        public static ArrayList GetSheetName(string outputFile)
        {
            var arrayList = new ArrayList();
            try
            {
                var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
                for (var i = 0; i < hssfworkbook.NumberOfSheets; i++)
                    arrayList.Add(hssfworkbook.GetSheetName(i));
            }
            catch (Exception exception)
            {
                //wl.WriteLogs(exception.ToString());
            }
            return arrayList;
        }

        public static bool isNumeric(string message, out double result)
        {
            var rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            return false;
        }
        //protected static readonly log4net.ILog wLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region 程序集特性访问器

        public static string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                    return "";
                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                    return "";
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                    return "";
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                    return "";
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        #endregion

        #region 右击文件 属性信息

        private static void SetDocumentSummaryInformation(HSSFWorkbook workbook, string Company, string Author,
            string ApplicationName, string LastAuthor, string Comments, string Title, string Subject,
            DateTime CreateDateTime)
        {
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = Company; //填加xls公司信息
            workbook.DocumentSummaryInformation = dsi;
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Author = Author; //填加xls文件作者信息
            si.ApplicationName = ApplicationName; //填加xls文件创建程序信息
            si.LastAuthor = LastAuthor; //填加xls文件最后保存者信息
            si.Comments = Comments; //填加xls文件说明信息
            si.Title = Title; //填加xls文件标题信息
            si.Subject = Subject; //填加文件主题信息
            si.CreateDateTime = CreateDateTime;
            workbook.SummaryInformation = si;
        }

        private static void SetDocumentSummaryInformation(HSSFWorkbook workbook)
        {
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = AssemblyCompany; //填加xls公司信息
            workbook.DocumentSummaryInformation = dsi;
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Author = AssemblyCopyright; //填加xls文件作者信息
            si.ApplicationName = "NPOI1.25"; //填加xls文件创建程序信息
            si.LastAuthor = AssemblyVersion; //填加xls文件最后保存者信息
            si.Comments = AssemblyDescription; //填加xls文件说明信息
            si.Title = AssemblyProduct; //填加xls文件标题信息
            si.Subject = AssemblyTitle; //填加文件主题信息
            si.CreateDateTime = DateTime.Now;
            workbook.SummaryInformation = si;
        }

        #endregion

        #region 从datatable中将数据导出到excel

        /// <summary>
        ///     DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        private static MemoryStream ExportDataTable(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;
            SetDocumentSummaryInformation(workbook);

            HSSFCellStyle dateStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat format = workbook.CreateDataFormat() as HSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            var arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName).Length;
            for (var i = 0; i < dtSource.Rows.Count; i++)
            for (var j = 0; j < dtSource.Columns.Count; j++)
            {
                var intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                if (intTemp > arrColWidth[j])
                    arrColWidth[j] = intTemp;
            }
            var rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                        sheet = workbook.CreateSheet() as HSSFSheet;

                    #region 表头及样式

                    {
                        HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        headStyle.Alignment = HorizontalAlignment.Center;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                    }

                    #endregion


                    #region 列头及样式

                    {
                        HSSFRow headerRow = sheet.CreateRow(1) as HSSFRow;
                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        headStyle.Alignment = HorizontalAlignment.Center;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }

                    #endregion

                    rowIndex = 2;
                }

                #endregion

                #region 填充内容

                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
                    var drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {
                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);
                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            var boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            var intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }

                #endregion

                rowIndex++;
            }
            using (var ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }


        /// <summary>
        ///     DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void ExportDataTableToExcel(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (var ms = ExportDataTable(dtSource, strHeaderText))
            {
                using (var fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    var data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        #endregion

        #region 从excel中将数据导出到datatable

        /// <summary>
        ///     读取excel
        ///     默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable ImportExcelToDataTable(string strFileName)
        {
            var dt = new DataTable();
            HSSFWorkbook hssfworkbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = hssfworkbook.GetSheetAt(0) as HSSFSheet;
            dt = ImportDataTable(sheet, 0, true);
            return dt;
        }

        /// <summary>
        ///     读取EXCEL
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="SheetIndex">读取的起始行</param>
        /// <returns></returns>
        public static DataTable ImportExcelToDataTable(string strFileName, int SheetIndex)
        {
            var dt = new DataTable();
            HSSFWorkbook hssfworkbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = hssfworkbook.GetSheetAt(0) as HSSFSheet;
            dt = ImportDataTable(sheet, SheetIndex, true);
            return dt;
        }

        /// <summary>
        ///     读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExcelToDataTable(string strFileName, string SheetName, int HeaderRowIndex)
        {
            HSSFWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = workbook.GetSheet(SheetName) as HSSFSheet;
            var table = new DataTable();
            table = ImportDataTable(sheet, HeaderRowIndex, true);
            //ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        ///     读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet序号</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExcelToDataTable(string strFileName, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = workbook.GetSheetAt(SheetIndex) as HSSFSheet;
            var table = new DataTable();
            table = ImportDataTable(sheet, HeaderRowIndex, true);
            //ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        ///     读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExcelToDataTable(string strFileName, string SheetName, int HeaderRowIndex,
            bool needHeader)
        {
            HSSFWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = workbook.GetSheet(SheetName) as HSSFSheet;
            var table = new DataTable();
            table = ImportDataTable(sheet, HeaderRowIndex, needHeader);
            //ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        ///     读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet序号</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExcelToDataTable(string strFileName, int SheetIndex, int HeaderRowIndex,
            bool needHeader)
        {
            HSSFWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = workbook.GetSheetAt(SheetIndex) as HSSFSheet;
            var table = new DataTable();
            table = ImportDataTable(sheet, HeaderRowIndex, needHeader);
            //ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        ///     将指定的sheet中的数据导出到datatable中
        /// </summary>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        private static DataTable ImportDataTable(HSSFSheet sheet, int HeaderRowIndex, bool needHeader)
        {
            var table = new DataTable();
            HSSFRow headerRow;
            int cellCount;
            try
            {
                if (HeaderRowIndex < 0 || !needHeader)
                {
                    headerRow = sheet.GetRow(0) as HSSFRow;
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                    {
                        var column = new DataColumn(Convert.ToString(i));
                        table.Columns.Add(column);
                    }
                }
                else
                {
                    headerRow = sheet.GetRow(HeaderRowIndex) as HSSFRow;
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                        if (headerRow.GetCell(i) == null)
                        {
                            if (table.Columns.IndexOf(Convert.ToString(i)) > 0)
                            {
                                var column = new DataColumn(Convert.ToString("重复列名" + i));
                                table.Columns.Add(column);
                            }
                            else
                            {
                                var column = new DataColumn(Convert.ToString(i));
                                table.Columns.Add(column);
                            }
                        }
                        else if (table.Columns.IndexOf(headerRow.GetCell(i).ToString()) > 0)
                        {
                            var column = new DataColumn(Convert.ToString("重复列名" + i));
                            table.Columns.Add(column);
                        }
                        else
                        {
                            var column = new DataColumn(headerRow.GetCell(i).ToString());
                            table.Columns.Add(column);
                        }
                }
                int rowCount = sheet.LastRowNum;
                for (var i = HeaderRowIndex + 1; i <= sheet.LastRowNum; i++)
                {
                    HSSFRow row;
                    if (sheet.GetRow(i) == null)
                        row = sheet.CreateRow(i) as HSSFRow;
                    else
                        row = sheet.GetRow(i) as HSSFRow;

                    var dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j <= cellCount; j++)
                        if (row.GetCell(j) != null)
                            SwitchCellType(row, dataRow, j);
                    table.Rows.Add(dataRow);
                }
            }
            catch (Exception exceptionMsg)
            {
                //wLog.Error(exceptionMsg.Message + "\r\n" + exceptionMsg.StackTrace.ToString() + "\r\n");
            }
            return table;
        }

        private static void SwitchCellType(HSSFRow row, DataRow dataRow, int j)
        {
            switch (row.GetCell(j).CellType)
            {
                case CellType.String:
                    string str = row.GetCell(j).StringCellValue;
                    if (str != null && str.Length > 0)
                        dataRow[j] = str;
                    else
                        dataRow[j] = null;
                    break;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(row.GetCell(j)))
                        dataRow[j] = DateTime.FromOADate(row.GetCell(j).NumericCellValue);
                    else
                        dataRow[j] = Convert.ToDouble(row.GetCell(j).NumericCellValue);
                    break;
                case CellType.Boolean:
                    dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                    break;
                case CellType.Error:
                    dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                    break;
                case CellType.Formula:
                    switch (row.GetCell(j).CachedFormulaResultType)
                    {
                        case CellType.String:
                            string strFORMULA = row.GetCell(j).StringCellValue;
                            if (strFORMULA != null && strFORMULA.Length > 0)
                                dataRow[j] = strFORMULA;
                            else
                                dataRow[j] = null;
                            break;
                        case CellType.Numeric:
                            dataRow[j] = Convert.ToString(row.GetCell(j).NumericCellValue);
                            break;
                        case CellType.Boolean:
                            dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                            break;
                        case CellType.Error:
                            dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                            break;
                        default:
                            dataRow[j] = "";
                            break;
                    }
                    break;
                default:
                    dataRow[j] = "";
                    break;
            }
        }

        #endregion

        #region 更新excel中的数据

        /// <summary>
        ///     更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluid">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, string[] updateData, int coluid, int rowid)
        {
            var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (var i = 0; i < updateData.Length; i++)
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                        sheet1.CreateRow(i + rowid);
                    if (sheet1.GetRow(i + rowid).GetCell(coluid) == null)
                        sheet1.GetRow(i + rowid).CreateCell(coluid);

                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData[i]);
                }
                catch (Exception ex)
                {
                    // wl.WriteLogs(ex.ToString());
                    throw;
                }
            try
            {
                readfile.Close();
                var writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                // wl.WriteLogs(ex.ToString());
            }
        }

        /// <summary>
        ///     更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluids">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, string[][] updateData, int[] coluids,
            int rowid)
        {
            var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            readfile.Close();
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (var j = 0; j < coluids.Length; j++)
            for (var i = 0; i < updateData[j].Length; i++)
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                        sheet1.CreateRow(i + rowid);
                    if (sheet1.GetRow(i + rowid).GetCell(coluids[j]) == null)
                        sheet1.GetRow(i + rowid).CreateCell(coluids[j]);
                    sheet1.GetRow(i + rowid).GetCell(coluids[j]).SetCellValue(updateData[j][i]);
                }
                catch (Exception ex)
                {
                    // wl.WriteLogs(ex.ToString());
                }
            try
            {
                var writefile = new FileStream(outputFile, FileMode.Create);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                //wl.WriteLogs(ex.ToString());
            }
        }

        /// <summary>
        ///     更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluid">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, double[] updateData, int coluid, int rowid)
        {
            var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (var i = 0; i < updateData.Length; i++)
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                        sheet1.CreateRow(i + rowid);
                    if (sheet1.GetRow(i + rowid).GetCell(coluid) == null)
                        sheet1.GetRow(i + rowid).CreateCell(coluid);

                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData[i]);
                }
                catch (Exception ex)
                {
                    //wl.WriteLogs(ex.ToString());
                    throw;
                }
            try
            {
                readfile.Close();
                var writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                //wl.WriteLogs(ex.ToString());
            }
        }

        /// <summary>
        ///     更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluids">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, double[][] updateData, int[] coluids,
            int rowid)
        {
            var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            readfile.Close();
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (var j = 0; j < coluids.Length; j++)
            for (var i = 0; i < updateData[j].Length; i++)
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                        sheet1.CreateRow(i + rowid);
                    if (sheet1.GetRow(i + rowid).GetCell(coluids[j]) == null)
                        sheet1.GetRow(i + rowid).CreateCell(coluids[j]);
                    sheet1.GetRow(i + rowid).GetCell(coluids[j]).SetCellValue(updateData[j][i]);
                }
                catch (Exception ex)
                {
                    //wl.WriteLogs(ex.ToString());
                }
            try
            {
                var writefile = new FileStream(outputFile, FileMode.Create);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                //wl.WriteLogs(ex.ToString());
            }
        }

        #endregion
    }
}