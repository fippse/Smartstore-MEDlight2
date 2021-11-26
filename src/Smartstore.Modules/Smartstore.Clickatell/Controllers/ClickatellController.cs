﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartstore.Clickatell.Models;
using Smartstore.Clickatell.Services;
using Smartstore.Clickatell.Settings;
using Smartstore.ComponentModel;
using Smartstore.Web.Controllers;
using Smartstore.Web.Modelling.Settings;

namespace Smartstore.Clickatell.Controllers
{
    [Area("Admin")]
    public class ClickatellController : ModuleController
    {
        [LoadSetting]
        public IActionResult Configure(ClickatellSettings settings)
        {
            var model = MiniMapper.Map<ClickatellSettings, ConfigurationModel>(settings);
            return View(model);
        }

        [HttpPost, SaveSetting]
        public IActionResult Configure(ConfigurationModel model, ClickatellSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return Configure(settings);
            }

            ModelState.Clear();
            MiniMapper.Map(model, settings);

            return RedirectToAction(nameof(Configure));
        }

        [LoadSetting]
        [HttpPost, ActionName("Configure"), FormValueRequired("test-sms")]
        public async Task<IActionResult> TestSmsAsync(ConfigurationModel model, ClickatellSettings settings)
        {
            try
            {
                if (model.TestMessage.IsEmpty())
                {
                    model.TestSucceeded = false;
                    model.TestSmsResult = T("Plugins.Sms.Clickatell.EnterMessage");
                }
                else
                {
                    await ClickatellSmsSender.SendSmsAsync(settings, model.TestMessage);

                    model.TestSucceeded = true;
                    model.TestSmsResult = T("Plugins.Sms.Clickatell.TestSuccess");
                }
            }
            catch (Exception exception)
            {
                model.TestSucceeded = false;
                model.TestSmsResult = T("Plugins.Sms.Clickatell.TestFailed");
                model.TestSmsDetailResult = exception.Message;
            }

            return View("Configure", model);
        }
    }
}