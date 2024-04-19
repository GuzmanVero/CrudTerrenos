using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Terrenos2.Permisos
{
    public class ValidarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {

                filterContext.Result = new RedirectResult("~/UsuarioLogin/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}