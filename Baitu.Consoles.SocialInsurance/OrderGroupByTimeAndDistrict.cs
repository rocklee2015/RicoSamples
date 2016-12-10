using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitu.Consoles.SocialInsurance
{
    /// <summary>
    /// 根据时间，和区域分组订单信息
    /// </summary>
    public class OrderGroupByTimeAndDistrict
    {
        /// <summary>
        /// 首先根据时间进行分组;
        /// 再对于每个分组结果按照区域分组,然后汇总求费用总值
        /// </summary>
        public void Excute()
        {
            var orders = new List<Order>
            {
                new Order() {Distict = "莲花区", Fee = 19, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "莲花区", Fee = 20, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "莲花区", Fee = 21, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "莲花区", Fee = 22, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "莲花区", Fee = 23, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "莲花区", Fee = 24, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "清田区", Fee = 25, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "清田区", Fee = 26, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "清田区", Fee = 27, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "清田区", Fee = 28, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "清田区", Fee = 29, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "清田区", Fee = 30, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "西湖区", Fee = 31, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "西湖区", Fee = 32, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "西湖区", Fee = 33, CreateTime = new DateTime(2016, 12, 6)},
                new Order() {Distict = "西湖区", Fee = 34, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "西湖区", Fee = 35, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "西湖区", Fee = 36, CreateTime = new DateTime(2016, 12, 7)},
                new Order() {Distict = "余杭区", Fee = 37, CreateTime = new DateTime(2016, 12, 9)}
            };

            #region  第一种写法
            /*
            var timeGroups = (from a in orders
                orderby a.CreateTime
                group a by a.CreateTime
                into timeGroup
                select new OrderGroupTime
                {
                    CreateTime = timeGroup.Key,
                    Orders = timeGroup.ToList(),
                }).ToList();
            timeGroups.ForEach(timeGroup =>
            {
                var districtGroups = (from a in timeGroup.Orders
                    group a by a.Distict
                    into districGroup
                    select new
                    {
                        Name = districGroup.Key,
                        Total = districGroup.Sum(b => b.Fee)
                    }).ToList();
                Console.WriteLine("Key：{0}", timeGroup.CreateTime);
                districtGroups.ForEach(a =>
                {
                    Console.WriteLine("地区：{0},总数{1}", a.Name, a.Total);
                });
            });
            */
            #endregion

            var districts = orders.GroupBy(a => a.Distict).Select(a => a.Key).ToList();
            districts.ForEach(a => { Console.WriteLine("地区：{0}", a); });
            Console.WriteLine(string.Empty.PadLeft(30, '-') + "我是分割线");
            //第二种写法
            var timeGroupSecond = orders.OrderBy(a => a.CreateTime)
                                        .GroupBy(a => a.CreateTime)
                                        .Select(a => new { CreateTime = a.Key, Orders = a })
                                        .ToList();
            timeGroupSecond.ForEach(a =>
            {
                Console.WriteLine("Key：{0}", a.CreateTime);
                var tempGroup = a.Orders.GroupBy(b => b.Distict)
                                        .Select(b => new { Name = b.Key, Total = b.Sum(c => c.Fee) })
                                        .ToList();
                tempGroup.ForEach(b =>
                {
                    Console.WriteLine("地区：{0},总数{1}", b.Name, b.Total);
                });
            });
        }
    }
    public class Order
    {
        public DateTime CreateTime { get; set; }
        public string Distict { get; set; }
        public decimal Fee { get; set; }
        public List<Order> OrderList { get; set; }
    }

    public class OrderGroupTime
    {
        public DateTime CreateTime { get; set; }
        public List<Order> Orders { set; get; }
    }

    public class OrderDistrictGroup
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
    }

    public class DistrictSummary
    {
        public DateTime Time { get; set; }
        public List<string> Columns { get; set; } 
    }
}
