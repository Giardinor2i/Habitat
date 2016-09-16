using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Sites;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web;

namespace Sitecore.Feature.Fxm
{
    public static class FxmHelper
    {
        public static SiteContext GetHostSite
        {
            get
            {
                var siteRoot = GetSiteRoot;
                if (siteRoot != null)
                {
                    return SiteContext.GetSite(siteRoot.GetSite().Name);
                }
                
                return null;
            }
        }

        public static Item GetSiteRoot
        {
            get
            {
                if (Sitecore.Context.Item != null && Context.Item.InFxm())
                {
                    var parent = Sitecore.Context.Item.Parent;

                    foreach (Item child in parent.Children)
                    {
                        if (child.TemplateID == Templates.SiteInfo.ID)
                        {
                            ReferenceField field = child.Fields["Site Root"];
                            if (field != null)
                            {
                                return field.TargetItem;
                            }
                        }
                    }
                }

                return null;
            }
        }
    }
}