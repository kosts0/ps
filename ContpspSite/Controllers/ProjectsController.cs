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
    public class ProjectsController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Projects

        public ActionResult Index()
        {

            return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            
            //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@id", id);
           // var track = db.Database.SqlQuery<Compositions>("GetTracks @id", param);
            return View(projects);
            

        }

        // GET: Projects/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ID_Musican = new SelectList(db.Musicians, "ID_Musician", "Famili");
            //ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name");
            ViewBag.Code_role = new SelectList(db.Roles, "Code_rol", "Name");
            return View();
        }

        // POST: Projects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,ID_Orojects")] Projects projects, [Bind(Include = "Data_including,Date_outsiding,ID_Musican,Code_role")] Sostav_of_project sostav_of_project)
        {
            
            if (ModelState.IsValid)
            {
                projects.ID_Project = Guid.NewGuid();
                db.Projects.Add(projects);
                //db.SaveChanges();
                sostav_of_project.ID_Project = projects.ID_Project;
                db.Sostav_of_project.Add(sostav_of_project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Musican = new SelectList(db.Musicians, "ID_Musician", "Famili", projects.Sostav_of_project.FirstOrDefault().ID_Musican);
            //ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", sostav_of_project.ID_Project);
            ViewBag.Code_role = new SelectList(db.Roles, "Code_rol", "Name", projects.Sostav_of_project.FirstOrDefault().Code_role);
   

            //db.Sostav_of_project.Add(this.ViewBag.I)
            return View(projects);
            //return View(projects);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: Projects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID_Project,Name")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Projects projects = db.Projects.Find(id);
            db.Projects.Remove(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
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
