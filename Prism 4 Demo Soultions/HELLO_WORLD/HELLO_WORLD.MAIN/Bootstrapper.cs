using System;
using System.Windows;

using Microsoft.Practices.Prism;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace HELLO_WORLD.MAIN
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {            
            //Create and show the Prism 4 shell form:
            MainWindow Shell = Container.Resolve<MainWindow>();

            Shell.Show();
            return Shell;
        }           
    }
}
