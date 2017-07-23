
using CalculatorManagement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestCalculatorManagement
{
    /// <summary>
    /// 计算器测试类
    /// </summary>
    [TestFixture]
    public class TestCalculator
    {
        /// <summary>
        /// 测试加法
        /// </summary>
        [TestCase(10,1,2,3,4)]
        [TestCase(8, -1, 2, 3, 4)]
        public void TestPlus(double result,double p1,double p2,double p3,double p4)
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
            Assert.AreEqual(2, calculator.Minus(10,5,3));
        }
    }
}
