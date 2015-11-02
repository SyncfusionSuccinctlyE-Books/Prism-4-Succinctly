using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.STATUS_SERVICE
{
    public class CalculatingStatus : IStatus
    {
        private const string StatusText = "Current Status: Calculating...";

        public string GetStatus()
        {
            return StatusText.Trim();
        }
    }
}
