using Microsoft.AspNetCore.Mvc;
using SeriesListWeb.Data;
using SeriesListWeb.Models;

namespace SeriesListWeb.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SeriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Series> objSeriesList = _db.Serie;
            return View(objSeriesList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Series obj)
        {
            if(obj.Name == obj.Genre)
            {
                ModelState.AddModelError("name", "The Genre cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Serie.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Serie created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var serieFromDb = _db.Serie.Find(id);
            if(serieFromDb == null)
            {
                return NotFound();
            }
            return View(serieFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Series obj)
        {
            if (obj.Name == obj.Genre)
            {
                ModelState.AddModelError("name", "The Genre cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Serie.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Serie updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var serieFromDb = _db.Serie.Find(id);
            if (serieFromDb == null)
            {
                return NotFound();
            }
            return View(serieFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Serie.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Serie.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Serie deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
