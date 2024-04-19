using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Carro.ToList());
            }
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Carro.Where(x => x.CarroID == id).FirstOrDefault());
            }
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        [HttpPost]
        public ActionResult Create(Carro carro)
        {
            try
            {
                // TODO: Add insert logic here

                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Carro.Add(carro);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Carro.Where(x => x.CarroID == id).FirstOrDefault());

            }
        }

        // POST: Carro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Carro carro)
        {
            try
            {
                // TODO: Add update logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    context.Entry(carro).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            using (CostaDelSol context = new CostaDelSol())
            {
                return View(context.Carro.Where(x => x.CarroID == id).FirstOrDefault());
            }
        }

        // POST: Carro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CostaDelSol context = new CostaDelSol())
                {
                    Carro carro = context.Carro.Where(x => x.CarroID == id).FirstOrDefault();
                    context.Carro.Remove(carro);
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
