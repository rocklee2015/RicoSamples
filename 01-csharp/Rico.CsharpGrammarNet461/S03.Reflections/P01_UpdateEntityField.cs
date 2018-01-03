using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
    public class P01_UpdateEntityField
    {
        [TestMethod]
        public void UpdateEnitityField_Return_New_Value()
        {
            Student oldStudent = new Student();
            oldStudent.Name = "Zhang San";
            oldStudent.Number = "1001";
            oldStudent.School = "Jiangnan University";
            oldStudent.Score = 87.98M;

            Student newStudent = new Student();
            newStudent.Name = "Li Si";
            newStudent.Score = 98.98M;

            Console.WriteLine("【Before】:");
            foreach (System.Reflection.PropertyInfo p in oldStudent.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", p.Name, p.GetValue(oldStudent, null));

            }

            foreach (System.Reflection.PropertyInfo p in newStudent.GetType().GetProperties())
            {
                if (p.GetValue(newStudent, null) != null)
                    p.SetValue(oldStudent, p.GetValue(newStudent, null), null);
            }
            
            Console.WriteLine("【After】:");
            foreach (System.Reflection.PropertyInfo p in oldStudent.GetType().GetProperties())
            {
                Console.WriteLine("{0}: {1}", p.Name, p.GetValue(oldStudent, null));

            }

            Assert.AreEqual("Li Si", newStudent.Name);
            Assert.AreEqual(98.98M, newStudent.Score);
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
