using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATE_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE;

namespace PRISM4.MATH_MODULE.MODELS
{
    public class SubtractTwoModel
    {
        private string TotalValue = "";
        private ICalculate SubtractIntegerValues;
        private Signed64BitIntegerConversionResult IntegerConversionResult;
        private IFormula SubtractFormula;
        private string FormulaText = "";

        ObservableCollection<string> IntegerStrings;

        public SubtractTwoModel
            ([Dependency("Subtract")] ICalculate SubtractIntegerValues,
            Signed64BitIntegerConversionResult IntegerConversionResult, 
            [Dependency("SubtractFormula")] IFormula SubtractFormula)
        {
            if (SubtractIntegerValues != null)
            {
                this.SubtractIntegerValues = SubtractIntegerValues;
            }

            if (IntegerConversionResult != null)
            {
                this.IntegerConversionResult = IntegerConversionResult;
            }

            if (SubtractFormula != null)
            {
                this.SubtractFormula = SubtractFormula;
            }
        }

        public string SubtractIntegers
            (ObservableCollection<string> IntegerStrings)
        {
            if (IntegerStrings != null)
            {
                this.IntegerStrings = IntegerStrings;
            }

            IntegerConversionResult = SubtractIntegerValues.Compute(IntegerStrings);

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
            FormulaText = SubtractFormula.GenerateFormula(this.IntegerStrings, TotalIntegerValue);

            return FormulaText;
        }
    }
}
