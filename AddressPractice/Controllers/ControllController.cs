using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AddressPractice.Models;

namespace AddressPractice.Controllers
{
    public class ControllController : Controller
    {
        private EfPracticeEntities db = new EfPracticeEntities();

        // GET: Controll
        public ActionResult Index()
        {
            return View(db.ADDRESS_MASTER.ToList());
        }

        // GET: Controll/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADDRESS_MASTER aDDRESS_MASTER = db.ADDRESS_MASTER.Find(id);
            if (aDDRESS_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(aDDRESS_MASTER);
        }

        // GET: Controll/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Controll/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,furigana,gender,bloodType,birthDay,homePhone,cellPhone,mailAddress,postalCode,homeAddress,homeFurigana")] ADDRESS_MASTER aDDRESS_MASTER)
        {
            if (ModelState.IsValid)
            {
                db.ADDRESS_MASTER.Add(aDDRESS_MASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDDRESS_MASTER);
        }

        // GET: Controll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADDRESS_MASTER aDDRESS_MASTER = db.ADDRESS_MASTER.Find(id);
            if (aDDRESS_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(aDDRESS_MASTER);
        }

        // POST: Controll/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,furigana,gender,bloodType,birthDay,homePhone,cellPhone,mailAddress,postalCode,homeAddress,homeFurigana")] ADDRESS_MASTER aDDRESS_MASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDDRESS_MASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDDRESS_MASTER);
        }

        // GET: Controll/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADDRESS_MASTER aDDRESS_MASTER = db.ADDRESS_MASTER.Find(id);
            if (aDDRESS_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(aDDRESS_MASTER);
        }

        // POST: Controll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADDRESS_MASTER aDDRESS_MASTER = db.ADDRESS_MASTER.Find(id);
            db.ADDRESS_MASTER.Remove(aDDRESS_MASTER);
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
