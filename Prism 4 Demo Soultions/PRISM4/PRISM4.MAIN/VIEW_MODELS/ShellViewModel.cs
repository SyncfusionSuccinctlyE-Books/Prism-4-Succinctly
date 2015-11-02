
using System;
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

namespace PRISM4.MAIN.VIEW_MODELS
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        #region CLASS PROPERTIES AND MEMBERS


        #region CLASS SINGLE MEMBERS
        
        IEventAggregator EventAggregator;

        #endregion //END CLASS SINGLE MEMBERS REGION


        #region GENERAL CLASS PROPERTIES AND MEMBERS

        

        #endregion //END GENERAL CLASS PROPERTIES AND MEMBERS REGION


        #region COMMAND CLASS PROPERTIES AND MEMBERS

        #endregion //END COMMAND CLASS PROPERTIES AND MEMBERS REGION


        #endregion //END CLASS PROPERTIES AND MEMBERS REGION


        #region CLASS CONSTRUCTOR        

        public ShellViewModel(IEventAggregator EventAggregator)
        {

            if (EventAggregator == null)
            {
                throw new NullReferenceException("EventAggregator");
            }

            this.EventAggregator = EventAggregator;            
        }

        #endregion //END CLASS CONSTRUCTOR REGION


        #region CLASS METHODS

        #region CLASS GENERAL METHODS

        #endregion //END CLASS GENERAL METHODS REGION


        #region CLASS COMMAND DELEGATE METHODS

        #region ENTER COMMAND DELEGATE ON AND CAN METHODS

        #endregion // END ENTER COMMAND DELEGATE ON AND CAN METHODS REGION

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
