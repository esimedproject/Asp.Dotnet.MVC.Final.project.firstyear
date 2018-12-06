using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Esimed.Projet.Service;

namespace WebApplication.Esimed.Projet.Controllers
{
    public class TableExigencesController : Controller
    {
        private EntitiesFrameworkDatabase db = new EntitiesFrameworkDatabase();

        // GET: TableExigences
        public ActionResult Index()
        {
            return View(db.TableExigence.ToList());
        }
        
        // GET: TableExigences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableExigences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExigenceId,ExigenceCommentaire,ExigenceFonctionnel,ExigenceFonctionTache")] TableExigence tableExigence)
        {
            if (ModelState.IsValid)
            {
                db.TableExigence.Add(tableExigence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableExigence);
        }

        // GET: TableExigences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableExigence tableExigence = db.TableExigence.Find(id);
            if (tableExigence == null)
            {
                return HttpNotFound();
            }
            return View(tableExigence);
        }

        // POST: TableExigences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExigenceId,ExigenceCommentaire,ExigenceFonctionnel,ExigenceFonctionTache")] TableExigence tableExigence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableExigence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableExigence);
        }

        // GET: TableExigences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableExigence tableExigence = db.TableExigence.Find(id);
            if (tableExigence == null)
            {
                return HttpNotFound();
            }
            return View(tableExigence);
        }

        // POST: TableExigences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableExigence tableExigence = db.TableExigence.Find(id);
            db.TableExigence.Remove(tableExigence);
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

        public ActionResult open(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tableExigences = db.TableExigence.Include(t => t.TableTache);
            return RedirectToAction("Index", "TableExigences", new { id = id });
        }
    }
}
