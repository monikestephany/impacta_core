using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult IncluirEventos()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IncluirEventos(Evento evento,IFormFile foto)
        {
            
            return View();
        }
    }
}