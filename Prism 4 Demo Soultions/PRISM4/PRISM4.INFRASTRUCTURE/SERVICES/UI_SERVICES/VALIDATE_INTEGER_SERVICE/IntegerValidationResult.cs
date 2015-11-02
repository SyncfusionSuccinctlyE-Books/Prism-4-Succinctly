using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE
{
    public class IntegerValidationResult
    {
        public bool IsValidated { get; set; }
        public int ExceptionId { get; set; }
        public string ValidatedText { get; set; }
    }
}
