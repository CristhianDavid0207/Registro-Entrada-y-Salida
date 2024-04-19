using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solucion.Data;
using solucion.Models;

namespace solucion.Controllers
{
    public class ControlsController : Controller
    {
        private readonly RegistroContext _context;

        public ControlsController(RegistroContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Income()
        {
            var id = HttpContext.Session.GetInt32("Id");
            return Json(id);
            var lista = new Control(){
                Income = DateTime.Now,
                EmployeesId = id
            };
           _context.Controls.Add(lista);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index", "Employees");            
        }
    }
}