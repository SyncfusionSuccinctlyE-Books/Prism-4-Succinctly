using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.VALIDATION_TESTS
{
    [TestFixture]
    public class Signed32BitIntegerValidationTests
    {
        private IntegerValidationResult ValidationResult = new IntegerValidationResult();
        private Validate32BitSignedInteger Validate32BitInteger;
        
        private ExceptionResult ExceptionResult;
        private ExceptionResult ExceptionResult32Bit;
        private ExceptionResult ExceptionResult64Bit;

        private ObservableCollection<ExceptionResult> ExceptionCollection = new ObservableCollection<ExceptionResult>();       

        [TestFixtureSetUp]
        public void Setup()
        {            
            var ExceptionResult = new ExceptionResult();
            var ExceptionResult32Bit = new ExceptionResult();
            
            if (ExceptionResult != null)
            {
                this.ExceptionResult = ExceptionResult;
            }

            if (ExceptionResult32Bit != null)
            {
                this.ExceptionResult32Bit = ExceptionResult32Bit;
            }           

            ICalculatorExceptionController ExceptionController = new CalculatorExceptionController();

            //, 
              //  ExceptionController

            var Validate = new Validate32BitSignedInteger
                (ValidationResult, 
                ExceptionController, 
                ExceptionResult);

            if (Validate != null)
            {
                Validate32BitInteger = Validate;
            }            
        }

        [Test]
        public void IsIntegerValidationResultClassCreated()
        {
            Assert.NotNull(ValidationResult);
        }

        [Test]
        public void Is32BitIntegerValidationClassCreated()
        {
            Assert.NotNull(Validate32BitInteger);
        }
       
        [Test]
        public void IsValidationResultReturned()
        {
            ValidationResult = Validate32BitInteger.Validate("0");
            Assert.NotNull(ValidationResult);
        }

        [Test]
        public void IsValidationOk()
        {
            ValidationResult = Validate32BitInteger.Validate("200");

            Assert.IsTrue(ValidationResult.IsValidated);
        }

        [Test]
        public void IsAZeroValueValid()
        {
            ValidationResult = Validate32BitInteger.Validate("0");

            Assert.IsTrue(ValidationResult.IsValidated);
        }

        [Test]
        public void IsANegitaveOneValueValid()
        {
            ValidationResult = Validate32BitInteger.Validate("-1");

            Assert.IsTrue(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationResultHaveAValidUpperBoundsValue()
        {
            ValidationResult = Validate32BitInteger.Validate("2147483647");

            Assert.IsTrue(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationResultHaveAValidLowerBoundsValue()
        {
            ValidationResult = Validate32BitInteger.Validate("-2147483648");

            Assert.IsTrue(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationResultHaveExceptionIdValue()
        {
            int ExpectedExceptionIdValue = 0;

            ValidationResult = Validate32BitInteger.Validate("2147483648");

            Assert.AreEqual(ExpectedExceptionIdValue, ValidationResult.ExceptionId);
        }

        [Test]
        public void DoesValidationResultHaveValidTextValue()
        {
            int ExpectedExceptionTextLength = 0;

            ValidationResult = Validate32BitInteger.Validate("21474836489765876");

            Assert.Greater(ValidationResult.ValidatedText.Length, ExpectedExceptionTextLength);
        }

        [Test]
        public void DoesValidationFailWithAlphaAndNumber()
        {
            ValidationResult = Validate32BitInteger.Validate("200A");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationFailWithPositiveOverflow()
        {
            ValidationResult = Validate32BitInteger.Validate("2147483648");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationFailWithNegativeOverflow()
        {
            ValidationResult = Validate32BitInteger.Validate("-2147483649");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationFailWithAlphaOnly()
        {
            ValidationResult = Validate32BitInteger.Validate("A");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationFailWithComma()
        {
            ValidationResult = Validate32BitInteger.Validate("2,876");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationFailWithFraction()
        {
            ValidationResult = Validate32BitInteger.Validate("2.25");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void DoesValidationFailWithSpecialCharacter()
        {
            ValidationResult = Validate32BitInteger.Validate("$200");

            Assert.IsFalse(ValidationResult.IsValidated);
        }

        [Test]
        public void IsExceptionResultClassCreated()
        {
            ValidationResult = Validate32BitInteger.Validate("E200");

            if (ValidationResult.IsValidated == false)
            {
                ExceptionResult = Validate32BitInteger.GetException(ValidationResult.ExceptionId);
            }

            Assert.NotNull(ExceptionResult);
        }

        [Test]
        public void IsValidationExceptionReturnedWhentheIsValidatedValueIsFalse()
        {
            ValidationResult = Validate32BitInteger.Validate("200%");

            if (ValidationResult.IsValidated == false)
            {
                ExceptionResult = Validate32BitInteger.GetException(ValidationResult.ExceptionId);
            }

            Assert.IsNotNull(ExceptionResult);
        }

        [Test]
        public void DoesExceptionResultHaveExceptionIdValue()
        {
            int ExpectedExceptionResultId = 0;
            int ExceptionResultId = -1;

            ValidationResult = Validate32BitInteger.Validate("200%73501");

            if (ValidationResult.IsValidated == false)
            {
                ExceptionResult = Validate32BitInteger.GetException(ValidationResult.ExceptionId);
                ExceptionResultId = ExceptionResult.ExceptionId;
            }

            Assert.AreEqual(ExpectedExceptionResultId, ExceptionResultId);
        }

        //[Test]
        //public void DoesExceptionResultHaveExceptionTextValue()
        //{
        //    int LowerExceptionResultTextLength = 0;
        //    int GreaterExceptionResultTextLength = 0;

        //    ValidationResult = Validate32BitInteger.Validate("200-");

        //    if (ValidationResult.IsValidated == false)
        //    {
        //        ExceptionResult = Validate32BitInteger.GetException(ValidationResult.ExceptionId);
        //        GreaterExceptionResultTextLength = ExceptionResult.ExceptionText.Length;
        //    }

        //    Assert.Greater(GreaterExceptionResultTextLength, LowerExceptionResultTextLength);
        //}

        [Test]
        public void IsBlankExceptionTextValueReturnedWhenIsValidIsTrue()
        {           
            ValidationResult = Validate32BitInteger.Validate("200");
            Assert.IsNullOrEmpty(ValidationResult.ValidatedText);
        }

        [Test]
        public void IsNegitaveOneExceptionIdValueReturnedWhenIsValidIsTrue()
        {
            int ExprctedExceptionId = -1;

            ValidationResult = Validate32BitInteger.Validate("200");

            Assert.AreEqual(ExprctedExceptionId, ValidationResult.ExceptionId);
        }
    }
}
