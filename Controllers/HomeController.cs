using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fluent_validation.Models;

namespace fluent_validation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var alunos = new List<Aluno>();
            alunos.Add(new Aluno{
                Nome = "Ítalo Luz",
                Email = "italoluz@yahoo.com" ,
                DataNascimento = new System.DateTime(1998, 7, 8)
            });
            
            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create2()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Aluno model)
        {
            if(ModelState.IsValid)
            {
               return RedirectToAction("Index","Home");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
