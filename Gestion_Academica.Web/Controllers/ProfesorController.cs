using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Academica.Web.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly IProfesorRepository profesorRepository;
        public ProfesorController(IProfesorRepository profesorRepository) 
        {
            // Una prueba c QA
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
            var profesores = this.profesorRepository.ObtenerPorID(id);
            return View(profesores);
        }

        // GET: ProfesorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesor profesor)
        {
            try
            {
                this.profesorRepository.Agregar(profesor);
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
            var profesores = this.profesorRepository.ObtenerPorID(id);
            return View(profesores);
        }

        // POST: ProfesorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profesor profesor)
        {
            try
            {
                this.profesorRepository.Actualizar(profesor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
