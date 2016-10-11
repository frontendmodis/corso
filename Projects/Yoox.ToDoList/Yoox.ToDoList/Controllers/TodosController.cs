using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yoox.ToDoList.Models;

namespace Yoox.ToDoList.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Todos
        public ActionResult Index()
        {
            var utenteId = User.Identity.GetUserId();
            var todos = db.Todos.Where(t => t.UtenteId == utenteId);
            return View(todos.ToList());
        }

        // GET: Todos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }

            var utenteId = User.Identity.GetUserId();

            if(todo.UtenteId != utenteId)
            {
                return HttpNotFound();
            }

            return View(todo);
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            var model = new Todo();
            model.UtenteId = User.Identity.GetUserId();
            return View(model);
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                todo.UtenteId = User.Identity.GetUserId();
                db.Todos.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }

            var utenteId = User.Identity.GetUserId();

            if (todo.UtenteId != utenteId)
            {
                return HttpNotFound();
            }

            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                if(todo.UtenteId != User.Identity.GetUserId())
                {
                    return HttpNotFound();
                }

                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }

            var utenteId = User.Identity.GetUserId();

            if (todo.UtenteId != utenteId)
            {
                return HttpNotFound();
            }

            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todos.Find(id);

            if (todo.UtenteId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }

            db.Todos.Remove(todo);
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
