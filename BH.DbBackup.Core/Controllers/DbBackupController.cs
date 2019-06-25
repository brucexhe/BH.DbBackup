using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace BH.DbBackup.Core
{
    public class DbBackupController : Controller
    {

        public IActionResult Index()
        {

            return Content(ResourceUtil.GetResource("static/index.html"), "text/html");
            //return View();// Content("db backup index");
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
    }
}
