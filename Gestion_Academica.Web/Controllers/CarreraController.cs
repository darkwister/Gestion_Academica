using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Academica.Web.Controllers
{
    public class CarreraController : Controller
    {
        private readonly ICarrerasRepository carrerasRepository;

        public CarreraController(ICarrerasRepository carrerasRepository) 
        {
            this.carrerasRepository = carrerasRepository;
        }
         
        // GET: CarreraController1
        public ActionResult Index()
        {

            var carreras = this.carrerasRepository.TraerTodos();

            return View(carreras);
        }

        // GET: CarreraController1/Details/5
        public ActionResult Details(int id)
        {
            var carrera = this.carrerasRepository.ObtenerPorId(id);

            return View(carrera);
        }

        // GET: CarreraController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarreraController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carrera carrera)
        {
            try
            {
                this.carrerasRepository.Agregar(carrera);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarreraController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarreraController1/Edit/5
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

        // GET: CarreraController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarreraController1/Delete/5
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
