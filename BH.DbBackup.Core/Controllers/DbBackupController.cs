using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace BH.DbBackup.Core
{
    public class DbBackupController : Controller
    {

        public IActionResult Index()
        {
            //read config
            if (!ConfigUtil.hasInitial())
            {
                return RedirectToAction("Config");
            }

            return Content(ResourceUtil.GetResource("static/index.html"), "text/html");
            //return View();// Content("db backup index");
        }

        public IActionResult Config()
        {
            return Content(ResourceUtil.GetResource("static/config.html"), "text/html");
        }

        public IActionResult GetResource(string fileName)
        {
            return Content(ResourceUtil.GetResource(fileName));
        }

        public JsonResult GetDbList()
        {
            List<String> dbList = new List<string>();
            dbList.Add("mysql");
            return Json(dbList);
        }

        [HttpPost]
        public IActionResult ConnectTest(DbBackupConfig config)
        {
            ConfigUtil.Write(config);

            bool result = DbFactory.GetDbInstance().ConnectTest();

            return Content(result.ToString());
        }

        [HttpPost]
        public IActionResult SaveConfig(IFormCollection form)
        {
            ConfigUtil.Write(FormUtil.ToModel<DbBackupConfig>(form));

            return RedirectToAction("Index");
        }
    }
}
