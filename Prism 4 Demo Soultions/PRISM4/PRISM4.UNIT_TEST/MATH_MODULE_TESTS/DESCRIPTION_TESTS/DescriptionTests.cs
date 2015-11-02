using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using NUnit.Framework;

using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.DESCRIPTION_SERVICES;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.DESCRIPTION_TESTS
{
    [TestFixture]
    public class DescriptionTests
    {
        private ObservableCollection<DescriptionResult> DescriptionResults = new ObservableCollection<DescriptionResult>();
        private Description Description;
        private DescriptionResult DescriptionResult = new DescriptionResult();

        private int AddTwoIntegersId = 0;       
        private int SubtractIntegersId = 1;

        [TestFixtureSetUp]
        public void Setup()
        {
            Description Description = new Description();

            if (Description != null)
            {
                this.Description = Description;
            }

            //Description.GenerateDescriptions();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
           DescriptionResults.Clear();
        }

        [TearDown]
        public void TearDown()
        {
           
        }

        [Test]
        public void ConfirmThatDescriptionResultsExists()
        {
            Assert.IsNotNull(DescriptionResults);
        }

        [Test]
        public void ConfirmThatDescreiptionResultExists()
        {
            Assert.IsNotNull(DescriptionResult);
        }

        [Test]
        public void ConfirmThatDescreiptionExists()
        {
            Assert.IsNotNull(Description);
        }      

        [Test]
        public void ConfirmThatGetDescriptionReturnsNonNullAddTwoIntegersResult()
        {
            DescriptionResult = Description.GetDescription(AddTwoIntegersId);

            Assert.IsNotNull(DescriptionResult);
        }        

        [Test]
        public void ConfirmThatGetDescriptionReturnsAddTwoIntegersExceptionId()
        {
            int ExpectedValue = 2;
            int ActualValue;

            DescriptionResult = Description.GetDescription(AddTwoIntegersId);
            ActualValue = DescriptionResult.ExceptionId;

            Assert.AreEqual(ExpectedValue, ActualValue);
        }             

        [Test]
        public void ConfirmThatGetDescriptionReturnsNonNullSubtractIntegersResult()
        {
            DescriptionResult = Description.GetDescription(SubtractIntegersId);

            Assert.IsNotNull(DescriptionResult);
        }

        [Test]
        public void ConfirmThatGetDescriptionReturnsSubtractIntegersDescriptionText()
        {
            int GreaterThanValue = 0;
            int ActualValue;

            DescriptionResult = Description.GetDescription(SubtractIntegersId);
            ActualValue = DescriptionResult.Description.Length;

            Assert.Greater(ActualValue, GreaterThanValue);
        }

        [Test]
        public void ConfirmThatGetDescriptionReturnsSubtractIntegersExceptionId()
        {
            int ExpectedValue = 3;
            int ActualValue;

            DescriptionResult = Description.GetDescription(SubtractIntegersId);
            ActualValue = DescriptionResult.ExceptionId;

            Assert.AreEqual(ExpectedValue, ActualValue);
        }       

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConfirmThatGetDescriptionHandlesArgumentOutOfRangeException()
        {            
            DescriptionResult = Description.GetDescription(4);            
        }
    }
}
