using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using System.Web;
using Sitecore.Feature.Fxm.Controls;

namespace Sitecore.Feature.Fxm.Models
{
    public class FxmItemRendererModel
    {
        private Item _item = null;

        public FxmItemRendererModel()
        {

        }

        public FxmItemRendererModel(Item item)
        {
            _item = item;
        }

        public IHtmlString DataSourceHtml
        {
            get
            {
                if (_item == null)
                    return new HtmlString("<div>Please specify a Data Source</div>");

                return new HtmlString(new ItemRenderer(_item).Render()); ;
            }
        }
    }
}
