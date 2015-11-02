
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATE_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE;

namespace PRISM4.MATH_MODULE.MODELS
{
    public class AddTwoModel
    {       
        private string TotalValue = "";
        private ICalculate AddIntegerValues;
        private Signed64BitIntegerConversionResult IntegerConversionResult;
        private IFormula AddFormula;
        private string FormulaText = "";

        ObservableCollection<string> IntegerStrings;

        public AddTwoModel
            (ICalculate AddIntegerValues,
            Signed64BitIntegerConversionResult IntegerConversionResult, 
            IFormula AddFormula)
        {
            if (AddIntegerValues != null)
            {
                this.AddIntegerValues = AddIntegerValues;
            }

            if (IntegerConversionResult != null)
            {
                this.IntegerConversionResult = IntegerConversionResult;
            }

            if (AddFormula != null)
            {
                this.AddFormula = AddFormula;
            }
        }

        public string AddIntegers
            (ObservableCollection<string> IntegerStrings)
        {
            if (IntegerStrings != null)
            {
                this.IntegerStrings = IntegerStrings;
            }
            
            IntegerConversionResult = AddIntegerValues.Compute(IntegerStrings);

            if (IntegerConversionResult.IsConverted == true)
            {
                TotalValue = IntegerConversionResult.ConvertedValue.ToString();               
            }
           
            return TotalValue;
        }

        public string GetFormula
            (ObservableCollection<string> IntegerStrings, 
            string TotalIntegerValue)
        {
            FormulaText = AddFormula.GenerateFormula(this.IntegerStrings, TotalIntegerValue);

            return FormulaText;
        }
    }
}
