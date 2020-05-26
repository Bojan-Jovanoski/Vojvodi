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
    public class VojvodasController : Controller
    {
        private IVojvodaRepository vojvodaRepository;

        public  VojvodasController()
        {
            this.vojvodaRepository = new VojvodaRepository(new WebAppContext());
        }

        public VojvodasController(IVojvodaRepository vojvodaRepository)
        {
            this.vojvodaRepository = vojvodaRepository;
        }

        // GET: Vojvodas
        public ActionResult Index()
        {
            var vojvodas = vojvodaRepository.GetVojvodas();
            return View(vojvodas);
        }

        // GET: Vojvodas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vojvoda vojvoda = vojvodaRepository.GetVojvodaByID(id);
            if (vojvoda == null)
            {
                return HttpNotFound();
            }
            return View(vojvoda);
        }

        // GET: Vojvodas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vojvodas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VojvodaID,Name,DateOfBirth")] Vojvoda vojvoda)
        {
            if (ModelState.IsValid)
            {
               vojvodaRepository.InsertVojvoda(vojvoda);
               vojvodaRepository.Save();
                return RedirectToAction("Index");
            }

            return View(vojvoda);
        }

        // GET: Vojvodas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vojvoda vojvoda = vojvodaRepository.GetVojvodaByID(id);
            if (vojvoda == null)
            {
                return HttpNotFound();
            }
            return View(vojvoda);
        }

        // POST: Vojvodas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VojvodaID,Name,DateOfBirth")] Vojvoda vojvoda)
        {
            if (ModelState.IsValid)
            {
                vojvodaRepository.UpdateVojvoda(vojvoda);
                vojvodaRepository.Save();
                return RedirectToAction("Index");
            }
            return View(vojvoda);
        }

        // GET: Vojvodas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vojvoda vojvoda = vojvodaRepository.GetVojvodaByID(id);
            if (vojvoda == null)
            {
                return HttpNotFound();
            }
            return View(vojvoda);
        }

        // POST: Vojvodas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vojvoda vojvoda = vojvodaRepository.GetVojvodaByID(id);
            vojvodaRepository.DeleteVojvoda(id);
            vojvodaRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vojvodaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
