using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES
{
    public class TextboxOneAndTwoBlankOrClearState : IUpdateUIState
    {
        private bool TEXTBOX_1_EXCEPTION_STATE = false;
        public bool TextBox1ExceptionState
        {
            get
            {
                return TEXTBOX_1_EXCEPTION_STATE;
            }
        }

        private bool TEXTBOX_2_EXCEPTION_STATE = false;
        public bool TextBox2ExceptionState
        {
            get
            {
                return TEXTBOX_2_EXCEPTION_STATE;
            }
        }       

        private bool BOTH_TEXTBOXES_BLANK_OR_CLEAR_STATE = true;
        public bool BothTextBoxesBlankOrClearState
        {
            get
            {
                return BOTH_TEXTBOXES_BLANK_OR_CLEAR_STATE;
            }
        }

        private bool TEXTBOX_1_HAS_VALUE_STATE = false;
        public bool TextBox1HasValueState
        {
            get
            {
                return TEXTBOX_1_HAS_VALUE_STATE;
            }
        }

        private bool TEXTBOX_1_AND_TEXTBOX_2_HAS_VALUE_STATE = false;
        public bool TextBox1AndTextBox2HasValueState
        {
            get
            {
                return TEXTBOX_1_AND_TEXTBOX_2_HAS_VALUE_STATE;
            }
        }

        private string FORMULA_TEXT;
        public string FormulaText
        {
            get
            {
                return FORMULA_TEXT;
            }

            set
            {
                if (FORMULA_TEXT != value)
                {
                    FORMULA_TEXT = value;
                }
            }
        }

        private string STATUS_TEXT;
        public string StatusText
        {
            get
            {
                return STATUS_TEXT;
            }

            set
            {
                if (STATUS_TEXT != value)
                {
                    STATUS_TEXT = value;
                }
            }
        }
    }
}
