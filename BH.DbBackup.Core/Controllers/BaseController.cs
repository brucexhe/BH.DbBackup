using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BH.DbBackup.Core
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);
            if (context.HttpContext.Request.Path == "/DbBackup/login")
            {
                return;
            }
            if (context.HttpContext.Request.Path == "/DbBackup/GetResource")
            {
                return;
            }

            if (string.IsNullOrEmpty(context.HttpContext.Request.Cookies["token"]))
            {
                //context.HttpContext.Response.Redirect("login");
                //context.HttpContext.Response.StatusCode = 200;
            }
        }

    }
}
