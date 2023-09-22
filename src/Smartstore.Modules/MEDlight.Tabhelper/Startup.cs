
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Smartstore.Core;
using Smartstore.Core.Data;
using Smartstore.Core.OutputCache;
using Smartstore.Core.Web;
using Smartstore.Data;
using Smartstore.Data.Providers;
using Smartstore.Diagnostics;
using Smartstore.Engine;
using Smartstore.Engine.Builders;
using Smartstore.Web.Controllers;
using StackExchange.Profiling;
using StackExchange.Profiling.Internal;

namespace MEDlight.Tabhelper
{
    internal class Startup : StarterBase
    {
        public override bool Matches(IApplicationContext appContext)
            => appContext.IsInstalled;

        public override void MapRoutes(EndpointRoutingBuilder builder)
        {
            //builder.MapRoutes(0, routes =>
            //{
            //    //routes.MapControllerRoute("Smartstore.DevTools",
            //    //     "devtools/{action=Configure}/{id?}"
            //    //);
            //});
        }
    }
}