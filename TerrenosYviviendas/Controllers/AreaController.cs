using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Area.ToList());
            }
        }

        // GET: Area/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Area.Where(x => x.AreaID == id).FirstOrDefault());
            }
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(Area area)
        {
            try
            {
                // TODO: Add insert logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Area.Add(area);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Area.Where(x => x.AreaID == id).FirstOrDefault());

            }
        }

        // POST: Area/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Area area)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(area).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Area.Where(x => x.AreaID == id).FirstOrDefault());
            }
        }

        // POST: Area/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Area area = context.Area.Where(x => x.AreaID == id).FirstOrDefault();
                    context.Area.Remove(area);
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
