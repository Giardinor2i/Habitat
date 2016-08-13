using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Feature.Fxm.Models;

namespace Sitecore.Feature.Fxm.Controllers
{
    public class FxmItemRendererController : Mvc.Controllers.SitecoreController
    {
        public ActionResult Default()
        {
            FxmItemRendererModel model = null;

            var dataSource = DataSource;
            if (DataSource == null)
                model = new FxmItemRendererModel();

            var item = Sitecore.Context.Database.GetItem(dataSource);
            if (item == null)
                model = new FxmItemRendererModel();
            else
                model = new FxmItemRendererModel(item);

            return View("~/Views/Fxm/Fxm.cshtml", model);
        }

        private string DataSource
        {
            get
            {
                var dataSource = RenderingContext.Current.Rendering.DataSource;

                return string.IsNullOrEmpty(dataSource) ? null : dataSource;
            }
        }
    }
}
