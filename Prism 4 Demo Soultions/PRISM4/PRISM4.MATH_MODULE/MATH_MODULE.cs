using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Events;

using System.Windows;
using System.Data;

using PRISM4.MATH_MODULE.VIEWS;

namespace PRISM4.MATH_MODULE
{
    [Module(
    ModuleName = "MATH_MODULE",
    OnDemand = false)]
    public class MATH_MODULE : IModule
    {

        private IRegionManager RegionManager { get; set; }
        private AddTwoView AddTwoView;               
        private SubtractView SubtractView;        

        //Constructor:
        public MATH_MODULE(
            IRegionManager RegionManager,
            AddTwoView AddTwoView,            
            SubtractView SubtractView)
        {
            if (RegionManager != null)
            {
                this.RegionManager = RegionManager;
            }

            if (AddTwoView != null)
            {                
                this.AddTwoView = AddTwoView;                
            }
            

            if (SubtractView != null)
            {
                this.SubtractView = SubtractView;
            }           
        }

        //Add the Module Views to the Regions here:
        public void Initialize()
        {
            ///Add the user controls to the region here:
            IRegion MathRegion = RegionManager.Regions["MathRegion"];

            MathRegion.Add(this.AddTwoView, "AddTwoView");
            MathRegion.Add(SubtractView, "SubtractView");           
        }        
    }
}
