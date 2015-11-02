using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows;

using Microsoft.SqlServer;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Logging;

using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.DESCRIPTION_SERVICES;

using PRISM4.MATH_MODULE.MODELS;

namespace PRISM4.MATH_MODULE.VIEW_MODELS
{
    public class SubtractTwoViewModel : INotifyPropertyChanged
    {
        #region CLASS PROPERTIES AND MEMBERS

        #region CLASS CONSTANTS

        private const string SubtractIntegersTabHeaderText = "Subtract Two Integers";
        private const string SubtractIntegersGroupboxHeaderText = "Subtract Integers";

        #endregion //END CLASS CONSTANTS REGION

        #region CLASS SINGLE MEMBERS

        private IEventAggregator EventAggregator;
        private UpdateSubtractUIModel UIModel;
        private IUpdateUIState CurrentUIState;
        private bool ClearFlag = false;
        private ObservableCollection<string> IntegerStrings = new ObservableCollection<string>();
        private string IntegerTotal = "";

        private SubtractTwoModel SubtractIntegers;

        private IDescription Description;
        private DescriptionResult DescriptionResult;

        #endregion //END CLASS SINGLE MEMBERS REGION


        #region GENERAL CLASS PROPERTIES AND MEMBERS               

        private string TAB_HEADER_TEXT;
        public string TabHeaderText
        {
            get
            {
                return TAB_HEADER_TEXT;
            }

            set
            {
                if (TAB_HEADER_TEXT != value)
                {
                    TAB_HEADER_TEXT = value;
                    NotifyPropertyChanged("TabHeaderText");
                }
            }
        }

        private string GROUP_BOX__HEADER_TEXT;
        public string GroupBoxHeaderText
        {
            get
            {
                return GROUP_BOX__HEADER_TEXT;
            }

            set
            {
                if (GROUP_BOX__HEADER_TEXT != value)
                {
                    GROUP_BOX__HEADER_TEXT = value;
                    NotifyPropertyChanged("GroupBoxHeaderText");
                }
            }
        }

        private bool TEXT_BOX_1_EXCEPTION;
        public bool TextBox1Exception
        {
            get
            {
                return TEXT_BOX_1_EXCEPTION;
            }

            set
            {
                if (TEXT_BOX_1_EXCEPTION != value)
                {
                    TEXT_BOX_1_EXCEPTION = value;
                    NotifyPropertyChanged("TextBox1Exception");
                }
            }
        }

        private bool TEXT_BOX_2_EXCEPTION;
        public bool TextBox2Exception
        {
            get
            {
                return TEXT_BOX_2_EXCEPTION;
            }

            set
            {
                if (TEXT_BOX_2_EXCEPTION != value)
                {
                    TEXT_BOX_2_EXCEPTION = value;
                    NotifyPropertyChanged("TextBox2Exception");
                }
            }
        }

        private bool BOTH_TEXT_BOXES_BLANK_OR_CLEAR;
        public bool BothTextBoxesBlankOrClear
        {
            get
            {
                return BOTH_TEXT_BOXES_BLANK_OR_CLEAR;
            }

            set
            {
                if (BOTH_TEXT_BOXES_BLANK_OR_CLEAR != value)
                {
                    BOTH_TEXT_BOXES_BLANK_OR_CLEAR = value;
                    NotifyPropertyChanged("BothTextBoxesBlankOrClear");
                }
            }
        }

        private bool TEXT_BOX_1_HAS_VALUE;
        public bool TextBox1HasValue
        {
            get
            {
                return TEXT_BOX_1_HAS_VALUE;
            }

            set
            {
                if (TEXT_BOX_1_HAS_VALUE != value)
                {
                    TEXT_BOX_1_HAS_VALUE = value;
                    NotifyPropertyChanged("TextBox1HasValue");
                }
            }
        }

