using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.DESCRIPTION_SERVICES
{
    public class Description : IDescription
    {        
        private ObservableCollection<DescriptionResult> DescriptionResults = new ObservableCollection<DescriptionResult>();
        private DescriptionResult DescriptionResult = new DescriptionResult();

        public Description()
        {
            GenerateDescriptions();
        }

        public DescriptionResult GetDescription(int Index)
        {
            if (Index > DescriptionResults.Count())
            {               
                throw new ArgumentOutOfRangeException();
            }
            
            DescriptionResult = DescriptionResults[Index];
            
            return DescriptionResult;
        }

        public void AddDescription(string DescriptionText, int ExceptionId)
        {
            DescriptionResult Result = new DESCRIPTION_SERVICES.DescriptionResult();

            Result.Description = DescriptionText;
            Result.ExceptionId = ExceptionId;

            DescriptionResults.Add(Result);                       
        }

        public void GenerateDescriptions()
        {
            DescriptionResults.Clear();

            GenerateAddTwoIntegersDescriptions();            
            GenerateSubtractIntegersDescriptions();            
        }

        public void GenerateAddTwoIntegersDescriptions()
        {
            string AddTwoIntegersText =
            "Add Two Integers Demonstration View: " +
            Environment.NewLine +
            Environment.NewLine +
            "The add two integers code consists of a View, " +
            "view model and two model classes. It uses a " +  
            "number of classes from the Infrastructure project, " + 
            "including classes to add two integers, validate " + 
            "that text input is valid and classes to handle " + 
            "UI updates and exceptions. " + 
            Environment.NewLine +
            Environment.NewLine +
            "The view uses Prism 4 State Based Navigation to " + 
            "insure that the user interface is always in the " + 
            "correct state. The XAML based behaviors trigger " + 
            "associated states which set enables and other " + 
            "properties in the view depending on the current state." + 
            Environment.NewLine +
            Environment.NewLine +
            "The behaviors are triggered by a number of Boolean " + 
            "properties that reside in the view model.  " + 
            Environment.NewLine +
            Environment.NewLine +
            "A number of design patterns are used in this solution " + 
            "including the Strategy and State patterns. Prism 4 " + 
            "includes a number design patterns as well, including the " + 
            "Command pattern , and the Observer pattern which " + 
            "is used in the Event Aggregator. " + 
            Environment.NewLine +
            Environment.NewLine +
            "The business rules for this solution are very simple " + 
            "in order to allow you to better focus on Microsoft " + 
            "Prism 4 constructs. Regular textboxes are used in " + 
            "place of numeric input controls (which would greatly " + 
            "simplify the UI,) to give you an idea of how " + 
            "validation code integrates into Prism 4 solutions." + 
            Environment.NewLine +
            Environment.NewLine +
            "This view allows for the input of two 32 bit integer " + 
            "values. The values are added when the Calculate " + 
            "button is clicked. The Clear button can be used to " + 
            "clear the text values from the three textboxes and " + 
            "reset the user interface's enables." + 
            Environment.NewLine +
            Environment.NewLine +
            "Make sure to test the validation by entering " + 
            "incorrect values in different combinations. " + 
            "Also note how the UI changes as you input " + 
            "values.";

            AddDescription(AddTwoIntegersText, 2);
        }
       
        public void GenerateSubtractIntegersDescriptions()
        {
            string SubtractTwoIntegersText =
            "Subtract Two Integers Demonstration View: " +
            Environment.NewLine +
            Environment.NewLine +
            "The subtract two integers code consists of a View, " +
            "view model and two model classes. It uses a " +
            "number of classes from the Infrastructure project, " +
            "including classes to add two integers, validate " +
            "that text input is valid and classes to handle " +
            "UI updates and exceptions. " +
            Environment.NewLine +
            Environment.NewLine +
            "The view uses Prism 4 State Based Navigation to " +
            "insure that the user interface is always in the " +
            "correct state. The XAML based behaviors trigger " +
            "associated states which set enables and other " +
            "properties in the view depending on the current state." +
            Environment.NewLine +
            Environment.NewLine +
            "The behaviors are triggered by a number of Boolean " +
            "properties that reside in the view model.  " +
            Environment.NewLine +
            Environment.NewLine +
            "A number of design patterns are used in this solution " +
            "including the Strategy and State patterns. Prism 4 " +
            "includes a number design patterns as well, including the " +
            "Command pattern , and the Observer pattern which " +
            "is used in the Event Aggregator. " +
            Environment.NewLine +
            Environment.NewLine +
            "The business rules for this solution are very simple " +
            "in order to allow you to better focus on Microsoft " +
            "Prism 4 constructs. Regular textboxes are used in " +
            "place of numeric input controls (which would greatly " +
            "simplify the UI,) to give you an idea of how " +
            "validation code integrates into Prism 4 solutions." +
            Environment.NewLine +
            Environment.NewLine +
            "This view allows for the input of two 32 bit integer " +
            "values. The values are subtracted when the Calculate " +
            "button is clicked. The Clear button can be used to " +
            "clear the text values from the three textboxes and " +
            "reset the user interface's enables." +
            Environment.NewLine +
            Environment.NewLine +
            "Make sure to test the validation by entering " +
            "incorrect values in different combinations. " +
            "Also note how the UI changes as you input " +
            "values.";
            AddDescription(SubtractTwoIntegersText, 3);
        }
    }
}
