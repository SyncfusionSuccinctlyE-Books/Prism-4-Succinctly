using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE
{
    public interface IFormula
    {
        string GenerateFormula
            (ObservableCollection<string> FormulaValues,
            string FormulaTotalValue);
    }
}
