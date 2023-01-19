using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class UtentiController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Utentis
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utenti u)
        {
           var utente = db.Utenti
                            .Where(ut => ut.Username.Equals(u.Username) && ut.Password_.Equals(u.Password_));
            try
            {
            if(utente != null)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ViewBag.Errore = "Username o Password errati";
            }

            }
            catch
            {

            }
            return View();
        }

        // GET: Utentis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // GET: Utentis/Create
        public ActionResult Create()
        {
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "User_Admin");
            return View();
        }

        // POST: Utentis/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUtente,Indirizzo,Nome,Cognome,Username,Password_,IdRuolo")] Utenti utenti)
        {
            try
            {
                if (utenti.Ruoli == null)
                {
                    utenti.IdRuolo = 1;
                    if (ModelState.IsValid)
                        {
               
                            db.Utenti.Add(utenti);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                         }
                }
            }
            catch
            {

            }
            finally
            {

            }

            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "User_Admin", utenti.IdRuolo);
            return View(utenti);
        }

        // GET: Utentis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "User_Admin", utenti.IdRuolo);
            return View(utenti);
        }

        // POST: Utentis/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUtente,Indirizzo,Nome,Cognome,Username,Password_,IdRuolo")] Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "User_Admin", utenti.IdRuolo);
            return View(utenti);
        }

        // GET: Utentis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // POST: Utentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utenti utenti = db.Utenti.Find(id);
            db.Utenti.Remove(utenti);
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
