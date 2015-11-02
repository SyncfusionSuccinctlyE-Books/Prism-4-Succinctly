using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES
{
    public class CalculatorExceptionController : ICalculatorExceptionController
    {
        private ObservableCollection<ExceptionResult> ExceptionResults = new ObservableCollection<ExceptionResult>();
        private ExceptionResult ExceptionResult32Bit = new ExceptionResult();
       
        public CalculatorExceptionController()
        {                       
            GenerateExceptions();
        }


        public ExceptionResult GetException(int index)
        {
            ExceptionResult32Bit = ExceptionResults[index];
            return ExceptionResult32Bit;
        }

        public void AddException(ExceptionResult ExceptionResult)
        {
            ExceptionResults.Add(ExceptionResult);            
        }

        public int ClearAllExceptions()
        {
            int ExceptionResultCount;

            ExceptionResults.Clear();

            ExceptionResultCount = ExceptionResults.Count();

            return ExceptionResultCount;
        }

        public int GenerateExceptions()
        {
            ClearAllExceptions();

            int ExceptionResultCount = 0;

                ExceptionResult32Bit.ExceptionId = 0;

                ExceptionResult32Bit.ExceptionText =
                    "Current Status: FAIL!" +                                                          
                    Environment.NewLine +
                    Environment.NewLine +
                    "Error: " +
                    Environment.NewLine +
                    "The value entered is not a valid signed 32bit integer (int)." +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Resolution: " +
                    Environment.NewLine +
                    "Signed 32 bit integer values are numeric digits between 0 and 9." +
                    Environment.NewLine +
                    "Signed 32 bit integers can contain values between: -2147483648 and 2147483647 only." +
                    Environment.NewLine +
                    "They can be prefixed with the minus (-) or the plus (+) signs." +
                    Environment.NewLine +
                    "Alpha Characters (A-Z or a-z) are not allowed." +
                    Environment.NewLine +
                    "Symbols (#, @, %, *, ! etc.) are not allowed." +
                    Environment.NewLine +
                    "Commas (,) are not allowed." +
                    Environment.NewLine +
                    "Signed 32 bit integers do not allow fractions such as 12.5." +
                    Environment.NewLine +
                    "Some examples of valid integers are: -2567, 104, 297843 +746, 10000, 2147483647, -2147483.";

               
                AddException(ExceptionResult32Bit);
                
                ExceptionResultCount = ExceptionResults.Count;

                return ExceptionResultCount;
        }
    }
}
