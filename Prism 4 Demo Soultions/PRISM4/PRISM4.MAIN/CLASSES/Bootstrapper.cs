using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Prism;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

using Syncfusion.Windows.Tools.Controls;
using PRISM4.MAIN.REGION_ADAPTERS;

using PRISM4.MAIN.FORMS;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.DESCRIPTION_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.VALIDATE_INTEGER_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.STATUS_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.UI_SERVICES.UPDATE_USER_INTERFACE_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.EXCEPTION_SERVICES;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.STRING_TO_INTEGER_CONVERTER_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATE_SERVICE;
using PRISM4.INFRASTRUCTURE.SERVICES.BUSINESS_SERVICES.CALCULATION_FORMULA_SERVICE;

namespace PRISM4.MAIN.CLASSES
{
    public class MainBootstrapper : UnityBootstrapper
    {
         private Window ShellForm;
         private byte ShellSelector = 0;

        protected override System.Windows.DependencyObject CreateShell()
        {
            //Register services and objects with the Dependency Injection Container.
            CreateServices();

            //Create and show the Prism 4 shell form:            
            ShellForm = CreateShellForm(ShellSelector);

            return ShellForm;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            return configurationCatalog;
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();

            if (mappings != null)
            {
                mappings.RegisterMapping(typeof(TabControlExt),
                this.Container.Resolve<SyncfusionTabCtrlRegionAdapter>());
            }

            return mappings;
        }

        private void CreateServices()
        {
            Container.RegisterType<IValidateInteger, 
                Validate32BitSignedInteger>();

            Container.RegisterType<IValidateInteger, 
                Validate64BitSignedInteger>("IntegerLong");

            Container.RegisterType<IntegerValidationResult>();

            //Setup the Strategy Design Pattern for the shell form:
            Container.RegisterType<ICreateShellForm, 
                CreateShellLogoTop>();

            Container.RegisterType<ICreateShellForm, 
                CreateShellLogoBottom>("LogoBottom");

            Container.RegisterType<ICalculatorExceptionController, 
                CalculatorExceptionController>
                (new ContainerControlledLifetimeManager()); 
           
            Container.RegisterType<ExceptionResult>();            

            Container.RegisterType<IStatus, 
                OkStatus>();

            Container.RegisterType<IStatus, 
                CalculatingStatus>("CalculateStatus");

            Container.RegisterType<IFormula, 
                AddFormula>();

            Container.RegisterType<IFormula, 
                SubtractFormula>("SubtractFormula");

            Container.RegisterType<IConvertInteger, 
                ConvertInteger>();

            Container.RegisterType<ICalculate, 
                AddIntegers>();

            Container.RegisterType<ICalculate, 
                SubtractIntegers>("Subtract");

            Container.RegisterType<IDescription, 
                Description>();            

            Container.RegisterType<IUpdateUIState, 
                TextboxOneAndTwoBlankOrClearState>();

            Container.RegisterType<IUpdateUIState, 
                TextboxOneExceptionState>
                ("TextBoxOneException");       
     
            Container.RegisterType<IUpdateUIState, 
                TextboxTwoExceptionState>
                ("TextBoxTwoException");

            Container.RegisterType<IUpdateUIState, 
                TextboxOneAndTwoExceptionState>
                ("TextBoxOneAndTwoException");

            Container.RegisterType<IUpdateUIState, 
                TextboxOneHasValueState>
                ("TextBoxOneHasValue");   
         
            Container.RegisterType<IUpdateUIState, 
                TextboxOneAndTwoHasValueState>
                ("TextBoxOneAndTwoHaveValues");

            Container.RegisterType<UpdateUserInterface>();
            Container.RegisterType<UpdateSubtractionUserInterface>();    

            Container.RegisterType<Signed32BitIntegerConversionResult>();
            Container.RegisterType<Signed64BitIntegerConversionResult>();

            Container.RegisterType<IDescription, 
                Description>();

            Container.RegisterType<DescriptionResult>();
        }

        private Window CreateShellForm(byte ShellSelector)
        {
            if (ShellSelector == 0)
            {               
                var ShellConverter = Container.Resolve<ICreateShellForm>();
                return ShellForm = ShellConverter.CreateShellForm();
            }
            else
            {                
                var ShellConverter = Container.Resolve<ICreateShellForm>("LogoBottom");
                return ShellForm = ShellConverter.CreateShellForm();
            }
        }
    }
}
