
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Regions;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace PRISM4.MAIN.REGION_ADAPTERS
{
    public class SyncfusionTabCtrlRegionAdapter
    : RegionAdapterBase<TabControlExt>
    {
        public SyncfusionTabCtrlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TabControlExt regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var tab in region.Views.Cast<FrameworkElement>())
                {
                    if (!regionTarget.Items.Contains(tab))
                    {
                        regionTarget.Items.Add(tab);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }        
    }
}