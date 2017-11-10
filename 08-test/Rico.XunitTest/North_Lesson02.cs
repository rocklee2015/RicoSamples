using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rico.XunitTest
{
   public class North_Lesson02
    {
        [Fact]
        public void EqualStringIgnoreCase()
        {
            string expected = "TestString";
            string actual = "teststring";

            Assert.False(actual == expected);
            Assert.NotEqual(expected, actual);
            Assert.Equal(expected, actual, StringComparer.CurrentCultureIgnoreCase);
        }

        [Fact(DisplayName = "Lesson02.Demo01")]
        public void Demo01_Fact_Test()
        {
            int num01 = 1;
            int num02 = 2;
            Assert.Equal<int>(3, num01 + num02);
        }

        [Fact(DisplayName = "Lesson02.Demo02", Skip = "Just test skip!")]
        public void Demo02_Fact_Test()
        {
            int num01 = 1;
            int num02 = 2;
            Assert.Equal<int>(3, num01 + num02);
        }

        [Theory(DisplayName = "Lesson02.Demo03")]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 4)]
        public void Demo03_Theory_Test(int num01, int num02, int result)
        {
            Assert.Equal<int>(result, num01 + num02);
        }

        #region MemberData InputData_Property
        public static IEnumerable<object[]> InputData_Property
        {
            get
            {
                var driverData = new List<object[]>();
                driverData.Add(new object[] { 1, 1, 2 });
                driverData.Add(new object[] { 1, 2, 3 });
                driverData.Add(new object[] { 2, 3, 5 });
                driverData.Add(new object[] { 3, 4, 7 });
                driverData.Add(new object[] { 4, 5, 9 });
                driverData.Add(new object[] { 5, 6, 11 });
                return driverData;
            }
        }

        [Theory(DisplayName = "Lesson02.Demo04")]
        [MemberData("InputData_Property")]
        public void Demo04_Theory_Test(int num01, int num02, int result)
        {
            Assert.Equal<int>(result, num01 + num02);
        }
        #endregion

        #region MemberData InputData_Method
        public static IEnumerable<object[]> InputData_Method(string flag)
        {
            var driverData = new List<object[]>();
            if (flag == "Default")
            {
                driverData.Add(new object[] { 1, 1, 2 });
                driverData.Add(new object[] { 1, 2, 3 });
                driverData.Add(new object[] { 2, 3, 5 });
            }
            else
            {
                driverData.Add(new object[] { 3, 4, 7 });
                driverData.Add(new object[] { 4, 5, 9 });
                driverData.Add(new object[] { 5, 6, 11 });
            }
            return driverData;
        }

        [Theory(DisplayName = "Lesson02.Demo05")]
        [MemberData("InputData_Method", "Default")]
        //[MemberData("InputData_Method", "Other")]
        public void Demo05_Theory_Test(int num01, int num02, int result)
        {
            Assert.Equal<int>(result, num01 + num02);
        }
        #endregion MemberData InputData_Method

        #region MemberData InputData_Field
        public class MatrixTheoryData<T1, T2> : TheoryData<T1, T2>
        {
            public MatrixTheoryData(IEnumerable<T1> data1, IEnumerable<T2> data2)
            {
                Contract.Assert(data1 != null && data1.Any());
                Contract.Assert(data2 != null && data2.Any());

                foreach (T1 t1 in data1)
                {
                    foreach (T2 t2 in data2)
                    {
                        Add(t1, t2);
                    }
                }
            }
        }

        public static int[] Numbers = { 5, 6, 7 };
        public static string[] Strings = { "Hello", "world!" };
        public static MatrixTheoryData<string, int> MatrixData = new MatrixTheoryData<string, int>(Strings, Numbers);

        [Theory(DisplayName = "Lesson02.Demo06")]
        [MemberData("MatrixData")]
        public void Demo06_Theory_Test(string x, int y)
        {
            Assert.Equal(y, x.Length);
        }
        #endregion MemberData InputData_Field
    }
}
