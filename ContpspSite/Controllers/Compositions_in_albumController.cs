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
    public class Compositions_in_albumController : Controller
    {
        private IDZnewEntities1 db = new IDZnewEntities1();

        // GET: Compositions_in_album
        public ActionResult Index()
        {
            var compositions_in_album = db.Compositions_in_album.Include(c => c.Albom).Include(c => c.Compositions);
            return View(compositions_in_album.ToList());
        }

        // GET: Compositions_in_album/Details/5
        public ActionResult Details(Guid idk, Guid ida)
        {
            if (ida == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositions_in_album compositions_in_album = db.Compositions_in_album.Find(idk,ida);
            if (compositions_in_album == null)
            {
                return HttpNotFound();
            }
            return View(compositions_in_album);
        }

        // GET: Compositions_in_album/Create
        public ActionResult Create()
        {
            ViewBag.ID_Albom = new SelectList(db.Albom, "ID_Alboma", "Name");
            ViewBag.ID_Composition = new SelectList(db.Compositions, "ID_Composotion", "Name");
            return View();
        }

        // POST: Compositions_in_album/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Number,ID_Composition,ID_Albom")] Compositions_in_album compositions_in_album)
        {
            if (ModelState.IsValid)
            {
                //compositions_in_album.ID_Composition = Guid.NewGuid();
                db.Compositions_in_album.Add(compositions_in_album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Albom = new SelectList(db.Albom, "ID_Alboma", "Name", compositions_in_album.ID_Albom);
            ViewBag.ID_Composition = new SelectList(db.Compositions, "ID_Composotion", "Name", compositions_in_album.ID_Composition);
            return View(compositions_in_album);
        }

        // GET: Compositions_in_album/Edit/5
        public ActionResult Edit(Guid idk, Guid ida)
        {
            if (ida == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositions_in_album compositions_in_album = db.Compositions_in_album.Find(idk,ida);
            if (compositions_in_album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Albom = new SelectList(db.Albom, "ID_Alboma", "Name", compositions_in_album.ID_Albom);
            ViewBag.ID_Composition = new SelectList(db.Compositions, "ID_Composotion", "Name", compositions_in_album.ID_Composition);
            return View(compositions_in_album);
        }

        // POST: Compositions_in_album/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Number,ID_Composition,ID_Albom")] Compositions_in_album compositions_in_album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compositions_in_album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Albom = new SelectList(db.Albom, "ID_Alboma", "Name", compositions_in_album.ID_Albom);
            ViewBag.ID_Composition = new SelectList(db.Compositions, "ID_Composotion", "Name", compositions_in_album.ID_Composition);
            return View(compositions_in_album);
        }

        // GET: Compositions_in_album/Delete/5
        public ActionResult Delete(Guid idk, Guid ida)
        {
            if (ida == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositions_in_album compositions_in_album = db.Compositions_in_album.Find(idk, ida);
            if (compositions_in_album == null)
            {
                return HttpNotFound();
            }
            return View(compositions_in_album);
        }

        // POST: Compositions_in_album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid idk, Guid ida)
        {
            Compositions_in_album compositions_in_album = db.Compositions_in_album.Find(idk,ida);
            db.Compositions_in_album.Remove(compositions_in_album);
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
