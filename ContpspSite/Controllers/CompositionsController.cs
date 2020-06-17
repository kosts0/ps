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
    public class CompositionsController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Compositions

        public ActionResult Index()
        {

            var compositions = db.Compositions.Include(c => c.Compositions2);
          
            return View(compositions.ToList());
        }

        // GET: Compositions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositions compositions = db.Compositions.Find(id);
            if (compositions == null)
            {
                return HttpNotFound();
            }
            return View(compositions);
        }

        // GET: Compositions/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Original = new SelectList(db.Compositions, "ID_Composotion", "Name");
            return View();
        }

        // POST: Compositions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID_Composotion,Name,Realise_Date,Original")] Compositions compositions)
        {
            if (ModelState.IsValid)
            {
                compositions.ID_Composotion = Guid.NewGuid();
                db.Compositions.Add(compositions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Original = new SelectList(db.Compositions, "ID_Composotion", "Name", compositions.Original);
            return View(compositions);
        }

        // GET: Compositions/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositions compositions = db.Compositions.Find(id);
            if (compositions == null)
            {
                return HttpNotFound();
            }
            ViewBag.Original = new SelectList(db.Compositions, "ID_Composotion", "Name", compositions.Original);
            return View(compositions);
        }

        // POST: Compositions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID_Composotion,Name,Realise_Date,Original")] Compositions compositions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compositions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Original = new SelectList(db.Compositions, "ID_Composotion", "Name", compositions.Original);
            return View(compositions);
        }

        // GET: Compositions/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositions compositions = db.Compositions.Find(id);
            if (compositions == null)
            {
                return HttpNotFound();
            }
            return View(compositions);
        }

        // POST: Compositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Compositions compositions = db.Compositions.Find(id);
            db.Compositions.Remove(compositions);
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
