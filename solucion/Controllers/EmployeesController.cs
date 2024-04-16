using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Data;

namespace solucion.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly RegistroContext _context;

        public EmployeesController(RegistroContext context)
        {
            _context = context;
        }
    }
}