        private bool TEXT_BOX_1_AND_TEXT_BOX_2_HAS_VALUE;
        public bool TextBox1AndTextbox2HasValue
        {
            get
            {
                return TEXT_BOX_1_AND_TEXT_BOX_2_HAS_VALUE;
            }

            set
            {
                if (TEXT_BOX_1_AND_TEXT_BOX_2_HAS_VALUE != value)
                {
                    TEXT_BOX_1_AND_TEXT_BOX_2_HAS_VALUE = value;
                    NotifyPropertyChanged("TextBox1AndTextbox2HasValue");
                }
            }
        }

        private string TEXT_BOX_ONE_TEXT;
        public string TextBoxOneText
        {
            get
            {
                return TEXT_BOX_ONE_TEXT;
            }

            set
            {
                if (TEXT_BOX_ONE_TEXT != value)
                {
                    TEXT_BOX_ONE_TEXT = value;
                    NotifyPropertyChanged("TextBoxOneText");
                }
            }
        }

        private string TEXT_BOX_TWO_TEXT;
        public string TextBoxTwoText
        {
            get
            {
                return TEXT_BOX_TWO_TEXT;
            }

            set
            {
                if (TEXT_BOX_TWO_TEXT != value)
                {
                    TEXT_BOX_TWO_TEXT = value;
                    NotifyPropertyChanged("TextBoxTwoText");
                }
            }
        }

        private string TEXT_BOX_TOTAL_TEXT;
        public string TextBoxTotalText
        {
            get
            {
                return TEXT_BOX_TOTAL_TEXT;
            }

            set
            {
                if (TEXT_BOX_TOTAL_TEXT != value)
                {
                    TEXT_BOX_TOTAL_TEXT = value;
                    NotifyPropertyChanged("TextBoxTotalText");
                }
            }
        }

        private string STATUS_TEXTBOX_TEXT;
        public string StatusTextboxText
        {
            get
            {
                return STATUS_TEXTBOX_TEXT;
            }

            set
            {
                if (STATUS_TEXTBOX_TEXT != value)
                {
                    STATUS_TEXTBOX_TEXT = value;
                    NotifyPropertyChanged("StatusTextboxText");
                }
            }
        }

        private string FORMULA_TEXTBOX_TEXT;
        public string FormulaTextboxText
        {
            get
            {
                return FORMULA_TEXTBOX_TEXT;
            }

            set
            {
                if (FORMULA_TEXTBOX_TEXT != value)
                {
                    FORMULA_TEXTBOX_TEXT = value;
                    NotifyPropertyChanged("FormulaTextboxText");
                }
            }
        }

        private string DESCRIPTION_TEXTBOX_TEXT = "";
        public string DescriptionTextboxText
        {
            get
            {
                return DESCRIPTION_TEXTBOX_TEXT;
            }

            set
            {
                if (DESCRIPTION_TEXTBOX_TEXT != value)
                {
                    DESCRIPTION_TEXTBOX_TEXT = value;
                    NotifyPropertyChanged("DescriptionTextboxText");
                }
            }
        }

        #endregion //END GENERAL CLASS PROPERTIES AND MEMBERS REGION


        #region COMMAND CLASS PROPERTIES AND MEMBERS

        private ICommand TAB_LOADED_COMMAND;
        public ICommand TabLoadedCommand
        {
            get
            {
                return TAB_LOADED_COMMAND;
            }

            set
            {
                if (TAB_LOADED_COMMAND != value)
                {
                    TAB_LOADED_COMMAND = value;
                    NotifyPropertyChanged("TabLoadedCommand");
                }
            }
        }

        private ICommand TEXT_BOX_ONE_TEXT_CHANGED_COMMAND;
        public ICommand TextBoxOneTextChangedCommand
        {
            get
            {
                return TEXT_BOX_ONE_TEXT_CHANGED_COMMAND;
            }

            set
            {
                if (TEXT_BOX_ONE_TEXT_CHANGED_COMMAND != value)
                {
                    TEXT_BOX_ONE_TEXT_CHANGED_COMMAND = value;
                    NotifyPropertyChanged("TextBoxOneTextChangedCommand");
                }
            }
        }

