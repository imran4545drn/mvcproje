using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcprojesi.Models.Entity;

namespace mvcprojesi.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities3 db = new MvcDbStokEntities3();

        public ActionResult Index()
        {
            var degerler = db.Kategoriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(Kategoriler p1)
        {
            db.Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kategorigetir(int? id)
        {
            var ktgr = db.Kategoriler.Find(id);
            return View("Kategorigetir", ktgr);
        }
        public ActionResult Guncelle(Kategoriler p1)
        {
            var ktg = db.Kategoriler.Find(p1.Kategoriid);
            ktg.Kategoriad = p1.Kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
