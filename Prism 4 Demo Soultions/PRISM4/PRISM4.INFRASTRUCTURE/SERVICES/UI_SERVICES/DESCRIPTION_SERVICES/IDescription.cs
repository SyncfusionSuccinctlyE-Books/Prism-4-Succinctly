using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.DESCRIPTION_SERVICES
{
    public interface IDescription
    {
        DescriptionResult GetDescription(int Index);
        void AddDescription(string DescriptionText, int ExceptionId);
        void GenerateDescriptions();
    }
}
