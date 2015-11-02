using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE
{
    public class Signed64BitIntegerConversionResult
    {
        public bool IsConverted { get; set; }
        public long ConvertedValue { get; set; }
        public string ExceptionText { get; set; }
    }
}
