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
    public class SignedInteger32BitConversionTests
    {
        private Signed32BitIntegerConversionResult Signed32BitIntegerConversionResult;        
        private ConvertInteger ConvertInteger;

        [TestFixtureSetUp]
        public void Setup()
        {
            Signed32BitIntegerConversionResult = new Signed32BitIntegerConversionResult();           
            ConvertInteger = new ConvertInteger
                (Signed32BitIntegerConversionResult);
        }

        [Test]
        public void Signed32BitIntegerConversionResultExists()
        {
            Assert.IsNotNull(Signed32BitIntegerConversionResult);
        }
       
        [Test]
        public void ConvertIntegerExsits()
        {
            Assert.IsNotNull(ConvertInteger);
        }

        [Test]
        public void ReturnANonNullSigned32BitIntegerConversionResult()
        {
            Signed32BitIntegerConversionResult S32Bit;

            S32Bit = ConvertInteger.ConvertStringTo32BitSignedInteger("TEST");
            Assert.IsNotNull(S32Bit);
        }

        [Test]
        public void ConvertStringToSigned32BitInteger()
        {
            int Signed32BitIntegerExpected = 500;
            int Signed32BitIntegerActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("500");

            Signed32BitIntegerActual = Signed32BitIntegerConversionResult.ConvertedValue;

            Assert.AreEqual(Signed32BitIntegerExpected, Signed32BitIntegerActual);
        }

        [Test]
        public void IfIsConvertedValueEqualsTrueWithValidValue()
        {
            bool IsConvertedExpected = true;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("5000");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfIsConvertedValueEqualsFalseWithInvalidValue()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("5000A");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueEqualsFalseWithInvalidValue()
        {
            int Signed32BitIntegerExpected = -1;
            int Signed32BitIntegerActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("575938485763646589299874665747");

            Signed32BitIntegerActual = Signed32BitIntegerConversionResult.ConvertedValue;

            Assert.AreEqual(Signed32BitIntegerExpected, Signed32BitIntegerActual);
        }

        [Test]
        public void IfConvertedValueHasValidUpperBoundsIsConvertedEqualsTrue()
        {
            bool IsConvertedExpected = true;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("2147483647");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasValidLowerBoundsIsConvertedEqualsTrue()
        {
            bool IsConvertedExpected = true;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("-2147483648");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasPositiveOverflowIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("2147483648958");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasNegitaveOverflowIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("-2147483648958098745");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasAlphaIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("15W");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasNonNumericIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("$649594");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasMinusInWrongPositionIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("649-594");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasBlankIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueIsNullIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger(null);

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasAlphaOnlyIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("E");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueHasCommaIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("2,473,674");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueIsFractionIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("2.25");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }

        [Test]
        public void IfConvertedValueIsNumberAndLowerCaseAlphaIsConvertedEqualsFalse()
        {
            bool IsConvertedExpected = false;
            bool IsConvertedActual;

            Signed32BitIntegerConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger("3a");

            IsConvertedActual = Signed32BitIntegerConversionResult.IsConverted;

            Assert.AreEqual(IsConvertedExpected, IsConvertedActual);
        }
    }
}
