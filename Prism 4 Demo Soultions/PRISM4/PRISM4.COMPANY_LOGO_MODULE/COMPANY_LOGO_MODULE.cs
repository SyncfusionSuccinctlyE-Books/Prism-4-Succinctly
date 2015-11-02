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

using PRISM4.COMPANY_LOGO_MODULE.VIEWS;

namespace PRISM4.COMPANY_LOGO_MODULE
{
    [Module(
    ModuleName = "COMPANY_LOGO_MODULE",
    OnDemand = false)]
    public class COMPANY_LOGO_MODULE : IModule
    {

        private IRegionManager RegionManager { get; set; }
        private CompanyLogoView CompanyLogoView;

        //Constructor:
        public COMPANY_LOGO_MODULE(
            IRegionManager RegionManager,
            CompanyLogoView CompanyLogoView)
        {
            if (RegionManager != null)
            {
                this.RegionManager = RegionManager;
            }

            if (CompanyLogoView != null)
            {
                this.CompanyLogoView = CompanyLogoView;
            }
        }

        //Add the Module Views to the Regions here:
        public void Initialize()
        {
            ///Add the user control to the region here:
            IRegion CompanyRegion = RegionManager.Regions["CompanyRegion"];

            CompanyRegion.Add(CompanyLogoView, "CompanyLogoView");            
        }

    }
}
