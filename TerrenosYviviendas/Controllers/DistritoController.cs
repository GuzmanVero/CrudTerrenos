using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class DistritoController : Controller
    {
        // GET: Distrito
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Distrito.ToList());
            }
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Distrito.Where(x => x.DistritoID == id).FirstOrDefault());
            }
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distrito/Create
        [HttpPost]
        public ActionResult Create(Distrito distrito)
        {
            try
            {
                // TODO: Add insert logic here

                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Distrito.Add(distrito);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Distrito.Where(x => x.DistritoID == id).FirstOrDefault());

            }
        }

        // POST: Distrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Distrito distrito)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(distrito).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Distrito.Where(x => x.DistritoID == id).FirstOrDefault());
            }
        }

        // POST: Distrito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Distrito distrito = context.Distrito.Where(x => x.DistritoID == id).FirstOrDefault();
                    context.Distrito.Remove(distrito);
                    context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
