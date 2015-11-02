using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using NUnit.Framework;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE;

namespace PRISM4.UNIT_TEST.MATH_MODULE_TESTS.CALCULATION_FORMULA_TESTS
{
    public class SubtractCalculationFormulaTests
    {        
        private ObservableCollection<string> FormulaValues = new ObservableCollection<string>();
        private IFormula SubtractFormula;
        private string TotalValue = "";

        [TestFixtureSetUp]
        public void Setup()
        {
            IFormula SubtractFormula = new SubtractFormula();

            if (SubtractFormula != null)
            {
                this.SubtractFormula = SubtractFormula;
            }
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            FormulaValues.Clear();
        }

        [Test]
        public void ConfirmThatFormulaValuesExists()
        {
            Assert.IsNotNull(FormulaValues);
        }

        [Test]
        public void ConfirmThatAddFormulaExists()
        {
            Assert.IsNotNull(SubtractFormula);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConfirmThatLessThanOneValueIsInvalid()
        {            
            FormulaValues.Clear();

            SubtractFormula.GenerateFormula(FormulaValues, TotalValue);           
        }

        [Test]
        public void SubtractASingleValueWithOutTotal()
        {
            string ExpectedValue = "The remainder of 2";
            string ActualValue;

            FormulaValues.Add("2");
            TotalValue = "";

            ActualValue = SubtractFormula.GenerateFormula(FormulaValues, TotalValue);

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void SubtractFiveMinusTwoWithOutTotal()
        {
            string ExpectedValue = "The remainder of 5 - 2";
            string ActualValue;

            FormulaValues.Add("5");
            FormulaValues.Add("2");

            ActualValue = SubtractFormula.GenerateFormula(FormulaValues, TotalValue);

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void SubtractFiveMinusTwoWithTotal()
        {
            IFormula AddFormula = new SubtractFormula();

            string ExpectedValue = "The remainder of 5 - 2 equals 3";
            string ActualValue;

            FormulaValues.Add("5");
            FormulaValues.Add("2");
            TotalValue = "3";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, "3");

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void SubtractTenKMinusFiveKWithTotal()
        {
            IFormula AddFormula = new SubtractFormula();

            string ExpectedValue = "The remainder of 10000 - 5000 equals 5000";
            string ActualValue;

            FormulaValues.Add("10000");
            FormulaValues.Add("5000");
            TotalValue = "5000";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, "5000");

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void Subtract100000MinusFiveKWithTotal()
        {
            IFormula AddFormula = new SubtractFormula();

            string ExpectedValue = "The remainder of 100000 - 5000 equals 95000";
            string ActualValue;

            FormulaValues.Add("100000");
            FormulaValues.Add("5000");
            
            TotalValue = "95000";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, "95000");

            Assert.AreEqual(ExpectedValue, ActualValue);
        }
    }
}
