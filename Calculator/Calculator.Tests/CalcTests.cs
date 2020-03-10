using System;
using System.IO;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_4_and_5_results_9()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(4, 5);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Calc_Sum_N3_and_N6_results_N9()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(-3, -6);

            //Assert
            Assert.AreEqual(-9, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Ex")]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }


        [TestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(5, 18, 23)]
        [DataRow(-5, -4, -9)]
        [DataRow(2, -4, -2)]
        [TestCategory("Blau")]
        public void Calc_Sum(int a, int b, int r)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(r, result);
        }

        [TestMethod]
        public void Calc_IsWeekend()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                //System.IO.Fakes.ShimFile.ExistsString = x => true;
                //Assert.IsTrue(File.Exists(@"b:\weornfoim4tkewm.fwego43ng4ojng3oi"));

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 9);
                Assert.IsFalse(calc.IsWeekend());//mo
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 10);
                Assert.IsFalse(calc.IsWeekend());//di
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 11);
                Assert.IsFalse(calc.IsWeekend());//mi
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 12);
                Assert.IsFalse(calc.IsWeekend());//do
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 13);
                Assert.IsFalse(calc.IsWeekend());//fr
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 14);
                Assert.IsTrue(calc.IsWeekend());//sa
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 3, 15);
                Assert.IsTrue(calc.IsWeekend());//so
            }
        }


    }
}
