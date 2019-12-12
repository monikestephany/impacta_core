using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class ParticipantesController : Controller
    {
        private EventosDaoImpl EventosDao { get; set; }
        private ParticipantesDaoImpl ParticipantesDao { get; set; }

        public ParticipantesController(EventosContext context)
        {
            this.EventosDao = new EventosDaoImpl(context);
            this.ParticipantesDao = new ParticipantesDaoImpl(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IncluirParticipante()
        {
            ViewBag.ListaDeEventos = new
                SelectList(EventosDao.Listar(), "Id", "Descricao");

            return View();
        }

        [HttpPost]
        public IActionResult IncluirParticipante(Participante participante)
        {
            if(participante.IdEvento == 0)
            {
                ModelState.AddModelError("IdEvento", "Nenhum evento selecionado ");
            }

            if (!participante.Cpf.ValidarCPF())
            {
                ModelState.AddModelError("Cpf", "Cpf inválido");
            }

            if (!ModelState.IsValid)
            {
                return IncluirParticipante();
            }
            ParticipantesDao.ProcessarBD(participante, TipoOperacaoBD.Added);
            return RedirectToAction("Index");
        }

        public IActionResult ListarParticipantesAjax(int idEvento)
        {
            ViewBag.ListaDeEventos = new
                SelectList(EventosDao.Listar(), "Id", "Descricao");
            
            if(idEvento == 0)
            {
                return View();
            }
            else
            {
                var lista = ParticipantesDao.ListarPorEvento(idEvento);
                return PartialView("_ListarParticipantes", lista);
            }

        }
    }
}