using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S01.Generic
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class _01_generic_convert
    {
        
        #region Cast
        /// <summary>
        /// cast 协变 成功
        /// </summary>
        [TestMethod]
        public void sonclass_convert_baseclass_return_two_item_using_cast()
        {
            var students = new List<Student>()
            {
                new Student() { Name = "rico",Age = 25},
                new Student() { Name = "rock",Age = 24}
            };
            var persons = students.Cast<Person>().ToList();
            Assert.AreEqual(persons.Count, 2);
        }
        /// <summary>
        /// cast 逆变 invalidcast 异常
        /// </summary>
        [TestMethod]
        public void baseclass_convert_sonclass_return_null_using_cast()
        {
            var persons = new List<Person>()
            {
                new Person() { Name = "rico",Age = 25},
                new Person() { Name = "rock",Age = 24}
            };
            var sutdents = persons.Cast<Student>().ToList();
            Assert.IsNull(sutdents);
        }
        #endregion
        #region As
        /// <summary>
        /// as 协变 成功
        /// </summary>
        [TestMethod]
        public void sonclass_convert_baseclass_return_two_item_using_as()
        {
            var students = new List<Student>()
            {
                new Student() { Name = "rico",Age = 25},
                new Student() { Name = "rock",Age = 24}
            };
            var persons = students.Select(a => a as Person).ToList();
            Assert.AreEqual(persons.Count, 2);
        }

        /// <summary>
        /// as 逆变 可以转换 但都是空值
        /// </summary>
        [TestMethod]
        public void baseclass_convert_sonclass_return_null_using_as()
        {
            var persons = new List<Person>()
            {
                new Person() { Name = "rico",Age = 25},
                new Person() { Name = "rock",Age = 24}
            };
            var sutdents = persons.Select(a => a as Student).ToList();
            Assert.IsNull(sutdents);
        }
        #endregion

        #region OfType
        /// <summary>
        /// oftype 协变 成功
        /// </summary>
        [TestMethod]
        public void sonclass_convert_baseclass_return_two_item_using_oftype()
        {
            var students = new List<Student>()
            {
                new Student() { Name = "rico",Age = 25},
                new Student() { Name = "rock",Age = 24}
            };
            var persons = students.OfType<Person>().ToList();
            Assert.AreEqual(persons.Count, 2);
        }
        /// <summary>
        /// oftype 逆变 非空  数量为0 没有异常
        /// </summary>
        [TestMethod]
        public void baseclass_convert_sonclass_return_null_using_oftype()
        {
            var persons = new List<Person>()
            {
                new Person() { Name = "rico",Age = 25},
                new Person() { Name = "rock",Age = 24}
            };
            var sutdents = persons.OfType<Student>().ToList();
            Assert.IsNotNull(sutdents);
            Assert.AreEqual(sutdents.Count, 0);
        }
        #endregion
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Student : Person
    {
        public string School { get; set; }
    }
}
