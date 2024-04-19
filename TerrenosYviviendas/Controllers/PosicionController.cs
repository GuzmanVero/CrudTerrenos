using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class PosicionController : Controller
    {
        // GET: Posicion
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Posicion.ToList());
            }
        }

        // GET: Posicion/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Posicion.Where(x => x.PosicionID == id).FirstOrDefault());
            }
        }

        // GET: Posicion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posicion/Create
        [HttpPost]
        public ActionResult Create(Posicion posicion)
        {
            try
            {
                // TODO: Add insert logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Posicion.Add(posicion);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posicion/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Posicion.Where(x => x.PosicionID == id).FirstOrDefault());

            }
        }

        // POST: Posicion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Posicion posicion)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(posicion).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posicion/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Posicion.Where(x => x.PosicionID == id).FirstOrDefault());
            }
        }

        // POST: Posicion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Posicion posicion = context.Posicion.Where(x => x.PosicionID == id).FirstOrDefault();
                    context.Posicion.Remove(posicion);
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
