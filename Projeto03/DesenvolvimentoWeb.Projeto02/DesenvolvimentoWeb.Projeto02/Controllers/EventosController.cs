using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class EventosController : Controller
    {
        private EventosDaoImpl EventosDao { get; set; }

        //EventosContext é passado por injeção de dependencia
        public EventosController(EventosContext context)
        {
            this.EventosDao = new EventosDaoImpl(context);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //Inclusão do evento
        [HttpGet]
        [Authorize(Roles ="ADMIN")]
        public IActionResult IncluirEvento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncluirEvento(Evento evento, IFormFile foto)
        {
            if(foto != null)
            {
                evento.Foto = foto.ToByteArray();
                evento.MimeType = foto.ContentType;
            }
            EventosDao.ProcessarBD(evento, TipoOperacaoBD.Added);
            return RedirectToAction("ListarEventos");
        }

        //Buscando a imagem
        public FileResult BuscarFoto(int id)
        {
            var evento = EventosDao.BuscarPorId(id);
            return File(evento.Foto, evento.MimeType);
        }

        //Listando os eventos
        public IActionResult ListarEventos()
        {
            var lista = EventosDao.Listar();
            return View(lista);
        }

        //Alterando o evento
        [HttpGet]
        public IActionResult AlterarEvento(int id)
        {
            return ExecutarEvento(id, "AlterarEvento");
        }

        [HttpPost]
        public IActionResult AlterarEvento(Evento evento, IFormFile foto)
        {
            if (foto != null)
            {
                evento.Foto = foto.ToByteArray();
                evento.MimeType = foto.ContentType;
            }
            EventosDao.ProcessarBD(evento, TipoOperacaoBD.Modified);
            return RedirectToAction("ListarEventos");
        }

        //exibindo os detalhes
        public IActionResult VerDetalhes(int id)
        {
            return ExecutarEvento(id, "VerDetalhes");
        }

        //removendo um evento
        [HttpGet]
        public IActionResult RemoverEvento(int id)
        {
            return ExecutarEvento(id, "RemoverEvento");
        }

        //action HTTPGet Comum
        private IActionResult ExecutarEvento(int id, string viewName)
        {
            var evento = EventosDao.BuscarPorId(id);

            if (evento == null)
            {
                ViewData["MensagemErro"] = "Nenhum evento encontrado";
                return View("_Erro");
            }
            return View(viewName, evento);
        }

        [HttpPost]
        public IActionResult RemoverEvento(Evento evento)
        {
            EventosDao.ProcessarBD(evento, TipoOperacaoBD.Deleted);
            return RedirectToAction("ListarEventos");
        }
    }
}