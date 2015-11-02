using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES
{
    public interface IUpdateUIState
    {       
        bool TextBox1ExceptionState { get; }
        bool TextBox2ExceptionState { get; }        

        bool BothTextBoxesBlankOrClearState { get; }
        bool TextBox1HasValueState { get; }
        bool TextBox1AndTextBox2HasValueState { get; }

        string FormulaText { get; set; }
        string StatusText { get; set; }
    }
}
