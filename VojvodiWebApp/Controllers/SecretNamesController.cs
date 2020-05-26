using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Repos;

namespace VojvodiWebApp.Controllers
{
    public class SecretNamesController : Controller
    {
        private UoFVojvodaSname unitOfWork = new UoFVojvodaSname();

        // GET: SecretNames
        public ActionResult Index()
        {
            var secretNames = unitOfWork.SnameRepo.Get(includeProperties: "Vojvoda");
            return View(secretNames.ToList());
        }

        // GET: SecretNames/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecretName secretName = unitOfWork.SnameRepo.GetByID(id);
            if (secretName == null)
            {
                return HttpNotFound();
            }
            return View(secretName);
        }

        // GET: SecretNames/Create
        public ActionResult Create()
        {
            var VojvodaQuery = unitOfWork.VojvodaRepo.Get(
            orderBy: q => q.OrderBy(d => d.VojvodaID));
            ViewBag.SnameID = new SelectList(VojvodaQuery, "VojvodaID", "Name");
            return View();
        }

        

        // POST: SecretNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SnameID,Sname")] SecretName secretName)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SnameRepo.Insert(secretName);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.SnameID = new SelectList(db.Vojvodas, "VojvodaID", "Name", secretName.SnameID);
            return View(secretName);
        }

        // GET: SecretNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecretName secretName = unitOfWork.SnameRepo.GetByID(id);
            if (secretName == null)
            {
                return HttpNotFound();
            }
           // ViewBag.SnameID = new SelectList(db.Vojvodas, "VojvodaID", "Name", secretName.SnameID);
            return View(secretName);
        }

        // POST: SecretNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SnameID,Sname")] SecretName secretName)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SnameRepo.Update(secretName);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
           // ViewBag.SnameID = new SelectList(db.Vojvodas, "VojvodaID", "Name", secretName.SnameID);
            return View(secretName);
        }

        // GET: SecretNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecretName secretName = unitOfWork.SnameRepo.GetByID(id);
            if (secretName == null)
            {
                return HttpNotFound();
            }
            return View(secretName);
        }

        // POST: SecretNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecretName secretName = unitOfWork.SnameRepo.GetByID(id);
            unitOfWork.SnameRepo.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
