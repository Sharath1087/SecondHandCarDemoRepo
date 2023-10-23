using Microsoft.AspNetCore.Mvc;
using SecondHandCarDemoRepo.Data;
using SecondHandCarDemoRepo.Models;

namespace SecondHandCarDemoRepo.Controllers
{
    public class CarsController : Controller
    {
        private readonly IRepository<Car> _repo;

        public CarsController(IRepository<Car> repo)
        {
            _repo = repo;
        }
        
        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var cars = await _repo.GetAllAsync();
            return View(cars);
        }

        // GET: Cars/Deatils/5
        public async Task<IActionResult> Details(int id)
        {
            var car = await _repo.GetByIdAsync(id);
            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if(ModelState.IsValid)
            {
                await _repo.AddAsync(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if(product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if (id != car.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                await _repo.UpdateAsync(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
