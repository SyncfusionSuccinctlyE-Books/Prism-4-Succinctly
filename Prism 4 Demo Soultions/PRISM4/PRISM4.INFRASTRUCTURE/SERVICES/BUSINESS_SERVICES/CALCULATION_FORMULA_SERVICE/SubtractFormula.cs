using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE
{
    public class SubtractFormula : IFormula
    {

        public SubtractFormula()
        {
                    
        }

        public string GenerateFormula
            (ObservableCollection<string> FormulaValues,
            string FormulaTotalValue)
        {
            
                if (FormulaValues.Count() < 1)
                {
                    throw new ArgumentOutOfRangeException("Must have at least one integer to subtract.");
                }
           
            string Formula = "The remainder of ";

            foreach (string IntegerValue in FormulaValues)
            {
                if (IntegerValue != null)
                {
                    Formula += IntegerValue.Trim() + " - ";
                }
            }

            Formula = Formula.Substring(0, Formula.Length - 3);

            if (FormulaTotalValue != null && FormulaTotalValue != "")
            {
                Formula += " equals " + FormulaTotalValue.Trim();
            }

            return Formula;
        }
    }
}
