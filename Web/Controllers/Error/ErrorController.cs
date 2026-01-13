using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult General()
        {
            Response.StatusCode = 500;
            return View();
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        public ActionResult AccessDenied()
        {
            Response.StatusCode = 403;
            return View();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}