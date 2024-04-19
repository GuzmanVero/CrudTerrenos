using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class TerrenoController : Controller
    {
        // GET: Terreno
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Terreno.ToList());
            }
        }

        // GET: Terreno/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Terreno.Where(x => x.TerrenoID== id).FirstOrDefault());
            }
        }

        // GET: Terreno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terreno/Create
        [HttpPost]
        public ActionResult Create(Terreno terreno)
        {
            try
            {
                // TODO: Add insert logic here

                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Terreno.Add(terreno);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Terreno/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Terreno.Where(x => x.TerrenoID == id).FirstOrDefault());

            }
        }

        // POST: Terreno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Terreno terreno)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(terreno).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Terreno/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Terreno.Where(x => x.TerrenoID == id).FirstOrDefault());
            }
        }

        // POST: Terreno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Terreno terreno = context.Terreno.Where(x => x.TerrenoID == id).FirstOrDefault();
                    context.Terreno.Remove(terreno);
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
