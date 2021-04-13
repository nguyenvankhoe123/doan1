using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Commons;

namespace WebOnline.Areas.Administrator.Controllers
{
    public class BaseController : Controller
    {
        // GET: Administrator/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string returnUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
            if (GlobalVar.IdUserLogin < 0)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
                filterContext.Result = new RedirectResult("/login?returnUrl=" + returnUrl);
            }
            else
            {
                bool flag = FunctionUtils.CheckRole(GlobalVar.Permission, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                if (flag)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    filterContext.Result = new RedirectResult("/bad-request");
                }
            }
        }

    }
}