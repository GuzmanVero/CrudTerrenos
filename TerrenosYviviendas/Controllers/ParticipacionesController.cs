using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class ParticipacionesController : Controller
    {
        // GET: Participaciones
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Participaciones.ToList());
            }
        }

        // GET: Participaciones/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Participaciones.Where(x => x.ParticipaciónID == id).FirstOrDefault());
            }
        }

        // GET: Participaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participaciones/Create
        [HttpPost]
        public ActionResult Create(Participaciones participaciones)
        {
            try
            {
                // TODO: Add insert logic here

                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Participaciones.Add(participaciones);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Participaciones/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Participaciones.Where(x => x.ParticipaciónID == id).FirstOrDefault());

            }
        }

        // POST: Participaciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Participaciones participaciones)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(participaciones).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Participaciones/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Participaciones.Where(x => x.ParticipaciónID == id).FirstOrDefault());
            }
        }

        // POST: Participaciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Participaciones participaciones = context.Participaciones.Where(x => x.ParticipaciónID == id).FirstOrDefault();
                    context.Participaciones.Remove(participaciones);
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
