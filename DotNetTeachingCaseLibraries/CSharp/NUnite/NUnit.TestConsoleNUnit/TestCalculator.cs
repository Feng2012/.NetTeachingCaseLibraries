
using CalculatorManagement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NUnit.TestCalculatorManagement
{
    /// <summary>
    /// 计算器测试类
    /// </summary>
    [TestFixture]
    public class TestCalculator
    {
        /// <summary>
        /// 每个测试方法前运行
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }
        /// <summary>
        /// 第个测试方法后运行
        /// </summary>
        [TearDown]
        public void TearDown()
        {

        }
        /// <summary>
        /// 只在开始时运行一次
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //var con = File.ReadAllText("D://a.txt");
            //var num = Convert.ToInt32(con) + 1;
            //File.WriteAllText("D://a.txt", num.ToString());
            //System.Threading.Thread.Sleep(2000);
        }
        /// <summary>
        /// 只在结束时运行一次
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTrearDown()
        {

        }
        /// <summary>
        /// 测试加法
        /// </summary>
        [TestCase(10, 1, 2, 3, 4)]
        [TestCase(8, -1, 2, 3, 4)]
        public void TestPlus(double result, double p1, double p2, double p3, double p4)
        {
            var calculator = new Calculator();
            Assert.AreEqual(result, calculator.Plus(p1, p2, p3, p4));
        }

        /// <summary>
        /// 测试减法
        /// </summary>
        [Test]
        public void TestMinus()
        {
            var calculator = new Calculator();
            Assert.AreEqual(2, calculator.Minus(10, 5, 3));
        }
        /// <summary>
        /// 测试除法被除数为0
        /// </summary>
        [Test]
        public void TestDivide_DividendIsZore_Exception()
        {
            var calculator = new Calculator();
            var ext = Assert.Catch<Exception>(() => calculator.Divide(10, 23, 0));
            StringAssert.Contains("第3个参数不能为零", ext.Message);
        }
        /// <summary>
        /// 测试除法
        /// </summary>
        [Test]
        public void TestDivide()
        {
            var calculator = new Calculator();
            Assert.AreEqual(4, calculator.Divide(120, 5, 6));
        }

    }
}
