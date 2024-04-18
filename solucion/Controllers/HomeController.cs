using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Storage;
using solucion.Data;
using solucion.Models;
using Microsoft.EntityFrameworkCore;

namespace solucion.Controllers;

public class HomeController : Controller
{
    private readonly RegistroContext _context;

    public HomeController(RegistroContext context)
    {
        _context = context;
    }

    public IActionResult Index(string message = "")
    {
        ViewBag.Message = message;
  
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if(!string.IsNullOrEmpty(email))
        {
            //Hacemos uso de la base de datos
            var user = await _context.Employees.FirstOrDefaultAsync(r => r.Email == email);

            if(user != null && user.Password == password ) //Si el usuario es diferente de null
            {
                HttpContext.Session.SetString("Names", user.Names);
                HttpContext.Session.SetString("LastNames", user.LastNames);
                //Encontramos un usuario con los datos
                return RedirectToAction("Index", "Employees");
            }
            else if(user != null && user.Password != password ) 
            {
                return RedirectToAction("Index", new {message = "Incorrect user or password"});  
            }
            else
            {
                return RedirectToAction("Index" , new {message = "User not registered"} ) ;                
            }

        }
        else
        {
            return RedirectToAction("Index", new {message = "Fill in the fields to be able to login"});
        }
    }
    

}