        private ICommand TEXT_BOX_TWO_TEXT_CHANGED_COMMAND;
        public ICommand TextBoxTwoTextChangedCommand
        {
            get
            {
                return TEXT_BOX_TWO_TEXT_CHANGED_COMMAND;
            }

            set
            {
                if (TEXT_BOX_TWO_TEXT_CHANGED_COMMAND != value)
                {
                    TEXT_BOX_TWO_TEXT_CHANGED_COMMAND = value;
                    NotifyPropertyChanged("TextBoxTwoTextChangedCommand");
                }
            }
        }

        private ICommand CLEAR_BUTTON_CLICK_COMMAND;
        public ICommand ClearButtonClickCommand
        {
            get
            {
                return CLEAR_BUTTON_CLICK_COMMAND;
            }

            set
            {
                if (CLEAR_BUTTON_CLICK_COMMAND != value)
                {
                    CLEAR_BUTTON_CLICK_COMMAND = value;
                    NotifyPropertyChanged("ClearButtonClickCommand");
                }
            }
        }

        private ICommand CALCULATE_BUTTON_CLICK_COMMAND;
        public ICommand CalculateButtonClickCommand
        {
            get
            {
                return CALCULATE_BUTTON_CLICK_COMMAND;
            }

            set
            {
                if (CALCULATE_BUTTON_CLICK_COMMAND != value)
                {
                    CALCULATE_BUTTON_CLICK_COMMAND = value;
                    NotifyPropertyChanged("CalculateButtonClickCommand");
                }
            }
        }

        #endregion //END COMMAND CLASS PROPERTIES AND MEMBERS REGION


        #endregion //END CLASS PROPERTIES AND MEMBERS REGION


        #region CLASS CONSTRUCTOR

        public SubtractTwoViewModel
            (IEventAggregator EventAggregator, 
            UpdateSubtractUIModel UIModel, 
            IUpdateUIState CurrentUIState,
            SubtractTwoModel SubtractIntegers, 
            IDescription Description, 
            DescriptionResult DescriptionResult)
        {
            if (EventAggregator != null)
            {
                this.EventAggregator = EventAggregator;
            }

            if (UIModel != null)
            {
                this.UIModel = UIModel;
            }

            if (SubtractIntegers != null)
            {
                this.SubtractIntegers = SubtractIntegers;
            }

            if (Description != null)
            {
                this.Description = Description;
            }

            if (DescriptionResult != null)
            {
                this.DescriptionResult = DescriptionResult;
            }

            SetDescriptionText();
            SetHeaderValues();
            ResetUserInterface();

            TAB_LOADED_COMMAND = new DelegateCommand(OnTabLoad);
            TEXT_BOX_ONE_TEXT_CHANGED_COMMAND = new DelegateCommand<string>(OnTextBoxOneTextChanged);
            TEXT_BOX_TWO_TEXT_CHANGED_COMMAND = new DelegateCommand<string>(OnTextBoxTwoTextChanged);
            CLEAR_BUTTON_CLICK_COMMAND = new DelegateCommand(OnClearButtonClick);
            CALCULATE_BUTTON_CLICK_COMMAND = new DelegateCommand(OnCalculateButtonClick);
        }


        #endregion //END CLASS CONSTRUCTOR REGION


        #region CLASS METHODS

        private void SetDescriptionText()
        {
            DescriptionResult =  Description.GetDescription(1);

            if (DescriptionResult.Description.Length > 0)
            {
                DescriptionTextboxText = DescriptionResult.Description;
            }
        }

        private void SetHeaderValues()
        {
            TabHeaderText = SubtractIntegersTabHeaderText;
            GroupBoxHeaderText = SubtractIntegersGroupboxHeaderText;
        }

