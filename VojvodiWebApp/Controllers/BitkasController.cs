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
using Models.Repos.BitkaRepo;

namespace VojvodiWebApp.Controllers
{
    public class BitkasController : Controller
    {
        private IBitkaRepository bitkaRepository;

        public BitkasController()
        {
            this.bitkaRepository = new BitkaRepository(new WebAppContext());
        }

        public BitkasController(IBitkaRepository vojvodaRepository)
        {
            this.bitkaRepository = vojvodaRepository;
        }

        // GET: Bitkas
        public ActionResult Index()
        {
            var bitki = bitkaRepository.GetBitkas();
            return View(bitki);
        }

        // GET: Bitkas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitka bitka = bitkaRepository.GetBitkasByID(id);
            if (bitka == null)
            {
                return HttpNotFound();
            }
            return View(bitka);
        }

        // GET: Bitkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BitkaId,Lokacija,Datum")] Bitka bitka)
        {
            if (ModelState.IsValid)
            {
                bitkaRepository.InsertBitkas(bitka);
                bitkaRepository.Save();
                return RedirectToAction("Index");
            }

            return View(bitka);
        }

        // GET: Bitkas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitka bitka = bitkaRepository.GetBitkasByID(id);
            if (bitka == null)
            {
                return HttpNotFound();
            }
            return View(bitka);
        }

        // POST: Bitkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BitkaId,Lokacija,Datum")] Bitka bitka)
        {
            if (ModelState.IsValid)
            {
                bitkaRepository.UpdateBitkas(bitka);
                bitkaRepository.Save();
                return RedirectToAction("Index");
            }
            return View(bitka);
        }

        // GET: Bitkas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitka bitka = bitkaRepository.GetBitkasByID(id);
            if (bitka == null)
            {
                return HttpNotFound();
            }
            return View(bitka);
        }

        // POST: Bitkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bitka bitka = bitkaRepository.GetBitkasByID(id);
            bitkaRepository.DeleteBitkas(id);
            bitkaRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bitkaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
