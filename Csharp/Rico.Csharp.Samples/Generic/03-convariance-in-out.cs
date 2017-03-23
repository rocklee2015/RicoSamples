using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.Csharp.Samples.Generic
{
    /// <summary>
    /// 协变-逆变 和 in out
    /// 
    /// url:http://www.cnblogs.com/qixuejia/p/4383068.html
    /// </summary>
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class _03_convariance_in_out
    {
        /*
         * 目前out 和in 关键字只能在接口和委托中使用
         * 
         */
        /// <summary>
        /// List 协变 失败
        /// </summary>
        [TestMethod]
        public void sonclass_convert_baseclass_using_List()
        {
            var stu = new Student();
            Person person = stu;// student 会隐式转换为 person-> 因为 student 继承 person

            var students = new List<Student>() { new Student() { Name = "rico", Age = 25,School = "ntvc"} };
            //List<Person> persons1 = students;// 编译器报错 -> 虽然student继承person,但List<Student> 不继承List<Person>
            List<Person> persons = students.Select(a => (Person)a).ToList();//所以需要逐一显示转换
            //List<Person> persons1 = students.Select(a => a as Person).ToList();和上一样
            Assert.AreEqual(persons.Count, 1);
        }
        /// <summary>
        /// IList 协变 失败
        /// </summary>
        [TestMethod]
        public void sonclass_convert_baseclass_using_IList()
        {
            var stu = new Student();
            Person person = stu;// student 会隐式转换为 person-> 因为 student 继承 person
            IList<Student> students = new List<Student>() { new Student() { Name = "rico", Age = 25, School = "ntvc" } };
            //IList<Person> persons = students;// 编译器报错
            IList<Person> persons = students.Select(a => (Person)a).ToList();
            Assert.AreEqual(persons.Count, 1);
        }

       /// <summary>
       /// IEnumerable 协变 成功
       /// </summary>
        [TestMethod]
        public void sonclass_convert_baseclass_using_IEnumerable()
        {
            IEnumerable<Student> student = new List<Student>() { new Student() { Name = "rico", Age = 25,School = "ntvc"} };
            IEnumerable<Person> persons = student;
            Assert.AreEqual(persons.Count(),1);
        }
    }
}
