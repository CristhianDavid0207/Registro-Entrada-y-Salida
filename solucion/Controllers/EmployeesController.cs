using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace solucion.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly RegistroContext _context;

        public EmployeesController(RegistroContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.Nombre = HttpContext.Session.GetString("Email");
            if(ViewBag.Nombre != null){
                return View(_context.Controls.ToList());

            }else{
                return RedirectToAction("Index", "Home");
            }
            
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Index", "Home");
        }





    }
}