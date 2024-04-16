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
    }
}