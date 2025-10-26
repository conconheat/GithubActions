using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GithubActionsLab;

namespace GithubActionsLab
{
    [TestClass]
    public class CalculatorTests
    {
        // ---------- Add ----------
        [TestMethod]
        public void Add_Valid_Hohlen()
        {
            Assert.AreEqual(3, Program.Add("1", "2"));
            Assert.AreEqual(5, Program.Add("3", "2"));
            Assert.AreEqual(12, Program.Add("5", "7"));
        }

        [TestMethod]
        public void Add_Invalid_Hohlen()
        {
            Assert.ThrowsException<FormatException>(() => Program.Add("1", "a"));
            Assert.ThrowsException<FormatException>(() => Program.Add("a", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Add("a", "a"));
        }

        [TestMethod]
        public void Add_Null_Hohlen()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Add("1", null));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Add(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Add(null, null));
        }

        // ---------- Subtract ----------
        [TestMethod]
        public void Subtract_Valid_Hohlen()
        {
            Assert.AreEqual(4, Program.Subtract("10", "6"));
            Assert.AreEqual(-2, Program.Subtract("3", "5"));
        }

        [TestMethod]
        public void Subtract_Invalid_Hohlen()
        {
            Assert.ThrowsException<FormatException>(() => Program.Subtract("x", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Subtract("1", "y"));
        }

        [TestMethod]
        public void Subtract_Null_Hohlen()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Subtract(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Subtract("1", null));
        }

        // ---------- Multiply ----------
        [TestMethod]
        public void Multiply_Valid_Hohlen()
        {
            Assert.AreEqual(30, Program.Multiply("5", "6"));
            Assert.AreEqual(0, Program.Multiply("0", "999"));
        }

        [TestMethod]
        public void Multiply_Invalid_Hohlen()
        {
            Assert.ThrowsException<FormatException>(() => Program.Multiply("q", "2"));
            Assert.ThrowsException<FormatException>(() => Program.Multiply("2", "q"));
        }

        [TestMethod]
        public void Multiply_Null_Hohlen()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Multiply(null, "2"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Multiply("2", null));
        }

        // ---------- Divide ----------
        [TestMethod]
        public void Divide_Valid_Hohlen()
        {
            Assert.AreEqual(4, Program.Divide("20", "5"));
            Assert.AreEqual(2.5, Program.Divide("5", "2"));
        }

        [TestMethod]
        public void Divide_ByZero_ReturnsInfinity_Hohlen()
        {
            var posInf = Program.Divide("1", "0");
            Assert.IsTrue(double.IsPositiveInfinity(posInf));

            var negInf = Program.Divide("-1", "0");
            Assert.IsTrue(double.IsNegativeInfinity(negInf));
        }

        [TestMethod]
        public void Divide_Invalid_Hohlen()
        {
            Assert.ThrowsException<FormatException>(() => Program.Divide("z", "1"));
            Assert.ThrowsException<FormatException>(() => Program.Divide("1", "z"));
        }

        [TestMethod]
        public void Divide_Null_Hohlen()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Divide(null, "1"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Divide("1", null));
        }

        // ---------- Power ----------
        [TestMethod]
        public void Power_PositiveBaseExponent_Hohlen()
        {
            Assert.AreEqual(32.0, Program.Power("2", "5"), 1e-12);
            Assert.AreEqual(1.0, Program.Power("10", "0"), 1e-12);
        }

        [TestMethod]
        public void Power_NegativeExponent_Hohlen()
        {
            Assert.AreEqual(0.125, Program.Power("2", "-3"), 1e-12);
        }

        [TestMethod]
        public void Power_Invalid_Hohlen()
        {
            Assert.ThrowsException<FormatException>(() => Program.Power("a", "2"));
            Assert.ThrowsException<FormatException>(() => Program.Power("2", "b"));
        }

        [TestMethod]
        public void Power_Null_Hohlen()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Power(null, "2"));
            Assert.ThrowsException<ArgumentNullException>(() => Program.Power("2", null));
        }
    }
}
