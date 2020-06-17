using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoSite.Models;

namespace ContosoSite.Controllers
{
    public class Sostav_of_projectController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Sostav_of_project
        [Authorize]
        public ActionResult Index()
        {
            var sostav_of_project = db.Sostav_of_project.Include(s => s.Musicians).Include(s => s.Projects).Include(s => s.Roles);
            return View(sostav_of_project.ToList());
        }

        // GET: Sostav_of_project/Details/5
        public ActionResult Details(Guid id, Guid id2, int? code)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sostav_of_project = db.Sostav_of_project.Find(id,id2,code);
            
            if (sostav_of_project == null)
            {
                return HttpNotFound();
            }
            return View(sostav_of_project);
        }

        // GET: Sostav_of_project/Create
        public ActionResult Create(Guid id)
        {
            //ViewBag.ID_Musican = new SelectList(db.Musicians, "ID_Musician", "Famili");
            //ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name");
            IEnumerable<SelectListItem> selectList =
                from c in db.Musicians
                select new SelectListItem
                {

                    Text = c.Name + " " + c.Famili,
                    Value = c.ID_Musician.ToString()
                };
            ViewData["id"] = id;
            //ViewDa.ID_Project = id;
            ViewBag.ID_Musican = selectList;
            ViewData["Name"] = db.Projects.Find(id).Name;
            ViewBag.Code_role = new SelectList(db.Roles, "Code_rol", "Name");

            return View();
        }

        // POST: Sostav_of_project/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Data_including,Date_outsiding,ID_Musican,ID_Project,Code_role")] Sostav_of_project sostav_of_project,Guid id)
        {

            sostav_of_project.ID_Project = id;
            if (ModelState.IsValid)
            {
                //sostav_of_project.ID_Musican = Guid.NewGuid();

                db.Sostav_of_project.Add(sostav_of_project);
                db.SaveChanges();
                return RedirectToAction("Edit/"+id,"Projects");
            }
            IEnumerable<SelectListItem> selectList =
                from c in db.Musicians
                select new SelectListItem
                {
                    
                    Text = c.Name,
                    Value = c.ID_Musician.ToString()
                };
            //ViewBag.ID_Musican = new SelectList(db.Musicians, "ID_Musician", "Name,Family", sostav_of_project.ID_Musican);
            ViewBag.ID_Musican = selectList;
            //SelectList musics = new SelectList(db.Musicians, "Name", "Family");
            //ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", sostav_of_project.ID_Project);
            ViewBag.Code_role = new SelectList(db.Roles, "Code_rol", "Name", sostav_of_project.Code_role);
            return View(sostav_of_project);
        }

        // GET: Sostav_of_project/Edit/5
        public ActionResult Edit(Guid id, Guid id2, int code)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sostav_of_project sostav_of_project = db.Sostav_of_project.Find(id,id2,code);
            if (sostav_of_project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Musican = new SelectList(db.Musicians, "ID_Musician", "Famili", sostav_of_project.ID_Musican);
            ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", sostav_of_project.ID_Project);
            ViewBag.Code_role = new SelectList(db.Roles, "Code_rol", "Name", sostav_of_project.Code_role);
            return View(sostav_of_project);
        }

        // POST: Sostav_of_project/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Data_including,Date_outsiding,ID_Musican,ID_Project,Code_role")] Sostav_of_project sostav_of_project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sostav_of_project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Musican = new SelectList(db.Musicians, "ID_Musician", "Famili", sostav_of_project.ID_Musican);
            ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", sostav_of_project.ID_Project);
            ViewBag.Code_role = new SelectList(db.Roles, "Code_rol", "Name", sostav_of_project.Code_role);
            return View(sostav_of_project);
        }

        // GET: Sostav_of_project/Delete/5
        public ActionResult Delete(Guid id, Guid id2, int code)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sostav_of_project sostav_of_project = db.Sostav_of_project.Find(id, id2, code);
            if (sostav_of_project == null)
            {
                return HttpNotFound();
            }
            return View(sostav_of_project);
        }

        // POST: Sostav_of_project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id, Guid id2, int code)
        {
            Sostav_of_project sostav_of_project = db.Sostav_of_project.Find(id,id2,code);
            db.Sostav_of_project.Remove(sostav_of_project);
            db.SaveChanges();
            return RedirectToAction("Edit/" + id2, "Projects");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