        private void ResetUserInterface()
        {
            TextBox1Exception = false;
            TextBox2Exception = false;

            BothTextBoxesBlankOrClear = false;
            TextBox1HasValue = false;
            TextBox1AndTextbox2HasValue = false;
        }

        #region CLASS GENERAL METHODS

      
        #endregion //END CLASS GENERAL METHODS REGION


        #region CLASS COMMAND DELEGATE METHODS

        private void OnTabLoad()
        {
            ResetUserInterface();
            CurrentUIState = UIModel.ClearUI();
            BothTextBoxesBlankOrClear = CurrentUIState.BothTextBoxesBlankOrClearState;            
        }        

        private void OnTextBoxOneTextChanged(string Textbox1Text)
        {
            if (ClearFlag == false)
            {
                TextBoxOneText = Textbox1Text;
            }           
            
            ResetUserInterface();

            IntegerStrings.Clear();
            IntegerStrings.Add(TextBoxOneText);
            IntegerStrings.Add(TextBoxTwoText);

            IntegerTotal = TextBoxTotalText;

            CurrentUIState = UIModel.TextBox1HasValueState(IntegerStrings, IntegerTotal);

            StatusTextboxText = CurrentUIState.StatusText;
            FormulaTextboxText = CurrentUIState.FormulaText;
           
            TextBox1Exception = CurrentUIState.TextBox1ExceptionState;
            TextBox2Exception = CurrentUIState.TextBox2ExceptionState;            
            TextBox1HasValue = CurrentUIState.TextBox1HasValueState;
            TextBox1AndTextbox2HasValue = CurrentUIState.TextBox1AndTextBox2HasValueState;
            BothTextBoxesBlankOrClear = CurrentUIState.BothTextBoxesBlankOrClearState;
                          
        }

        private void OnTextBoxTwoTextChanged(string Textbox2Text)
        {
            if (ClearFlag == false)
            {
                TextBoxTwoText = Textbox2Text;
            }

            ResetUserInterface();

            IntegerStrings.Clear();
            IntegerStrings.Add(TextBoxOneText);
            IntegerStrings.Add(TextBoxTwoText);

            IntegerTotal = TextBoxTotalText;

            CurrentUIState = UIModel.TextBox1And2HaveValuesState(IntegerStrings, IntegerTotal);

            StatusTextboxText = CurrentUIState.StatusText;
            FormulaTextboxText = CurrentUIState.FormulaText;
            
            TextBox1Exception = CurrentUIState.TextBox1ExceptionState;
            TextBox2Exception = CurrentUIState.TextBox2ExceptionState;    
            TextBox1HasValue = CurrentUIState.TextBox1HasValueState;
            TextBox1AndTextbox2HasValue = CurrentUIState.TextBox1AndTextBox2HasValueState;
            BothTextBoxesBlankOrClear = CurrentUIState.BothTextBoxesBlankOrClearState;     
        }

        private void OnClearButtonClick()
        {
            ClearFlag = true;

            TextBoxOneText = "";
            TextBoxTwoText = "";
            TextBoxTotalText = "";

            ResetUserInterface();
            CurrentUIState = UIModel.ClearUI();
            BothTextBoxesBlankOrClear = CurrentUIState.BothTextBoxesBlankOrClearState;

            ClearFlag = false;
        }

        private void OnCalculateButtonClick()
        {                       
            TextBoxTotalText = SubtractIntegers.SubtractIntegers(IntegerStrings);

            if (IntegerStrings != null && TextBoxTotalText != null)
            {
                FormulaTextboxText = SubtractIntegers.GetFormula(IntegerStrings, TextBoxTotalText);
            }            
        }

        #endregion //END CLASS COMMAND DELEGATE METHODS REGION

        #endregion //END CLASS METHODS REGION


        #region I NOTIFY PROPERTY CHANGED

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        #endregion  //END I NOTIFY PROPERTY CHANGED REGION
    }
}
