using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Extensions;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class EventosController : Controller
    {
        public readonly EventosContext context;

        public EventosController(EventosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult IncluirEventos()
        {
            string email = "monikestephany@gmail.com".ValidarEmail();

            return View();
        }
        [HttpPost]
        public IActionResult IncluirEventos(Evento evento,IFormFile foto)
        {
            if (foto != null)
            {
                evento.Foto = foto.ToByteArray();
                evento.MimeType = foto.ContentType;
            }
            context.Add<Evento>(evento);
            context.SaveChanges();

            return RedirectToAction("ListarEventos");
        }
        public FileResult BuscarFoto(int id)
        {
            var evento = context.Eventos.FirstOrDefault(p => p.Id == id);
            if (evento == null)
                return File("~/images/noimage.gif", "image/gif");
            return File(evento.Foto, evento.MimeType);
        }
        public IActionResult ListarEventos()
        {
            var lista = context.Eventos.ToList();
        
            return View(lista);
        }
        [HttpGet]
        public IActionResult AlterarEvento(int id)
        {
            if (id < 1)
            {
                ViewData["MensagemErro"] = "Nenhum evento encontrado";
                return View("_Erro");
            }
            var evento = context.Eventos.FirstOrDefault(p => p.Id == id);
            
            return View( evento);
        }
        [HttpPost]
        public IActionResult AlterarEvento(Evento evento,IFormFile foto)
        {
         
            if (foto != null)
            {
                evento.Foto = foto.ToByteArray();
                evento.MimeType = foto.ContentType;
            }
            context.Eventos.Update(evento);
            context.SaveChanges();

            return RedirectToAction("ListarEventos","Eventos");
        }
        [HttpGet]
        public IActionResult RemoverEvento(int id)
        {
            var evento = context.Eventos.FirstOrDefault(p => p.Id == id);

            return View(evento);
        }
        [HttpPost]
        public IActionResult RemoverEvento(Evento evento, IFormFile foto)
        {
            context.Eventos.Remove(evento);
            context.SaveChanges();

            return RedirectToAction("ListarEventos", "Eventos");
        }
        [HttpGet]
        public IActionResult DetalhesEvento(int id)
        {
            var evento = context.Eventos.FirstOrDefault(p => p.Id == id);

            return View(evento);
        }
    }
}