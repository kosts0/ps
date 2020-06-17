using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoSite.Controllers
{
    public class Create_projectController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();
        // GET: Create_project
        public ActionResult Create_project()
        {
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create_project(Models.Create_project model)
        {
            if (ModelState.IsValid)
            {
                Projects project = new Projects();
            }
        }*/
    }
}