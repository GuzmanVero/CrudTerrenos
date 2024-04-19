using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class PropietarioController : Controller
    {
        // GET: Propietario
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Propietario.ToList());
            }
        }

        // GET: Propietario/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Propietario.Where(x => x.PropietarioID == id).FirstOrDefault());
            }
        }

        // GET: Propietario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        [HttpPost]
        public ActionResult Create(Propietario propietario)
        {
            try
            {
                // TODO: Add insert logic here

                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Propietario.Add(propietario);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietario/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Propietario.Where(x => x.PropietarioID == id).FirstOrDefault());

            }
        }

        // POST: Propietario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Propietario propietario)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(propietario).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietario/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Propietario.Where(x => x.PropietarioID == id).FirstOrDefault());
            }
        }

        // POST: Propietario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Propietario propietario = context.Propietario.Where(x => x.PropietarioID== id).FirstOrDefault();
                    context.Propietario.Remove(propietario);
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
