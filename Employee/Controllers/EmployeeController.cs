using Employee.Models;
using Employee.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private DatabaseContext _ctx;

        public EmployeeController(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
    
    public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult AddEmployee() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employees emp) 
        {

            if(!ModelState.IsValid) 
            {
                return View();
            }
            try
            {
                _ctx.Add(emp);
                _ctx.SaveChanges();
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("AddEmployee");
            }
            catch (Exception ex) 
            {
                TempData["msg"] = "Could not add" + ex;
                return View();
            }
        }
        public IActionResult DisplayEmployee()
        {
            var persons=_ctx.Employees.ToList();
            return View(persons);
        }
        public IActionResult EditEmployee(int Id)
        {
            var emp = _ctx.Employees.Find(Id);
            return View(emp);

        }
        [HttpPost]
        public IActionResult EditEmployee(Employees emp)
        { 
            if (!ModelState.IsValid) 
            {
                return View();
            }
            try
            {
                _ctx.Employees.Update(emp);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayEmployee");
            }
            catch (Exception ex) 
            {
                TempData["msg"] = "could not Update" + ex;
                return View();
            }
        }
        public IActionResult DeleteEmployee(int Id) 
        {
            try
            {
                var emp = _ctx.Employees.Find(Id);
                if (emp != null)
                {
                    _ctx.Employees.Remove(emp);
                    _ctx.SaveChanges();
                }
            }
            catch(Exception ex) 
            {
                
            }
            return RedirectToAction("DisplayEmployee");
            }
        }

       
    }

