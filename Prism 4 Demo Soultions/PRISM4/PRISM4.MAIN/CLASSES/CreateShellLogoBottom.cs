using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;

using PRISM4.MAIN.FORMS;

namespace PRISM4.MAIN.CLASSES
{
    public class CreateShellLogoBottom : ICreateShellForm
    {
   
         private Window Shell;

         public CreateShellLogoBottom(ShellLogoBottom Shell)
        {
            if (Shell != null)
            {
                this.Shell = Shell;
                CreateShellForm();
            }
        }        

        public Window CreateShellForm()
        {
            Shell.Show();
            return Shell;
        }

    }
}
