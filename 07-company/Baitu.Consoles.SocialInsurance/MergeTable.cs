using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitu.Consoles.SocialInsurance
{
    public class MergeTable
    {
        public static void ExcuteMain()
        {
            var dataTable1 = new DataTable();
            dataTable1.Columns.Add("时间");
            dataTable1.Columns.Add("Price");
            for (int i = 0; i < 10; i++)
            {
                var row = dataTable1.NewRow();
                row["时间"] = $"2016-12-{30-i}";
                row["Price"] = i+1;
                dataTable1.Rows.Add(row);
            }
           

            var dataTable2 = new DataTable();
            dataTable2.Columns.Add("时间");
            dataTable2.Columns.Add("Price");
            for (int i = 0; i < 10; i++)
            {
                var row = dataTable1.NewRow();
                row["时间"] = $"2016-12-{25 - i}";
                row["Price"] = i + 1;
                dataTable2.Rows.Add(row);
            }
            var dataTable3 = new DataTable();
            dataTable3.Columns.Add("时间");
            dataTable3.Columns.Add("Price");
            for (int i = 0; i < 10; i++)
            {
                var row = dataTable1.NewRow();
                row["时间"] = $"2016-12-{22 - i}";
                row["Price"] = i + 1;
                dataTable3.Rows.Add(row);
            }
        }
    }
}
