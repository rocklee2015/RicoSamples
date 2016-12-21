using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.BootstrapSamples.Models
{
    public class DataSourceManage
    {
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public static IList<DepartmentModel> GetDepartments()
        {
            var depts = new List<DepartmentModel>();
            for (var i = 0; i < 50; i++)
            {
                var dept = new DepartmentModel
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = "销售部" + i,
                    Level = i.ToString(),
                    Desc = "暂无描述信息"
                };
                depts.Add(dept);
            }
            return depts;
        }

        public static IList<Report> GetReports()
        {
            var lstRes = new List<Report>();
            Random rand = new Random();
            for (var i = 0; i < 50; i++)
            {
                var oModel = new Report
                {
                    JanCount = rand.Next(10, 99),
                    FebCount = rand.Next(10, 99),
                    MarCount = rand.Next(10, 99),
                    AprCount = rand.Next(10, 99),
                    MayCount = rand.Next(10, 99),
                    JunCount = rand.Next(10, 99),
                    JulCount = rand.Next(10, 99)
                };
                ;
                oModel.AguCount = rand.Next(10, 99);
                oModel.SepCount = rand.Next(10, 99);
                oModel.OctCount = rand.Next(10, 99);
                oModel.NovCount = rand.Next(10, 99); ;
                oModel.DecCount = rand.Next(10, 99);
                oModel.FirstQuarter = oModel.JanCount + oModel.FebCount + oModel.MarCount;
                oModel.SecondQuarter = oModel.AprCount + oModel.MayCount + oModel.JunCount;
                oModel.ThirdQuarter = oModel.JulCount + oModel.AguCount + oModel.SepCount;
                oModel.ForthQuarter = oModel.OctCount + oModel.NovCount + oModel.DecCount;
                oModel.TotalCount = oModel.FirstQuarter + oModel.SecondQuarter + oModel.ThirdQuarter + oModel.ForthQuarter;
                lstRes.Add(oModel);

            }
            return lstRes;
        }
    }
}