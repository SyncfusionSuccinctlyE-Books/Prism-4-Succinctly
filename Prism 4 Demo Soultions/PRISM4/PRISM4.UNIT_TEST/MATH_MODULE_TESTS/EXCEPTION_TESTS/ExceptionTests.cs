using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;
using NUnit.Framework;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.VALIDATION_TESTS
{
    [TestFixture]
    public class ExceptionTests        
    {
        ExceptionResult Exception = new ExceptionResult();
        ExceptionResult ExceptionResult32Bit = new ExceptionResult();
        
        ObservableCollection<ExceptionResult> ExceptionResultCollection = new ObservableCollection<ExceptionResult>();
        ICalculatorExceptionController CalculatorExceptionController;

        [TestFixtureSetUp]
        public void Setup()
        {
            ICalculatorExceptionController CalculatorException = new 
                CalculatorExceptionController();

            CalculatorExceptionController = CalculatorException;
        }

        [Test]
        public void IsExceptionClassCreated()
        {            
            Assert.NotNull(Exception);
        }

        [Test]
        public void IsCalculatorExceptionControllerClassCreated()
        {


            Assert.NotNull(CalculatorExceptionController);
        }

        [Test]
        public void IsExceptionResultCollectionClassCreated()
        {
            Assert.NotNull(ExceptionResultCollection);
        }

        [Test]
        public void IsTheExceptionCountGreaterThanZero()
        {            
            int ExceptionCountExpected = 0;
            int ExceptionCountResult = 0;

            ExceptionCountResult = CalculatorExceptionController.GenerateExceptions();

            Assert.Greater(ExceptionCountResult, ExceptionCountExpected);
        }       

        [Test]
        public void IsFirstExceptionResultAddedToCollection()
        {
            ExceptionResult ExceptionResultExpected;
            int ExceptionIdResult = 0;

            CalculatorExceptionController.GenerateExceptions();
            ExceptionResultExpected = CalculatorExceptionController.GetException(0);

            Assert.AreEqual(ExceptionResultExpected.ExceptionId, ExceptionIdResult);
        }

       
        [Test]
        public void IsTextInTheFirstCollectionResult()
        {
            ExceptionResult ExceptionResultExpected;
            int ActualTextLengthResult = 0;
            int ExpectedTextLengthResult = 0;

            CalculatorExceptionController.GenerateExceptions();
            ExceptionResultExpected = CalculatorExceptionController.GetException(0);

            ActualTextLengthResult = ExceptionResultExpected.ExceptionText.Length;

            Assert.Greater(ActualTextLengthResult, ExpectedTextLengthResult);
        }
       

        [Test]
        public void IsCollectionCleared()
        {
            int ExceptionIdExpected = 0;
            int ExceptionIdResult = 0;

            ExceptionIdResult = CalculatorExceptionController.ClearAllExceptions();

            Assert.AreEqual(ExceptionIdExpected, ExceptionIdResult);
        }
    }
}
