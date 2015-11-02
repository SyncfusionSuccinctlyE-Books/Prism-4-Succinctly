using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE
{
    public class Validate32BitSignedInteger : IValidateInteger
    {
        private const int Signed32BitIntegerExceptionId = 0;

        private IntegerValidationResult Result;
        private ExceptionResult ExceptionResult;
        private ICalculatorExceptionController ExceptionController;
       
        public Validate32BitSignedInteger
            (IntegerValidationResult Result,
            ICalculatorExceptionController ExceptionController, 
            ExceptionResult ExceptionResult)
        {
            if (ExceptionResult != null)
            {
                this.ExceptionResult = ExceptionResult;
            }

            if (ExceptionController != null)
            {
                this.ExceptionController = ExceptionController;
            }

            if (Result != null)
            {
                this.Result = Result;
            }            
        }

        public IntegerValidationResult Validate(string TextToValidate)
        {
            int IsValidated;

            Result.IsValidated = int.TryParse(TextToValidate, out IsValidated);

            if (Result.IsValidated == true)
            {
                Result.ExceptionId = -1;
                Result.ValidatedText = "";
            }
            else
            {

                Result.ExceptionId = Signed32BitIntegerExceptionId;
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
