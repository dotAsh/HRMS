using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
                _db = db;
        }
        public IActionResult Index(string search)
        {
            //List<Category> objCategoryList = _db.Categories.ToList();
            //return View(objCategoryList);
            var query = _db.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            List<Employee> objCategoryList = query.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if ( obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order can not be same");

            }
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Record created successfully!";
                return RedirectToAction("index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employeeFromDb = _db.Employees.Find(id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {

            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Record updated successfully!";
                return RedirectToAction("index");
            }

            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? categoryFromDb = _db.Employees.Find(id);
  
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Employee? obj = _db.Employees.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Record deleted successfully!";
            return RedirectToAction("index");
        }
    }
}
