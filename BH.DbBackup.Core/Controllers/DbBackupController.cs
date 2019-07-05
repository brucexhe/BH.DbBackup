using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using System.IO;
using Ionic.Zip;

namespace BH.DbBackup.Core
{
    public class DbBackupController : BaseController
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

        public JsonResult GetDbTypeList()
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

        [HttpGet]
        public IActionResult GetConfig()
        {
            return Json(ConfigUtil.GetConfig());
        }

        [HttpPost]
        public IActionResult SaveConfig(IFormCollection form)
        {
            ConfigUtil.Write(FormUtil.ToModel<DbBackupConfig>(form));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Content(ResourceUtil.GetResource("static/login.html"), "text/html");
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult GetDbList()
        {
            return Json(DbFactory.GetDbInstance().GetDbList());
        }

        [HttpGet]
        public IActionResult GetBackupList(string db)
        {
            var config = ConfigUtil.GetConfig();
            var path = AppDomain.CurrentDomain.BaseDirectory + "\\DbBackup\\" + db;
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            var files = System.IO.Directory.GetFiles(path);
            List<BackupInfo> list = new List<BackupInfo>();
            foreach (var file in files)
            {
                var f = new FileInfo(file);
                var backupInfo = new BackupInfo()
                {
                    Name = f.Name,
                    Size = (Math.Floor(Convert.ToDecimal(f.Length) / 1024)) + "KB",
                    Time = f.CreationTime.ToString(),
                    Position = config.positiontype
                };
                list.Add(backupInfo);
            }
            return Json(list);
        }

        [HttpGet]
        public IActionResult BackupManually(string db)
        {
            var config = ConfigUtil.GetConfig();
            var path = AppDomain.CurrentDomain.BaseDirectory + "DbBackup\\" + db;
            //backup temp file

            //zip
            ZipUtil.Zip(path + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".sql");

            //remove temp file

            return Content("");
        }

        [HttpGet]
        public IActionResult Rollback(string db, string name)
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory + "DbBackup\\" + db + "\\" + name;

            //UnZip
            ZipUtil.UnZip(filename);

            //remove temp file

            return Content("");
        }
    }
}
