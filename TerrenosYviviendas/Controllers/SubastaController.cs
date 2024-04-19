using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class SubastaController : Controller
    {
        // GET: Subasta
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Subasta.ToList());
            }
        }

        // GET: Subasta/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Subasta.Where(x => x.SubastaID == id).FirstOrDefault());
            }
        }

        // GET: Subasta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subasta/Create
        [HttpPost]
        public ActionResult Create(Subasta subasta)
        {
            try
            {
                // TODO: Add insert logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Subasta.Add(subasta);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subasta/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Subasta.Where(x => x.SubastaID == id).FirstOrDefault());

            }
        }

        // POST: Subasta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Subasta subasta)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(subasta).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subasta/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Subasta.Where(x => x.SubastaID == id).FirstOrDefault());
            }
        }

        // POST: Subasta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Subasta subasta = context.Subasta.Where(x => x.SubastaID == id).FirstOrDefault();
                    context.Subasta.Remove(subasta);
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
