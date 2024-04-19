using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class TipoController : Controller
    {
        // GET: Tipo
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Tipo.ToList());
            }
        }

        // GET: Tipo/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Tipo.Where(x => x.TipoID == id).FirstOrDefault());
            };
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo/Create
        [HttpPost]
        public ActionResult Create(Tipo tipo)
        {
            try
            {
                // TODO: Add insert logic here

                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Tipo.Add(tipo);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tipo/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Tipo.Where(x => x.TipoID == id).FirstOrDefault());

            }
        }

        // POST: Tipo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tipo tipo)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(tipo).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tipo/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Tipo.Where(x => x.TipoID == id).FirstOrDefault());
            }
        }

        // POST: Tipo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Tipo tipo = context.Tipo.Where(x => x.TipoID == id).FirstOrDefault();
                    context.Tipo.Remove(tipo);
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
