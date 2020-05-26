using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Models;
using Models.Repos.UnitofWorks;

namespace VojvodiWebApp.Controllers
{
    public class VojvodaBitkasController : Controller
    {
        private UoFVojvodaBitka unitOfWork = new UoFVojvodaBitka();



        // GET: VojvodaBitkas
        public ActionResult Index()
        {
            var vojvodaBitkas = unitOfWork.VojvodaBitkasRepo.Get(includeProperties: "Vojvoda,Bitka");
            return View(vojvodaBitkas.ToList());
        }

        // GET: VojvodaBitkas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VojvodaBitkas vojvodaBitkas = unitOfWork.VojvodaBitkasRepo.GetByID(id);
            if (vojvodaBitkas == null)
            {
                return HttpNotFound();
            }
            return View(vojvodaBitkas);
        }

        // GET: VojvodaBitkas/Create
        public ActionResult Create()
        {
            var VojvodaQuery = unitOfWork.VojvodaRepo.Get(
            orderBy: q => q.OrderBy(d => d.VojvodaID));

            var BitkaQuery = unitOfWork.BitkaRepo.Get(
            orderBy: q => q.OrderBy(d => d.BitkaId));

            ViewBag.BitkaID = new SelectList(BitkaQuery, "BitkaId", "Lokacija");
            ViewBag.VojvodaID = new SelectList(VojvodaQuery, "VojvodaID", "Name");
            return View();
        }

        // POST: VojvodaBitkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VojvodaID,BitkaID")] VojvodaBitkas vojvodaBitkas)
        {
            var VojvodaQuery = unitOfWork.VojvodaRepo.Get(
            orderBy: q => q.OrderBy(d => d.VojvodaID));

            var BitkaQuery = unitOfWork.BitkaRepo.Get(
            orderBy: q => q.OrderBy(d => d.BitkaId));

            if (ModelState.IsValid)
            {
                unitOfWork.VojvodaBitkasRepo.Insert(vojvodaBitkas);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BitkaID = new SelectList(BitkaQuery, "BitkaId", "Lokacija", vojvodaBitkas.BitkaID);
            ViewBag.VojvodaID = new SelectList(VojvodaQuery, "VojvodaID", "Name", vojvodaBitkas.VojvodaID);
            return View(vojvodaBitkas);
        }

        // GET: VojvodaBitkas/Edit/5
        public ActionResult Edit(int id)
        {
            var VojvodaQuery = unitOfWork.VojvodaRepo.Get(
            orderBy: q => q.OrderBy(d => d.VojvodaID));

            var BitkaQuery = unitOfWork.BitkaRepo.Get(
            orderBy: q => q.OrderBy(d => d.BitkaId));

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VojvodaBitkas vojvodaBitkas = unitOfWork.VojvodaBitkasRepo.GetByID(id);
            if (vojvodaBitkas == null)
            {
                return HttpNotFound();
            }
            ViewBag.BitkaID = new SelectList(BitkaQuery, "BitkaId", "Lokacija", vojvodaBitkas.BitkaID);
            ViewBag.VojvodaID = new SelectList(VojvodaQuery, "VojvodaID", "Name", vojvodaBitkas.VojvodaID);
            return View(vojvodaBitkas);
        }

        // POST: VojvodaBitkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VojvodaID,BitkaID")] VojvodaBitkas vojvodaBitkas)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.VojvodaBitkasRepo.Update(vojvodaBitkas);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(vojvodaBitkas);
        }

        // GET: VojvodaBitkas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VojvodaBitkas vojvodaBitkas = unitOfWork.VojvodaBitkasRepo.GetByID(id);
            if (vojvodaBitkas == null)
            {
                return HttpNotFound();
            }
            return View(vojvodaBitkas);
        }

        // POST: VojvodaBitkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VojvodaBitkas vojvodaBitkas = unitOfWork.VojvodaBitkasRepo.GetByID(id);
            unitOfWork.VojvodaBitkasRepo.Delete(vojvodaBitkas);
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
