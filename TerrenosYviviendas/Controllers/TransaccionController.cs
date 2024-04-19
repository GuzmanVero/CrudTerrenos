using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class TransaccionController : Controller
    {
        // GET: Transaccion
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Transaccion.ToList());
            }
        }

        // GET: Transaccion/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Transaccion.Where(x => x.TransaccionID == id).FirstOrDefault());
            }
        }

        // GET: Transaccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaccion/Create
        [HttpPost]
        public ActionResult Create(Transaccion transaccion)
        {
            try
            {
                // TODO: Add insert logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Transaccion.Add(transaccion);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaccion/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Transaccion.Where(x => x.TransaccionID == id).FirstOrDefault());

            }
        }

        // POST: Transaccion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Transaccion transaccion)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(transaccion).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaccion/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Transaccion.Where(x => x.TransaccionID == id).FirstOrDefault());
            }
        }

        // POST: Transaccion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Transaccion transaccion = context.Transaccion.Where(x => x.TransaccionID == id).FirstOrDefault();
                    context.Transaccion.Remove(transaccion);
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
