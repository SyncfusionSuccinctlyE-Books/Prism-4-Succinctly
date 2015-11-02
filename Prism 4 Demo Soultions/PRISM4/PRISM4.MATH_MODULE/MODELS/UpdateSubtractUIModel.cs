using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES;

namespace PRISM4.MATH_MODULE.MODELS
{
    public class UpdateSubtractUIModel
    {
        private UpdateSubtractionUserInterface UpdateUI;
        private IUpdateUIState CurrentState;

        public UpdateSubtractUIModel
            (UpdateSubtractionUserInterface UpdateUI)
        {
            if (UpdateUI != null)
            {
                this.UpdateUI = UpdateUI;
            }
        }

        public IUpdateUIState ClearUI()
        {
            CurrentState = UpdateUI.ClearButtonClicked();
            return CurrentState;
        }

        public IUpdateUIState TextBox1HasValueState
            (ObservableCollection<string> IntegerStrings, 
            string IntegerTotal)
        {
            CurrentState = UpdateUI.CharacterEnteredOrAppendedToTextboxOne
                (IntegerStrings,
                IntegerTotal);

            return CurrentState;
        }

        public IUpdateUIState TextBox1And2HaveValuesState
          (ObservableCollection<string> IntegerStrings,
          string IntegerTotal)
        {
            CurrentState = UpdateUI.CharacterEnteredOrAppendedToTextboxTwo
            (IntegerStrings,
            IntegerTotal);

            return CurrentState;
        }
    }
}
