using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using NUnit.Framework;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATE_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.CALCULATION_TESTS
{
    [TestFixture]
    public class AddIntegerTests
    {
        private ObservableCollection<string> IntegerStrings = new ObservableCollection<string>();
        private Signed32BitIntegerConversionResult Integer32ConversionResult = new Signed32BitIntegerConversionResult();
        private Signed64BitIntegerConversionResult Integer64ConversionResult = new Signed64BitIntegerConversionResult();
        private ICalculate AddInteger;

        private IConvertInteger ConvertInteger;       

        [TestFixtureSetUp]
        public void Setup()
        {
            IConvertInteger ConvertInteger = new ConvertInteger(Integer32ConversionResult);
            ICalculate AddInteger = new AddIntegers();

            this.ConvertInteger = ConvertInteger;
            this.AddInteger = AddInteger;
        }

        [TearDown]
        public void TearDown()
        {
            IntegerStrings.Clear();
        }

        [Test]
        public void ConfirmThatAddIntegerExists()
        {
            Assert.IsNotNull(AddInteger);
        }

        [Test]
        public void ConfirmThatConvertIntegerExists()
        {
            Assert.IsNotNull(ConvertInteger);
        }

        [Test]
        public void ConfirmThatIntegerStringsExists()
        {
            Assert.IsNotNull(IntegerStrings);
        }

        [Test]
        public void ConfirmThatInteger32ConversionResultExists()
        {
            Assert.IsNotNull(Integer32ConversionResult);
        }

        [Test]
        public void ConfirmThatInteger64ConversionResultExists()
        {
            Assert.IsNotNull(Integer64ConversionResult);
        }

        [Test]
        public void ConfirmThatOnlyTwoTextValuesWereEntered()
        {            
            bool ResultActual;

            IntegerStrings.Add("20");
            IntegerStrings.Add("30");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsTrue(ResultActual);           
        }

        [Test]
        public void ConfirmThatNoTextValuesReturnFalse()
        {
            bool ResultActual;            

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatLessThanTwoTextValuesReturnFalse()
        {            
            bool ResultActual;

            IntegerStrings.Add("20");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);           
        }

        [Test]
        public void ConfirmThatMoreThanTwoTextValuesReturnFalse()
        {
            bool ResultActual;

            IntegerStrings.Add("20");
            IntegerStrings.Add("30");
            IntegerStrings.Add("60");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);            
        }

        [Test]
        public void ConfirmThatInvalidTextValuesReturnExceptionText()
        {
            string ResultExpected = "Two Values must be entered to add, one value, zero or less values or more than two values were entered.";
            string ResultActual;

            IntegerStrings.Add("20");
            IntegerStrings.Add("40");
            IntegerStrings.Add("60");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ExceptionText;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatInvalidTextValuesReturnAValueOfNegativeOne()
        {
            long ResultExpected = -1;
            long ResultActual;

            IntegerStrings.Add("50");
            IntegerStrings.Add("40");
            IntegerStrings.Add("60");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatValidValuesReturnTrue()
        {
            bool ResultExpected = true;
            bool ResultActual;

            IntegerStrings.Add("3");
            IntegerStrings.Add("3");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatInvalidTextOneValuesReturnfalse()
        {            
            bool ResultActual;

            IntegerStrings.Add("3d");
            IntegerStrings.Add("3");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatBlankTextOneValuesReturnfalse()
        {
            bool ResultActual;

            IntegerStrings.Add("");
            IntegerStrings.Add("3");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatnullTextOneValuesReturnfalse()
        {
            bool ResultActual;

            IntegerStrings.Add(null);
            IntegerStrings.Add("3");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatInValidTextOneValuesReturnExceptionText()
        {
            string ResultExpected = "The value entered into integer one is not valid. Please enter a valid value.";
            string ResultActual;

            IntegerStrings.Add(null);
            IntegerStrings.Add("3");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ExceptionText;            

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatInvalidTextTwoValuesReturnfalse()
        {
            bool ResultActual;

            IntegerStrings.Add("3");
            IntegerStrings.Add("3f");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatBlankTextTwoValuesReturnfalse()
        {
            bool ResultActual;

            IntegerStrings.Add("10");
            IntegerStrings.Add("");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatnullTextTwoValuesReturnfalse()
        {
            bool ResultActual;

            IntegerStrings.Add("100");
            IntegerStrings.Add(null);

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatInValidTextTwoValuesReturnExceptionText()
        {
            string ResultExpected = "The value entered into integer two is not valid. Please enter a valid value.";
            string ResultActual;

            IntegerStrings.Add("1000");
            IntegerStrings.Add(null);

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ExceptionText;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatInvalidTextOneAndTextTwoValuesReturnfalse()
        {
            bool ResultActual;

            IntegerStrings.Add("3Q");
            IntegerStrings.Add("3f");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);
            ResultActual = Integer64ConversionResult.IsConverted;

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.IsFalse(ResultActual);
        }

        [Test]
        public void ConfirmThatInvalidTextOneAndTextTwoValuesReturnTextOneExceptionText()
        {
            string ResultExpected = "The value entered into integer one is not valid. Please enter a valid value.";
            string ResultActual;

            IntegerStrings.Add(null);
            IntegerStrings.Add(null);

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ExceptionText;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatTwoPlusTwoIsFour()
        {
            long ResultExpected = 4;
            long ResultActual;

            IntegerStrings.Add("2");
            IntegerStrings.Add("2");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThat10KPlusTwoKIs12K()
        {
            long ResultExpected = 12000;
            long ResultActual;

            IntegerStrings.Add("10000");
            IntegerStrings.Add("2000");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatZeroPlusZeroKIsZero()
        {
            long ResultExpected = 0;
            long ResultActual;

            IntegerStrings.Add("0");
            IntegerStrings.Add("0");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatNegitaveTenPlusNegitaveTenIsNegitaveTwenty()
        {
            long ResultExpected = -20;
            long ResultActual;

            IntegerStrings.Add("-10");
            IntegerStrings.Add("-10");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatNegitaveTenPlusTenIsZero()
        {
            long ResultExpected = 0;
            long ResultActual;

            IntegerStrings.Add("-10");
            IntegerStrings.Add("10");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]
        public void ConfirmThatNegitaveTwoKPlusNegitaveTwoKIsNegitaveFourK()
        {
            long ResultExpected = -4000;
            long ResultActual;

            IntegerStrings.Add("-2000");
            IntegerStrings.Add("-2000");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.ConvertedValue;

            Assert.AreEqual(ResultExpected, ResultActual);
        }

        [Test]        
        public void ConfirmThatTheMaxIntegerValuesInEachTextBoxIsNotValid()
        {
            bool ResultExpected = false;
            bool ResultActual;

            IntegerStrings.Add("2147483647");
            IntegerStrings.Add("2147483647");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.AreEqual(ResultExpected, ResultActual);             
        }

        [Test]        
        public void ConfirmThatMaxNegativeIntegerValuesInEachTextBoxIsNotValid()
        {
            bool ResultExpected = false;
            bool ResultActual;

            IntegerStrings.Add("-2147483648");
            IntegerStrings.Add("-2147483648");

            Integer64ConversionResult = AddInteger.Compute(IntegerStrings);

            ResultActual = Integer64ConversionResult.IsConverted;

            Assert.AreEqual(ResultExpected, ResultActual);
        }        
    }
}
