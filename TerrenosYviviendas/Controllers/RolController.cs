using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Rol.ToList());
            }
        }

        // GET: Rol/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Rol.Where(x => x.RolID == id).FirstOrDefault());
            }
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            try
            {
                // TODO: Add insert logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Rol.Add(rol);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Rol.Where(x => x.RolID == id).FirstOrDefault());

            }
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rol rol)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Rol.Where(x => x.RolID == id).FirstOrDefault());
            }
        }

        // POST: Rol/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Rol rol = context.Rol.Where(x => x.RolID== id).FirstOrDefault();
                    context.Rol.Remove(rol);
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
