using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.STATUS_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES
{
    public class UpdateUserInterface
    {
        private IUpdateUIState CurrentUIState;

        private IUpdateUIState Textbox1And2BlankOrClearState;
        private IUpdateUIState TextBoxOneHasValueState;
        private IUpdateUIState TextBoxOneAndTwoHaveValuesState;

        private IUpdateUIState TextBoxOneExceptionState;
        private IUpdateUIState TextBoxTwoExceptionState;
        private IUpdateUIState TextBoxOneAndTwoExceptionState;
        
        private ExceptionResult ExceptionResult;

        private IValidateInteger Validate32BitInteger;
        private IntegerValidationResult IntegerValidationResult;

        private bool Textbox1ValidationResult = true;
        private bool Textbox2ValidationResult = true;

        private IStatus OkStatus;
        private IFormula Formula;
        private ObservableCollection<string> FormulaStrings;
        //private string FormulaTotal = "";
        
        private string FormulaText = "";

        public UpdateUserInterface
            (IUpdateUIState Textbox1And2BlankOrClear,
            [Dependency("TextBoxOneHasValue")] IUpdateUIState TextBoxOneHasValue,
            [Dependency("TextBoxOneAndTwoHaveValues")] IUpdateUIState TextBoxOneAndTwoHaveValues,
            [Dependency("TextBoxOneException")] IUpdateUIState TextBoxOneException, 
            [Dependency("TextBoxTwoException")] IUpdateUIState TextBoxTwoException,
            [Dependency("TextBoxOneAndTwoException")] IUpdateUIState TextBoxOneAndTwoException,
            IValidateInteger Validate32BitInteger, 
            IntegerValidationResult IntegerValidationResult, 
            ExceptionResult ExceptionResult,
            IStatus OkStatus,
            IFormula Formula)
        {
            if (Textbox1And2BlankOrClear != null)
            {
                Textbox1And2BlankOrClearState = Textbox1And2BlankOrClear;
            }

            if (TextBoxOneHasValue != null)
            {
                TextBoxOneHasValueState = TextBoxOneHasValue;
            }

            if (TextBoxOneAndTwoHaveValues != null)
            {
                TextBoxOneAndTwoHaveValuesState = TextBoxOneAndTwoHaveValues;
            }

            if (TextBoxOneException != null)
            {
                TextBoxOneExceptionState = TextBoxOneException;
            }

            if (TextBoxTwoException != null)
            {
                TextBoxTwoExceptionState = TextBoxTwoException;
            }

            if (TextBoxOneAndTwoException != null)
            {
                TextBoxOneAndTwoExceptionState = TextBoxOneAndTwoException;
            }

            if (Validate32BitInteger != null)
            {
                this.Validate32BitInteger = Validate32BitInteger;
            }

            if (IntegerValidationResult != null)
            {
                this.IntegerValidationResult = IntegerValidationResult;
            }

            if(ExceptionResult != null)
            {
                this.ExceptionResult = ExceptionResult;
            }

            if (OkStatus != null)
            {
                this.OkStatus = OkStatus;
            }

            if (Formula != null)
            {
                this.Formula = Formula;
            }
        }

        public void SetState(IUpdateUIState State)
        {
            CurrentUIState = State;
        }

        private bool ValidateTextboxText
            (string TextboxText)
        {
            bool TextboxValidationValue = true;

            IntegerValidationResult = Validate32BitInteger.Validate(TextboxText);
            TextboxValidationValue = IntegerValidationResult.IsValidated;

            if (TextboxValidationValue == false)
            {
                ExceptionResult = Validate32BitInteger.GetException(IntegerValidationResult.ExceptionId);                
            }

            return TextboxValidationValue;
        }

        private IUpdateUIState GetExceptionState
            (string Textbox1Text,
            string Textbox2Text)
        {            
                  Textbox1ValidationResult = ValidateTextboxText(Textbox1Text);              
                  Textbox2ValidationResult = ValidateTextboxText(Textbox2Text);            

                  if (Textbox1Text != null &&
                      Textbox1Text.Length > 0 && 
                      Textbox2Text != null &&
                      Textbox2Text.Length > 0)
                  {
                      if (Textbox1ValidationResult == false &&
                          Textbox2ValidationResult == false)
                      {
                          CurrentUIState = TextBoxOneAndTwoExceptionState;
                          CurrentUIState.StatusText = ExceptionResult.ExceptionText;

                          return CurrentUIState;
                      }
                  }

                  if (Textbox1Text != null &&
                      Textbox1Text.Length > 0)
                  {
                      if (Textbox1ValidationResult == false)
                      {
                          CurrentUIState = TextBoxOneExceptionState;
                          CurrentUIState.StatusText = ExceptionResult.ExceptionText;
                          return CurrentUIState;
                      }
                  }

                  if (Textbox2Text != null &&
                      Textbox2Text.Length > 0)
                  {
                      if (Textbox2ValidationResult == false)
                      {
                          CurrentUIState = TextBoxTwoExceptionState;
                          CurrentUIState.StatusText = ExceptionResult.ExceptionText;
                          return CurrentUIState;
                      }
                  }
            return null;
        }

        private IUpdateUIState GetEnabledState
            (string Textbox1Text,
            string Textbox2Text, 
            string TextboxTotalText)
        {
            if (Textbox1Text != null && 
                Textbox1Text.Length <= 0 && 
                Textbox2Text != null && 
                Textbox2Text.Length <= 0)
            {
                CurrentUIState = Textbox1And2BlankOrClearState;                                               
                return CurrentUIState;
            }

                if (Textbox1Text != null && 
                Textbox1Text.Length > 0 && 
                Textbox2Text != null && 
                Textbox2Text.Length > 0)
            {
                CurrentUIState = TextBoxOneAndTwoHaveValuesState;                
            }
            else
            {
                CurrentUIState = TextBoxOneHasValueState;                
            }

                CurrentUIState.StatusText = OkStatus.GetStatus();

                FormulaText = Formula.GenerateFormula
                       (FormulaStrings,
                       TextboxTotalText);

                CurrentUIState.FormulaText = FormulaText.Trim();

            return CurrentUIState;
        }

        public IUpdateUIState CharacterEnteredOrAppendedToTextboxOne
            (ObservableCollection<string> IntegerStrings,
            string IntegerTotal)
        {
            FormulaStrings = IntegerStrings;

            var Textbox1Text = FormulaStrings[0];
            var Textbox2Text = FormulaStrings[1];

            CurrentUIState = GetExceptionState
                (Textbox1Text,
                Textbox2Text);

            if (CurrentUIState != null)
            {
                //Have Exception:
                return CurrentUIState;
            }

            CurrentUIState = GetEnabledState
                (Textbox1Text,
                Textbox2Text,
                IntegerTotal);            

            return CurrentUIState;
        }

        public IUpdateUIState CharacterEnteredOrAppendedToTextboxTwo
            (ObservableCollection<string> IntegerStrings,
            string IntegerTotal)
        {
            FormulaStrings = IntegerStrings;

            var Textbox1Text = FormulaStrings[0];
            var Textbox2Text = FormulaStrings[1];

            CurrentUIState = GetExceptionState
               (Textbox1Text,
               Textbox2Text);

            if (CurrentUIState != null)
            {
                //Have Exception:
                return CurrentUIState;
            }

            CurrentUIState = GetEnabledState
                (Textbox1Text,
                Textbox2Text,
                IntegerTotal);

            return CurrentUIState;
        }

        public IUpdateUIState TextboxOneValueErased
            (string Textbox1Text,
            string Textbox2Text)
        {
            CurrentUIState = TextBoxOneHasValueState;
            return CurrentUIState;
        }        

        public IUpdateUIState ClearButtonClicked()
        {
            CurrentUIState = Textbox1And2BlankOrClearState;
            return CurrentUIState;
        }
    }
}
