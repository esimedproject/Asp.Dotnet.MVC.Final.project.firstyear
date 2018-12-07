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
        private EntitiesFrameworkData db = new EntitiesFrameworkData();

        // GET: TableExigences
        public ActionResult IndexAll()
        {
            return View(db.TableExigence.ToList());
        }

        public ActionResult Index(int id)
        {
            var tableExigence = db.TableExigence.Include(t => t.TableProjet).Include(t => t.TableTache);
            var maliste = tableExigence.Where(t => t.IdProjet == id).ToList();
            ViewBag.idprojet = id;
            return View(maliste);
        }
        // GET: TableExigences/Create
        public ActionResult Create(int idprojet)
        {
            ViewBag.IdProjet = new SelectList(db.TableExigence,"ExigenceCommentaire", "ExigenceFonctionnel", "ExigenceFonctionTache");
            ViewBag.IdProjet = idprojet;
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
                return RedirectToAction("Index", new { id = tableExigence.IdProjet});
            }
            ViewBag.IdProjet = new SelectList(db.TableExigence, "ExigenceCommentaire", "ExigenceFonctionnel", "ExigenceFonctionTache");
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
