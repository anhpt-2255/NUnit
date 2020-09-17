using System;
using NUnit;
using NUnit_Application;
using NUnit.Framework;

namespace NUnit_Application.Test
{
    [TestFixture]
    public class TestClass
    {
        [TestCase]
        public void AddTest()
        {
            MathsHelper helper = new MathsHelper();
            int result = helper.Add(20, 10);
            Assert.AreEqual(40, result);
        }

        [TestCase]
        public void SubtractTest()
        {
            MathsHelper helper = new MathsHelper();
            int result = helper.Subtract(20, 10);
            Assert.AreEqual(10, result);
        }

        [TestCase(new int[] { 2, 4, 6 })]
        public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(int[] numbers)
        {
            Number number = new Number();

            bool result = number.AreAllNumbersEven(numbers);

            Assert.That(result == true);
        }
    }
}
