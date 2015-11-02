using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE
{
    public interface IConvertInteger
    {
        Signed32BitIntegerConversionResult ConvertStringTo32BitSignedInteger(string StringToConvert);
        Signed64BitIntegerConversionResult ConvertStringTo64BitSignedInteger(string StringToConvert);
    }
}
