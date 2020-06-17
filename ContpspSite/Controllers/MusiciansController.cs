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
    public class MusiciansController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Musicians
        public ActionResult Index()
        {
            return View(db.Musicians.ToList());
        }

        // GET: Musicians/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicians musicians = db.Musicians.Find(id);
            if (musicians == null)
            {
                return HttpNotFound();
            }
            return View(musicians);
        }

        // GET: Musicians/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musicians/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID_Musician,Famili,Name,Father,Information")] Musicians musicians)
        {
            if (ModelState.IsValid)
            {
                musicians.ID_Musician = Guid.NewGuid();
                db.Musicians.Add(musicians);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicians);
        }

        // GET: Musicians/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicians musicians = db.Musicians.Find(id);
            if (musicians == null)
            {
                return HttpNotFound();
            }
            return View(musicians);
        }

        // POST: Musicians/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID_Musician,Famili,Name,Father,Information")] Musicians musicians)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicians).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicians);
        }

        // GET: Musicians/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musicians musicians = db.Musicians.Find(id);
            if (musicians == null)
            {
                return HttpNotFound();
            }
            return View(musicians);
        }

        // POST: Musicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Musicians musicians = db.Musicians.Find(id);
            db.Musicians.Remove(musicians);
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
