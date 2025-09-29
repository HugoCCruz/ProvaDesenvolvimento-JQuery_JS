using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaDesenvolvimento.Models;

namespace ProvaDesenvolvimento
{
    public class UserViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserViewModels
        public ActionResult Index()
        {
            return View(db.UserViewModels.ToList());
        }

        // GET: UserViewModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = db.UserViewModels.Find(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // GET: UserViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return Json(new { usuarios = db.UserViewModels.ToList() }, JsonRequestBehavior.AllowGet);
        }

        // POST: UserViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,BirthDate,Password,ConfirmPassword")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                db.UserViewModels.Add(userViewModel);
                db.SaveChanges();
                if (!Request.IsAjaxRequest())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Json(new { status = "ok", usuario = userViewModel });
                }
            }
            var errors = ModelState.Where(y => y.Value.Errors.Count > 0).ToDictionary(m => m.Key, m => m.Value.Errors);// Select(x => x.Value.Errors).Where(y => y.Count > 0).ToDictionary();


            if (!Request.IsAjaxRequest())
            {
                return View(userViewModel);
            }
            else
            {
                return Json(new { status = "error", errors = errors });
            }
        }

        // GET: UserViewModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = db.UserViewModels.Find(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: UserViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,BirthDate,Password,ConfirmPassword")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: UserViewModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = db.UserViewModels.Find(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: UserViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserViewModel userViewModel = db.UserViewModels.Find(id);
            db.UserViewModels.Remove(userViewModel);
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
