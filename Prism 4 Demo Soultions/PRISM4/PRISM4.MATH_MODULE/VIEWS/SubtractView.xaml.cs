using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;

using PRISM4.MATH_MODULE.VIEW_MODELS;
using Syncfusion.Windows.Tools.Controls;

namespace PRISM4.MATH_MODULE.VIEWS
{
    /// <summary>
    /// Interaction logic for SubtractView.xaml
    /// </summary>
    public partial class SubtractView : TabItemExt
    {
        private SubtractTwoViewModel ViewModel;

        public SubtractView(SubtractTwoViewModel ViewModel)
        {
            InitializeComponent();


            if (ViewModel != null)
            {
                this.ViewModel = ViewModel;
            }

            this.DataContext = this.ViewModel;
        }
    }
}
