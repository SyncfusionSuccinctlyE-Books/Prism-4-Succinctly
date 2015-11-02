using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE
{
    public interface IValidateInteger
    {
        IntegerValidationResult Validate(string TextToValidate);
        ExceptionResult GetException(int ExceptionId);
    }
}
