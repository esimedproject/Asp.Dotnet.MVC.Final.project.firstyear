using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Esimed.Projet.Service;
using WebApplication.Esimed.Projet.Controllers; 


namespace WebApplication.Esimed.Projet.Controllers
{
    public class TableProjetsController : Controller
    {
        private EntitiesFrameworkDatabase db = new EntitiesFrameworkDatabase();

        // GET: TableProjets
        public ActionResult Index()
        {
            var tableProjet = db.TableProjet.Include(t => t.TableJalon).Include(t => t.TableTrigramme);
            return View(tableProjet.ToList());
        }

        // GET: TableProjets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableProjet tableProjet = db.TableProjet.Find(id);
            if (tableProjet == null)
            {
                return HttpNotFound();
            }
            return View(tableProjet);
        }

        // GET: TableProjets/Create
        public ActionResult Create()
        {
            ViewBag.ProjetJalon = new SelectList(db.TableJalon, "JalonId", "JalonNom");
            ViewBag.ProjetTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom");
            return View();
        }

        // POST: TableProjets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjetId,ProjetAvancement,ProjetTrigramme,ProjetJalon,ProjetNom")] TableProjet tableProjet)
        {
            if (ModelState.IsValid)
            {
                db.TableProjet.Add(tableProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjetJalon = new SelectList(db.TableJalon, "JalonId", "JalonNom");
            ViewBag.ProjetTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableProjet.ProjetTrigramme);
            return View(tableProjet);
        }

        // GET: TableProjets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableProjet tableProjet = db.TableProjet.Find(id);
            if (tableProjet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjetJalon = new SelectList(db.TableJalon, "JalonId", "JalonNom");
            ViewBag.ProjetTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableProjet.ProjetTrigramme);
            return View(tableProjet);
        }

        // POST: TableProjets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjetId,ProjetAvancement,ProjetTrigramme,ProjetJalon,ProjetNom")] TableProjet tableProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjetJalon = new SelectList(db.TableJalon, "JalonId", "JalonNom");
            ViewBag.ProjetTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableProjet.ProjetTrigramme);
            return View(tableProjet);
        }

        // GET: TableProjets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableProjet tableProjet = db.TableProjet.Find(id);
            if (tableProjet == null)
            {
                return HttpNotFound();
            }
            return View(tableProjet);
        }

        // POST: TableProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableProjet tableProjet = db.TableProjet.Find(id);
            db.TableProjet.Remove(tableProjet);
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

        public ActionResult Select(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tableJalon = db.TableJalon.Include(t => t.TableTache);
            return RedirectToAction("Index", "TableJalons", new { id = id});            
        }

        public ActionResult CreateUser()
        {
            ViewBag.ProjetJalon = new SelectList(db.TableJalon, "JalonId", "JalonNom");
            ViewBag.ProjetTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "ProjetId,ProjetAvancement,ProjetTrigramme,ProjetJalon,ProjetNom")] TableTrigramme tableTrigramme)
        {
            if (ModelState.IsValid)
            {
                db.TableTrigramme.Add(tableTrigramme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjetJalon = new SelectList(db.TableJalon, "JalonId", "JalonNom");
            ViewBag.ProjetTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom");
            return View(tableTrigramme);
        }
    }
}
