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

using PRISM4.APPLICATION_LOGO_MODULE.VIEWS;

namespace PRISM4.APPLICATION_LOGO_MODULE
{
    [Module(
        ModuleName = "APPLICATION_LOGO_MODULE",
        OnDemand = false)]
    public class APPLICATION_LOGO_MODULE : IModule
    {        
        private IRegionManager RegionManager { get; set; }
        private  ApplicationLogoView ApplicationLogoView;

        //Constructor:
        public APPLICATION_LOGO_MODULE(
            IRegionManager regionManager, 
            ApplicationLogoView ApplicationLogoView)
        {            
            this.RegionManager = regionManager;
            this.ApplicationLogoView = ApplicationLogoView;
        }

        //Add the Module Views to the Regions here:
        public void Initialize()
        {
            ///Add the user control to the region here:
            IRegion ApplicationRegion = RegionManager.Regions["ApplicationRegion"];

            ApplicationRegion.Add(ApplicationLogoView, "ApplicationLogoView");            
        }

    }
}
