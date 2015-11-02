using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE
{
    public class Validate64BitSignedInteger : IValidateInteger
    {
        private const int Signed64BitIntegerExceptionId = 1;

        private IntegerValidationResult Result;
        private ExceptionResult ExceptionResult;
        private ICalculatorExceptionController ExceptionController;

        public Validate64BitSignedInteger(
            IntegerValidationResult Result, 
            ExceptionResult ExceptionResult, 
            ICalculatorExceptionController ExceptionController)
        {
            if (ExceptionResult != null)
            {
                this.ExceptionResult = ExceptionResult;
            }

            if (Result != null)
            {
                this.Result = Result;
            }

            if (ExceptionController != null)
            {
                this.ExceptionController = ExceptionController;
            }
        }

        public IntegerValidationResult Validate(string TextToValidate)
        {
            long IsValidated;

            Result.IsValidated = long.TryParse(TextToValidate, out IsValidated);

            if (Result.IsValidated == true)
            {
                Result.ExceptionId = -1;
                Result.ValidatedText = "";
            }
            else
            {

                Result.ExceptionId = Signed64BitIntegerExceptionId;
                Result.ValidatedText = TextToValidate;

                GetException(Result.ExceptionId);
            }

            return Result;
        }

        public ExceptionResult GetException(int ExceptionId)
        {
            ExceptionResult = ExceptionController.GetException(ExceptionId);

            return ExceptionResult;
        }
    }
}
