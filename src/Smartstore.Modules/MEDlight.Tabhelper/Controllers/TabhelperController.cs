using MEDlight.Tabhelper.Models;
using Microsoft.AspNetCore.Mvc;
using Smartstore.ComponentModel;
using Smartstore.Core.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartstore;
using Smartstore.ComponentModel;
using Smartstore.Core.Data;
using Smartstore.Web.Controllers;
using Smartstore.Web.Modelling.Settings;


namespace MEDlight.Tabhelper.Controllers
{
    public class TabsTutorialController : PublicController
    {
        [LoadSetting]
        public IActionResult GetTab()
        {
            

            return View();
        }
    }
}