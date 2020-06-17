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
    public class AlbomsController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Alboms
        public ActionResult Index()
        {
            return View(db.Albom.ToList());
        }

        // GET: Alboms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albom albom = db.Albom.Find(id);
            if (albom == null)
            {
                return HttpNotFound();
            }
            //IEnumerable<Compositions_in_album> sostav = db.Compositions_in_album.Where(p => p.ID_Albom == id);
            return View(albom);
        }

        // GET: Alboms/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alboms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID_Alboma,Name,Information")] Albom albom)
        {
            if (ModelState.IsValid)
            {
                albom.ID_Alboma = Guid.NewGuid();
                db.Albom.Add(albom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albom);
        }

        // GET: Alboms/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albom albom = db.Albom.Find(id);
            if (albom == null)
            {
                return HttpNotFound();
            }
            return View(albom);
        }

        // POST: Alboms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID_Alboma,Name,Information")] Albom albom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albom);
        }

        // GET: Alboms/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albom albom = db.Albom.Find(id);
            if (albom == null)
            {
                return HttpNotFound();
            }
            return View(albom);
        }

        // POST: Alboms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Albom albom = db.Albom.Find(id);
            db.Albom.Remove(albom);
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
