using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using MvcStok.Controllers;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index(int sayfa=1)
        {
            //----1
            //var degerler = db.TBLMUSTERILER.ToList();
            //-------2
            var degerler = db.TBLMUSTERILER.ToList().ToPagedList(sayfa, 4);//indexin içi(int sayfa=1)
            return View(degerler);
            //----3
            //var degerler = from d in db.TBLMUSTERILER select d; //tbl Musterilerden cekip d (d yi tek tek sec) üzerinden degerlere attık
            //if (!string.IsNullOrEmpty(p))
            //{
            //    degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));

            //}
            //return View(degerler.ToList());

        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}