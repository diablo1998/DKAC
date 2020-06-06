using DKAC.Common;
using DKAC.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DKAC.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext fillterContext)
        {
            var em = (Employee)Session[CommonConstants.EMPLOYEE_SESSION];
            var user = (User)Session[CommonConstants.USER_SESSION];
            if (user == null && em == null)
            {
                fillterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            base.OnActionExecuting(fillterContext);
        }
    }
}