using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES
{
    public interface ICalculatorExceptionController
    {
        ExceptionResult GetException(int index);
        void AddException(ExceptionResult ExceptionResult);
        int GenerateExceptions();
        int ClearAllExceptions();
    }
}
