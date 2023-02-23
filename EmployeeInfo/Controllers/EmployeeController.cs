using Azure.Core;
using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationContext context;
        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employee.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if(ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                City = model.City,
                State=model.State,
                Salary=model.Salary
                };
                context.Employee.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty field cannot be submit";
                return View(model);
            }
           
        }
        public IActionResult Delete(int id)
        {
            var emp = context.Employee.SingleOrDefault(e => e.Id == id);
            context.Employee.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Employee.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {

                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };
            context.Employee.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Edited!";
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var data = context.Employee.Where(x => x.Id == id).FirstOrDefault();

            return View(data);

        }

    }
}
