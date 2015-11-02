using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATE_SERVICE
{
    public interface ICalculate
    {
        Signed64BitIntegerConversionResult Compute(ObservableCollection<string> IntegerStrings);        
    }
}
