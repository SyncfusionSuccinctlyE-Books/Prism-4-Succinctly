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
    [TestFixture]
    public class AddCalculationFormulaTests
    {
        private ObservableCollection<string> FormulaValues = new ObservableCollection<string>();
        private IFormula AddFormula;
        private string TotalValue = "";

        [TestFixtureSetUp]
        public void Setup()
        {
            IFormula AddFormula = new AddFormula();

            if (AddFormula != null)
            {
                this.AddFormula = AddFormula;
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
            Assert.IsNotNull(AddFormula);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConfirmThatLessThanOneValueIsInvalid()
        {            
            FormulaValues.Clear();

            AddFormula.GenerateFormula(FormulaValues, TotalValue);           
        }

        [Test]
        public void AddASingleValueWithOutTotal()
        {
            string ExpectedValue = "The sum of 2";
            string ActualValue;

            FormulaValues.Add("2");

            ActualValue = AddFormula.GenerateFormula(FormulaValues, TotalValue);

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void AddTwoPlusTwoWithOutTotal()
        {
            string ExpectedValue = "The sum of 2 + 2";
            string ActualValue;

            FormulaValues.Add("2");
            FormulaValues.Add("2");
            TotalValue = "";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, TotalValue);

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void AddTwoPlusTwoWithTotal()
        {
            IFormula AddFormula = new AddFormula();

            string ExpectedValue = "The sum of 2 + 2 equals 4";
            string ActualValue;

            FormulaValues.Add("2");
            FormulaValues.Add("2");
            TotalValue = "4";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, "4");

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void AddTwoKPlusFiveKWithTotal()
        {
            IFormula AddFormula = new AddFormula();

            string ExpectedValue = "The sum of 2000 + 5000 equals 7000";
            string ActualValue;

            FormulaValues.Add("2000");
            FormulaValues.Add("5000");
            TotalValue = "7000";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, "7000");

            Assert.AreEqual(ExpectedValue, ActualValue);
        }

        [Test]
        public void AddThreeKPlusFiveKPlusTenKPlusSixKWithTotal()
        {
            IFormula AddFormula = new AddFormula();

            string ExpectedValue = "The sum of 3000 + 5000 + 10000 + 6000 equals 24000";
            string ActualValue;

            FormulaValues.Add("3000");
            FormulaValues.Add("5000");
            FormulaValues.Add("10000");
            FormulaValues.Add("6000");

            TotalValue = "24000";

            ActualValue = AddFormula.GenerateFormula(FormulaValues, "24000");

            Assert.AreEqual(ExpectedValue, ActualValue);
        }
    }
}
