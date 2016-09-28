using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaNostraRubrica.DAL;

namespace SpeedyRubrica.Controllers
{
    //[Authorize]
    public class GruppiController : Controller
    {
        private RubricaDb db = new RubricaDb();

        // GET: Gruppi
        //[Authorize(Roles = "Amministratore, SuperUser", Users ="Gabriele, Valerio")]
        //[AllowAnonymous]
        //[HandleError(ExceptionType = typeof(UnauthorizedAccessException), View = "Error" )]
        public ActionResult Index()
        {
            var elenco = db.Gruppi.ToList();

            //throw new UnauthorizedAccessException("Non puoi passare!");

            return View(elenco);
        }

        // GET: Gruppi/Details/5
        //[OutputCache()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gruppo gruppo = db.Gruppi.Find(id);
            if (gruppo == null)
            {
                return HttpNotFound();
            }
            return View(gruppo);
        }

        // GET: Gruppi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gruppi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gruppo gruppo)
        {
            if (ModelState.IsValid)
            {
                db.Gruppi.Add(gruppo);
                db.SaveChanges();
                //var elenco = db.Gruppi.ToList();
                //return View("Index", elenco);
                TempData["Messaggio"] = "Creato gruppo " + gruppo.Id;
                return RedirectToAction("Index");
            }

            return View(gruppo);
        }

        // GET: Gruppi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gruppo gruppo = db.Gruppi.Find(id);
            if (gruppo == null)
            {
                return HttpNotFound();
            }
            return View(gruppo);
        }

        // POST: Gruppi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gruppo gruppo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gruppo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gruppo);
        }

        // GET: Gruppi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gruppo gruppo = db.Gruppi.Find(id);
            if (gruppo == null)
            {
                return HttpNotFound();
            }
            return View(gruppo);
        }

        // POST: Gruppi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gruppo gruppo = db.Gruppi.Find(id);
            db.Gruppi.Remove(gruppo);
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
