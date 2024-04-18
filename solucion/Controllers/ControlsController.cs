using Microsoft.AspNetCore.Mvc;
using solucion.Data;

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

        public IActionResult Incom(int id)
        {
            var user = _context.Controls.FirstOrDefault(r => r.EmployeesId == id);
            return Json(user);
        }
        }
}