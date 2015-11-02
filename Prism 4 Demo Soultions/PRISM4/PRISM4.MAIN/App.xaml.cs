using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PRISM4.MAIN.CLASSES;

namespace PRISM4.MAIN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainBootstrapper PT_Bootstrapper = new MainBootstrapper();
            PT_Bootstrapper.Run();
        }
    }
}
