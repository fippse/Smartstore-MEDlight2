using MEDlight.Tabhelper.Models;
using Smartstore.Events;
using Smartstore.Web.Rendering.Events;
using System.Threading.Tasks;
using Smartstore.Web.Modelling;
using Smartstore.Core.Data;
using System.Threading.Tasks;
using Smartstore;
using Smartstore.Core.Data;
using Smartstore.Events;
using Smartstore.Web.Modelling;
using Smartstore.Web.Rendering.Events;

namespace MEDlight.Tabhelper
{
    public class Events : IConsumer
    {
        private readonly SmartDbContext _db;

        public Events(SmartDbContext db)
        {
            _db = db;
        }

        public async Task HandleEventAsync(TabStripCreated eventMessage)
        {
            var tabStripName = eventMessage.TabStripName;

            if (tabStripName == "product-edit")
            {
                var entityId = ((TabbableModel)eventMessage.Model).Id;

                await eventMessage.TabFactory.AppendAsync(builder => builder
                    .Text("My Tab")
                    .Name("tab-MyTab")
                    .Icon("star", "bi")
                    .LinkHtmlAttributes(new { data_tab_name = "MyTab" })
                    .Action("GetTab", "Tabhelper", new { entityId })
                    .Ajax(true));
            }
        }

    }
}