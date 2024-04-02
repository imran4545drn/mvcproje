using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcprojesi.Models.Entity;

namespace mvcprojesi.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities3 db = new MvcDbStokEntities3();
        public ActionResult Index()
        {
            var degerler = db.Musteriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Musteriler p1)
        {
            db.Musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.Musteriler.Find(id);
            db.Musteriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Musterigetir(int? id)
        {
            var mus = db.Musteriler.Find(id);
            return View("Musterigetir", mus);
        }
        public ActionResult Guncelle(Musteriler p1)
        {
            var ktg = db.Musteriler.Find(p1.Musteriid);
            ktg.Musteriad = p1.Musteriad;
            ktg.Musteriadsoyad = p1.Musteriadsoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}