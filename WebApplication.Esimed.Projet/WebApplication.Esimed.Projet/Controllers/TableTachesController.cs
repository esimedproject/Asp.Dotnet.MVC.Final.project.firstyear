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
    public class TableTachesController : Controller
    {
        private EntitiesFrameworkDatabase db = new EntitiesFrameworkDatabase();

        // GET: TableTaches
        public ActionResult IndexAll()
        {
            var tableTache = db.TableTache;
            return View(tableTache.ToList());
        }

        public ActionResult Index(int id)
        {
            var tableTaches = db.TableTache.Include(t => t.TableJalon).Include(t => t.TableExigence);
            var maliste = tableTaches.Where(t => t.IdJalon == id).ToList();
            ViewBag.idtaches = id;
            return View(maliste);
        }
       
        // GET: TableTaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTache tableTache = db.TableTache.Find(id);
            if (tableTache == null)
            {
                return HttpNotFound();
            }
            return View(tableTache);
        }              

        // GET: TableTaches/Create
        public ActionResult Create(int idtaches)
        {
            ViewBag.IdJalon = new SelectList(db.TableTache, "TacheId", "TacheNom");
            ViewBag.TacheTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom");
            ViewBag.IdJalon = idtaches;
            return View();
        }

        // POST: TableTaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TableTache tableTache)
        {
            if (ModelState.IsValid)
            {
                db.TableTache.Add(tableTache);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = tableTache.IdJalon });
            }
            ViewBag.IdJalon = new SelectList(db.TableTache, "TacheId", "TacheNom", tableTache.IdJalon);
            ViewBag.TacheTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableTache.TacheTrigramme);
            return View(tableTache);
        }

        // GET: TableTaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTache tableTache = db.TableTache.Find(id);
            if (tableTache == null)
            {
                return HttpNotFound();
            }
            ViewBag.TacheTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableTache.TacheTrigramme);
            return View(tableTache);
        }

        // POST: TableTaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TacheId,TacheNom,TacheTrigramme,TacheFinReel,TacheDebutReel,TacheNbDeJours,TacheExigence")] TableTache tableTache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableTache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TacheTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableTache.TacheTrigramme);
            return View(tableTache);
        }
     
        // GET: TableTaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableTache tableTache = db.TableTache.Find(id);
            if (tableTache == null)
            {
                return HttpNotFound();
            }
            return View(tableTache);
        }

        // POST: TableTaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableTache tableTache = db.TableTache.Find(id);
            db.TableTache.Remove(tableTache);
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
