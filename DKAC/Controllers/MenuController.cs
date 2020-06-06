using DKAC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKAC.Controllers
{
    public class MenuController : Controller
    {
        MenuRepository _menuRepo = new MenuRepository();

        // GET: Menu
        public ActionResult Index(string KeySearch, int page = 1, int pageSize = 10)
        {
            var model = _menuRepo.GetAllMenu(KeySearch, page, pageSize);
            return View(model);
        }
    }
}