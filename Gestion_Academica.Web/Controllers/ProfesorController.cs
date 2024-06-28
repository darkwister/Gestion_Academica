﻿using Gestion_Academica.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Academica.Web.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly IProfesorRepository profesorRepository;
        public ProfesorController(IProfesorRepository profesorRepository) 
        {
            this.profesorRepository = profesorRepository;
        }
        // GET: ProfesorController
        public ActionResult Index()
        {
            var profesores = this.profesorRepository.TraerTodos();
            return View(profesores);
        }

        // GET: ProfesorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfesorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfesorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfesorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfesorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfesorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
