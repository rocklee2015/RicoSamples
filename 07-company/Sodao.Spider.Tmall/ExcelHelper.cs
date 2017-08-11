using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.Spider.Tmall
{
   public class ExcelHelper
    {
        #region 生成Excel
        /// <summary>
        /// 生成Excel
        /// </summary>
        public static void CreateExcel(DataTable dt, string path)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);//创建工作表

            #region 标题
            IRow row = sheet.CreateRow(0);//在工作表中添加一行
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);//在行中添加一列
                cell.SetCellValue(dt.Columns[i].ColumnName);//设置列的内容	 

                sheet.SetColumnWidth(i, 10000);
            }
            #endregion

            #region 填充数据
            for (int i = 1; i <= dt.Rows.Count; i++)//遍历DataTable行
            {
                DataRow dataRow = dt.Rows[i - 1];
                row = sheet.CreateRow(i);//在工作表中添加一行

                for (int j = 0; j < dt.Columns.Count; j++)//遍历DataTable列
                {
                    ICell cell = row.CreateCell(j);//在行中添加一列
                    cell.SetCellValue(dataRow[j].ToString());//设置列的内容	 
                }
            }
            #endregion

            #region 输出到Excel
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                byte[] bArr = ms.ToArray();
                fs.Write(bArr, 0, bArr.Length);
                fs.Flush();
            }
            #endregion

        }
        #endregion
    }
}
