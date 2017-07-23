
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
        [Test]
        public void TestPlus()
        {
            var calculator = new Calculator();
            Assert.AreEqual(10, calculator.Plus(1, 2, 3, 4));
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
