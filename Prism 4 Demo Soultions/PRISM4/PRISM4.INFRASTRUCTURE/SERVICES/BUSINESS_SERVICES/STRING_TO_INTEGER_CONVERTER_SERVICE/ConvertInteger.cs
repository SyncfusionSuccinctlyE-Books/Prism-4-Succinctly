using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE
{
    public class ConvertInteger : IConvertInteger
    {
        private Signed32BitIntegerConversionResult Signed32BitIntegerConversionResult;
        private Signed64BitIntegerConversionResult Signed64BitIntegerConversionResult;
        private bool IsConverted;        

        public ConvertInteger
            (Signed32BitIntegerConversionResult Signed32BitIntegerConversionResult)
        {
            if (Signed32BitIntegerConversionResult != null)
            {
                this.Signed32BitIntegerConversionResult = Signed32BitIntegerConversionResult;
            }           
        }

        public ConvertInteger
           (Signed64BitIntegerConversionResult Signed64BitIntegerConversionResult)
        {           
            if (Signed64BitIntegerConversionResult != null)
            {
                this.Signed64BitIntegerConversionResult = Signed64BitIntegerConversionResult;
            }

        }

        public Signed32BitIntegerConversionResult ConvertStringTo32BitSignedInteger(string StringToConvert)
        {            
            int ConversionResult;

            if (StringToConvert == null || StringToConvert.Length <= 0)
            {                
                Signed32BitIntegerConversionResult.IsConverted = false;
                Signed32BitIntegerConversionResult.ConvertedValue = -1;

                return Signed32BitIntegerConversionResult;
            }

            IsConverted = int.TryParse(StringToConvert, out ConversionResult);

            Signed32BitIntegerConversionResult.IsConverted = IsConverted;

            if (IsConverted == true)
            {               
                Signed32BitIntegerConversionResult.ConvertedValue = ConversionResult;
            }
            else
            {                
                Signed32BitIntegerConversionResult.ConvertedValue = -1;
            }

            return Signed32BitIntegerConversionResult;
        }

        public Signed64BitIntegerConversionResult ConvertStringTo64BitSignedInteger(string StringToConvert)
        {
            long ConversionResult;

            if (StringToConvert == null || StringToConvert.Length <= 0)
            {                
                Signed64BitIntegerConversionResult.IsConverted = false;
                Signed64BitIntegerConversionResult.ConvertedValue = -1;

                return Signed64BitIntegerConversionResult;
            }

            IsConverted = long.TryParse(StringToConvert, out ConversionResult);

            Signed64BitIntegerConversionResult.IsConverted = IsConverted;

            if (IsConverted == true)
            {               
                Signed64BitIntegerConversionResult.ConvertedValue = ConversionResult;
            }
            else
            {                
                Signed64BitIntegerConversionResult.ConvertedValue = -1;
            }

            return Signed64BitIntegerConversionResult;        
        }
    }
}
