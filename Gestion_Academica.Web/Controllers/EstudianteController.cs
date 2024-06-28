using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Academica.Web.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IAEstudianteRepository estudianteRepository;

        // GET: EstudianteController

        public EstudianteController(IAEstudianteRepository estudianteRepository) 
        {
            this.estudianteRepository = estudianteRepository;
        }

        public ActionResult Index()
        {
            var estudiantes= this.estudianteRepository.TraerTodos();
            return View(estudiantes);
        }

        // GET: EstudianteController/Details/5
        public ActionResult Details(int id)
        {
            var estudiantes = this.estudianteRepository.ObtenerporId(id);
            return View(estudiantes);
        }

        // GET: EstudianteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiantes estudiantes)
        {
            try
            {
                this.estudianteRepository.Agregar(estudiantes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudianteController/Edit/5
        public ActionResult Edit(int id)
        {
            var estudiantes = this.estudianteRepository.ObtenerporId(id);
            return View(estudiantes);
        }

        // POST: EstudianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estudiantes estudiantes)
        {
            try
            {
                this.estudianteRepository.Actualizar(estudiantes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
