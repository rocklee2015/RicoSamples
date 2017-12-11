using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S02.ReflectionSample
{
    /// <summary>
    /// 将字段不为空的字段更新
    /// </summary>
    public class S01_对象字段更新
    {
        public void Excute()
        {
            Student std1 = new Student();
            std1.Name = "Zhang San";
            std1.Number = "1001";
            std1.School = "Jiangnan University";
            std1.Score = 87.98M;

            Student std2 = new Student();
            std2.Name = "Li Si";
            std2.Score = 98.98M;

            Console.WriteLine("Before:");
            foreach (System.Reflection.PropertyInfo p in std1.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", p.Name, p.GetValue(std1, null));

            }

            foreach (System.Reflection.PropertyInfo p in std2.GetType().GetProperties())
            {
                if (p.GetValue(std2, null) != null)
                    p.SetValue(std1, p.GetValue(std2, null), null);
            }
            Console.WriteLine("After:");
            foreach (System.Reflection.PropertyInfo p in std1.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", p.Name, p.GetValue(std1, null));

            }
            Console.ReadKey();
        }

    }
    public class Student
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public string School { get; set; }

        public decimal Score { get; set; }
    }
}
