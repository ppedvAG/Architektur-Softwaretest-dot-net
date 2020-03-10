using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests_NUnit
{
    [TestFixture]
    public class CalcTest_NUnit
    {
        [Test]
        public void NUNIT_Calc_Sum_8_and_12_result_20()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(8, 12);

            //Assert
            Assert.AreEqual(20, result);
            Assert.That(result == 20);
        }
    }
}
