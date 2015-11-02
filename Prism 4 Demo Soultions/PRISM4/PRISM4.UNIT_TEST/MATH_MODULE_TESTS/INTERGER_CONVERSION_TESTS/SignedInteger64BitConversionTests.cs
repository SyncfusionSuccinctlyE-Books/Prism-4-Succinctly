using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.INTERGER_CONVERSION_TESTS
{
    [TestFixture]
    public class SignedInteger64BitConversionTests
    {        
        private Signed64BitIntegerConversionResult Signed64BitIntegerConversionResult;
        private ConvertInteger ConvertInteger;

        [TestFixtureSetUp]
        public void Setup()
        {
            Signed64BitIntegerConversionResult = new Signed64BitIntegerConversionResult();

            ConvertInteger = new ConvertInteger
                (Signed64BitIntegerConversionResult);
        }

        [Test]
        public void Signed64BitIntegerConversionResultExists()
        {
            Assert.IsNotNull(Signed64BitIntegerConversionResult);
        }

        [Test]
        public void ConvertIntegerExsits()
        {
            Assert.IsNotNull(ConvertInteger);
        }

        [Test]
        public void ReturnANonNullSigned64BitIntegerConversionResult()
        {
            Signed64BitIntegerConversionResult S32Bit;

            S32Bit = ConvertInteger.ConvertStringTo64BitSignedInteger("Test");
            Assert.IsNotNull(S32Bit);
        }

        [Test]
        public void ConvertStringToSigned32BitInteger()
        {
            long Signed64BitIntegerExpected = 10000;
            long Signed64BitIntegerActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("10000");

            Signed64BitIntegerActual = Signed64BitIntegerConversionResult.ConvertedValue;

            Assert.AreEqual(Signed64BitIntegerExpected, Signed64BitIntegerActual);
        }

        [Test]
        public void IfIsConvertedValueEqualsTrueWithValidValue()
        {
            bool IsConvertedExpected = true;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("12000");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfIsConvertedValueEqualsFalseWithInvalidValue()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("N5000");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueEqualsFalseWithInvalidValue()
        {
            long Signed64BitIntegerExpected = -1;
            long Signed64BitIntegerActual;
            
            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("#5");

            Signed64BitIntegerActual = Signed64BitIntegerConversionResult.ConvertedValue;

            Assert.AreEqual(Signed64BitIntegerExpected, Signed64BitIntegerActual);
        }

        [Test]
        public void IfConvertedValueHasValidUpperBoundsIsConvertedEqualsTrue()
        {
            bool IsConvertedExpected = true;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("9223372036854775807");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasValidLowerBoundsIsConvertedEqualsTrue()
        {
            bool IsConvertedExpected = true;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("-9223372036854775808");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasPositiveOverflowIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("9223372036854775808");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasNegitaveOverflowIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("-9223372036854775809");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasAlphaIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("15W");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasNonNumericIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("$649594");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasMinusInWrongPositionIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("649-594");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasBlankIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueIsNullIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger(null);

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasAlphaOnlyIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("E");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasCommaIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("2,473,674");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueIsFractionIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed64BitIntegerConversionResult = ConvertInteger.ConvertStringTo64BitSignedInteger("2.473");

            IsConvertedActual = Signed64BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }
    }
}
