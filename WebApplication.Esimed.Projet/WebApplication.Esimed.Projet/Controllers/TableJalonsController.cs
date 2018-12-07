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
    public class TableJalonsController : Controller
    {
        private EntitiesFrameworkData db = new EntitiesFrameworkData();

        // GET: TableJalons
        public ActionResult IndexAll()
        {
            var tableJalon = db.TableJalon.Include(t => t.TableProjet).Include(t => t.TableTrigramme);
            return View(tableJalon.ToList());
        }
        
        public ActionResult Index(int id)
        {
            var tableJalon = db.TableJalon.Include(t => t.TableTache).Include(t => t.TableTrigramme); 
            var maliste = tableJalon.Where(t => t.IdProjet == id).ToList();
            ViewBag.idprojet = id;     
            return View(maliste); 
        }

        // GET: TableJalons/Create
        public ActionResult Create(int id)
        {
            ViewBag.IdProjet = new SelectList(db.TableProjet, "ProjetId", "ProjetNom");
            ViewBag.JalonTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom");
            ViewBag.IdProjet = id;
            return View();
        }

        // POST: TableJalons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TableJalon tableJalon)
        {
            if (ModelState.IsValid)
            {
                db.TableJalon.Add(tableJalon);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = tableJalon.IdProjet });
            }
            ViewBag.IdProjet = new SelectList(db.TableProjet, "ProjetId", "ProjetNom", tableJalon.IdProjet);
           // ViewBag.IdJalon = new SelectList(db.TableTache, "TacheId", "TacheNom", tableJalon.Id);
            ViewBag.JalonTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableJalon.JalonTrigramme);
            return View(tableJalon);
        }

        // GET: TableJalons/Edit/5
        public ActionResult Edit(int? id, int? idpage)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableJalon tableJalon = db.TableJalon.Find(id);
            ViewBag.IdProjet = id;
            if (tableJalon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProjet = new SelectList(db.TableProjet, "ProjetId", "ProjetNom", tableJalon.IdProjet);
            ViewBag.JalonTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableJalon.JalonTrigramme);
            return View(tableJalon);
        }

        // POST: TableJalons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TableJalon tableJalon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableJalon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { id = tableJalon.IdProjet });
            }
            ViewBag.IdProjet = new SelectList(db.TableProjet, "ProjetId", "ProjetNom", tableJalon.IdProjet);
            ViewBag.JalonTrigramme = new SelectList(db.TableTrigramme, "TrigrammeId", "TrigrammeNom", tableJalon.JalonTrigramme);
            return View(tableJalon);
        }

        // GET: TableJalons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableJalon tableJalon = db.TableJalon.Find(id);
            
            if (tableJalon == null)
            {
                return HttpNotFound();
            }
            return View(tableJalon);
        }

        // POST: TableJalons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableJalon tableJalon = db.TableJalon.Find(id);
            db.TableJalon.Remove(tableJalon);
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
            var tableTache = db.TableTache;
            return RedirectToAction("Index", "TableTaches", new {id = id});
        }
        
        public ActionResult Redirect(int? idprojet)
        {
            ViewBag.IdProjet = idprojet;
            if (idprojet == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tableTache = db.TableTache;
            return RedirectToAction("Index", "TableJalons", new { id = idprojet });
        }
    }
}
