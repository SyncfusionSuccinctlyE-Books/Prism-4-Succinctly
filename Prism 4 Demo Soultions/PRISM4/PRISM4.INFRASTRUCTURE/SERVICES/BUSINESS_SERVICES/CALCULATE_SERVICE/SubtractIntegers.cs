using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATE_SERVICE
{
    public class SubtractIntegers : ICalculate
    {
        private ObservableCollection<string> IntegerStrings;
        private IConvertInteger ConvertInteger;

        private Signed32BitIntegerConversionResult StringConversionResult = new Signed32BitIntegerConversionResult();
        private Signed64BitIntegerConversionResult TotalConversionResult = new Signed64BitIntegerConversionResult();

        private int IntegerValue1;
        private int IntegerValue2;
        private long IntegerTotal;

        public SubtractIntegers()
        {
            ConvertInteger = new ConvertInteger(StringConversionResult);
        }

        public Signed64BitIntegerConversionResult Compute(ObservableCollection<string> IntegerStrings)
        {
            if (IntegerStrings != null)
            {
                this.IntegerStrings = IntegerStrings;
            }

            TotalConversionResult.ExceptionText = "";

            TotalConversionResult = ConfirmCountOnCollection();

            if (TotalConversionResult.IsConverted == false)
            {
                IntegerStrings.Clear();
                return TotalConversionResult;
            }

            TotalConversionResult = ConvertStringValue1();

            if (TotalConversionResult.IsConverted == false)
            {
                IntegerStrings.Clear();
                return TotalConversionResult;
            }

            TotalConversionResult = ConvertStringValue2();

            if (TotalConversionResult.IsConverted == false)
            {
                IntegerStrings.Clear();
                return TotalConversionResult;
            }

            TotalConversionResult = SubtractValues(IntegerStrings);

            if (TotalConversionResult.IsConverted == false)
            {
                IntegerStrings.Clear();
                return TotalConversionResult;
            }                                        

            return TotalConversionResult;                                              
        }

        private Signed64BitIntegerConversionResult ConfirmCountOnCollection()
        {           
            if (IntegerStrings.Count == 2)
            {
                TotalConversionResult.IsConverted = true;
                TotalConversionResult.ConvertedValue = 0;

                TotalConversionResult.ExceptionText = "";
            }
            else
            {
                TotalConversionResult.IsConverted = false;
                TotalConversionResult.ConvertedValue = -1;

                TotalConversionResult.ExceptionText = 
                    "Two Values must be entered to subtract, one value, zero or less values or more than two values were entered.";
            }

            return TotalConversionResult;
        }

        private Signed64BitIntegerConversionResult ConvertStringValue1()
        {
            string StringValue1 = IntegerStrings[0];
            
            StringConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger(StringValue1);

            if (StringConversionResult.IsConverted == true)
            {
                IntegerValue1 = StringConversionResult.ConvertedValue;
            }
            else
            {
                IntegerStrings.Clear();

                TotalConversionResult.IsConverted = false;
                TotalConversionResult.ConvertedValue = -1;
                TotalConversionResult.ExceptionText =
                    "The value entered into integer one is not valid. Please enter a valid value.";                
            }

            return TotalConversionResult;
        }

        private Signed64BitIntegerConversionResult ConvertStringValue2()
        {
            string StringValue2 = IntegerStrings[1];

            StringConversionResult = ConvertInteger.ConvertStringTo32BitSignedInteger(StringValue2);

            if (StringConversionResult.IsConverted == true)
            {
                IntegerValue2 = StringConversionResult.ConvertedValue;
            }
            else
            {
                IntegerStrings.Clear();

                TotalConversionResult.IsConverted = false;
                TotalConversionResult.ConvertedValue = -1;
                TotalConversionResult.ExceptionText =
                    "The value entered into integer two is not valid. Please enter a valid value.";
            }

            return TotalConversionResult;
        }

        private Signed64BitIntegerConversionResult SubtractValues(ObservableCollection<string> IntegerStrings)
        {            
             try
             {
                 checked
                 {                     
                     IntegerTotal = IntegerValue1 - IntegerValue2;

                     TotalConversionResult.IsConverted = true;
                     TotalConversionResult.ConvertedValue = IntegerTotal;
                     TotalConversionResult.ExceptionText = "";
                 }
             }
             catch (Exception ex)
             {
                 //MessageBox.Show(ex.Message);
                 TotalConversionResult.IsConverted = false;
                 TotalConversionResult.ConvertedValue = -1;
                 TotalConversionResult.ExceptionText = ex.Message;
             }  

            return TotalConversionResult;
        }
    }
}
