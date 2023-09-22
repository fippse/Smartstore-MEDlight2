global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.Linq;
global using System.Threading.Tasks;
global using Smartstore.Web.Modelling;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Smartstore.Engine.Modularity;
using Smartstore.Http;

namespace MEDlight.Tabhelper
{
    internal class Module : ModuleBase
    {

        public override async Task InstallAsync(ModuleInstallationContext context)
        {

            // Imports all language resources for the current module from 
            // xml files in "Localization" directory (if any found).
            await ImportLanguageResourcesAsync();

            // VERY IMPORTANT! Don't forget to call.
            await base.InstallAsync(context);
        }

        public override async Task UninstallAsync()
        {;

            // Deletes all language resource for the current module 
            // if "ResourceRootKey" is module.json is not empty.
            await DeleteLanguageResourcesAsync();

            // VERY IMPORTANT! Don't forget to call.
            await base.UninstallAsync();
        }
    }
}
