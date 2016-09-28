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
    public class RecapitiController : Controller
    {
        private RubricaDb db = new RubricaDb();

        // GET: Recapiti
        public ActionResult Index()
        {
            var recapiti = db.Recapiti.Include(r => r.Persona);
            return View(recapiti.ToList());
        }

        // GET: Recapiti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recapito recapito = db.Recapiti.Find(id);
            if (recapito == null)
            {
                return HttpNotFound();
            }
            return View(recapito);
        }

        // GET: Recapiti/Create
        public ActionResult Create()
        {
            ViewBag.Persona_Id = new SelectList(db.Persone, "Id", "Nome");
            return View();
        }

        // POST: Recapiti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Valore,Persona_Id")] Recapito recapito)
        {
            if (ModelState.IsValid)
            {
                db.Recapiti.Add(recapito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Persona_Id = new SelectList(db.Persone, "Id", "Nome", recapito.Persona_Id);
            return View(recapito);
        }

        // GET: Recapiti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recapito recapito = db.Recapiti.Find(id);
            if (recapito == null)
            {
                return HttpNotFound();
            }
            ViewBag.Persona_Id = new SelectList(db.Persone, "Id", "Nome", recapito.Persona_Id);
            return View(recapito);
        }

        // POST: Recapiti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Valore,Persona_Id")] Recapito recapito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recapito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Persona_Id = new SelectList(db.Persone, "Id", "Nome", recapito.Persona_Id);
            return View(recapito);
        }

        // GET: Recapiti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recapito recapito = db.Recapiti.Find(id);
            if (recapito == null)
            {
                return HttpNotFound();
            }
            return View(recapito);
        }

        // POST: Recapiti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recapito recapito = db.Recapiti.Find(id);
            db.Recapiti.Remove(recapito);
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
