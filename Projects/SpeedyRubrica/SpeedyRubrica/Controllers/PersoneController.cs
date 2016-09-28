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
    public class PersoneController : Controller
    {
        private RubricaDb db = new RubricaDb();

        // GET: Persone
        public ActionResult Index()
        {
            var persone = db.Persone.Include(p => p.Gruppo);
            return View(persone.ToList());
        }

        // GET: Persone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persone.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persone/Create
        public ActionResult Create()
        {
            ViewBag.Gruppo_Id = new SelectList(db.Gruppi, "Id", "Nome");
            return View();
        }

        // POST: Persone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cognome,Gruppo_Id")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persone.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gruppo_Id = new SelectList(db.Gruppi, "Id", "Nome", persona.Gruppo_Id);
            return View(persona);
        }

        // GET: Persone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persone.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gruppo_Id = new SelectList(db.Gruppi, "Id", "Nome", persona.Gruppo_Id);
            return View(persona);
        }

        // POST: Persone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cognome,Gruppo_Id")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gruppo_Id = new SelectList(db.Gruppi, "Id", "Nome", persona.Gruppo_Id);
            return View(persona);
        }

        // GET: Persone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persone.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persone.Find(id);
            db.Persone.Remove(persona);
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
