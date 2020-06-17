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
    public class Soctav_of_compositionsController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Soctav_of_compositions
        public ActionResult Index()
        {
            var soctav_of_compositions = db.Soctav_of_compositions.Include(s => s.Compositions).Include(s => s.Projects);
            return View(soctav_of_compositions.ToList());
        }

        // GET: Soctav_of_compositions/Details/5
        public ActionResult Details(Guid idc,Guid idp)
        {
            if (idc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soctav_of_compositions soctav_of_compositions = db.Soctav_of_compositions.Find(idc,idp);
            if (soctav_of_compositions == null)
            {
                return HttpNotFound();
            }
            return View(soctav_of_compositions);
        }

        // GET: Soctav_of_compositions/Create
        public ActionResult Create()
        {
            ViewBag.ID_composition = new SelectList(db.Compositions, "ID_Composotion", "Name");
            ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name");
            return View();
        }

        // POST: Soctav_of_compositions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Guest,ID_composition,ID_Project")] Soctav_of_compositions soctav_of_compositions)
        {
            if (ModelState.IsValid)
            {
               
                db.Soctav_of_compositions.Add(soctav_of_compositions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_composition = new SelectList(db.Compositions, "ID_Composotion", "Name", soctav_of_compositions.ID_composition);
            ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", soctav_of_compositions.ID_Project);
            return View(soctav_of_compositions);
        }

        // GET: Soctav_of_compositions/Edit/5
        public ActionResult Edit(Guid idc, Guid idp)
        {
            if (idc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soctav_of_compositions soctav_of_compositions = db.Soctav_of_compositions.Find(idc,idp);
            if (soctav_of_compositions == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_composition = new SelectList(db.Compositions, "ID_Composotion", "Name", soctav_of_compositions.ID_composition);
            ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", soctav_of_compositions.ID_Project);
            return View(soctav_of_compositions);
        }

        // POST: Soctav_of_compositions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Guest,ID_composition,ID_Project")] Soctav_of_compositions soctav_of_compositions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soctav_of_compositions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_composition = new SelectList(db.Compositions, "ID_Composotion", "Name", soctav_of_compositions.ID_composition);
            ViewBag.ID_Project = new SelectList(db.Projects, "ID_Project", "Name", soctav_of_compositions.ID_Project);
            return View(soctav_of_compositions);
        }

        // GET: Soctav_of_compositions/Delete/5
        public ActionResult Delete(Guid idc, Guid idp)
        {
            if (idc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soctav_of_compositions soctav_of_compositions = db.Soctav_of_compositions.Find(idc,idp);
            if (soctav_of_compositions == null)
            {
                return HttpNotFound();
            }
            return View(soctav_of_compositions);
        }

        // POST: Soctav_of_compositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid idc, Guid idp)
        {
            Soctav_of_compositions soctav_of_compositions = db.Soctav_of_compositions.Find(idc,idp);
            db.Soctav_of_compositions.Remove(soctav_of_compositions);
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
