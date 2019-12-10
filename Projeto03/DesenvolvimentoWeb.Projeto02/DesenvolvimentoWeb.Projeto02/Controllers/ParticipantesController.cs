using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Extensions;
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
            ViewBag.ListarEventos = new SelectList(EventosDao.Listar(), "Id", "Descricao");

            return View();
        }
        [HttpPost]
        public IActionResult IncluirParticipante(Participante participante)
        {
            if (participante.IdEvento == 0)
            {
                ModelState.AddModelError("IdEvento", "É necessario selecionar um evento!");
                return IncluirParticipante();
            }
            else if (!ModelState.IsValid)
            {
                return IncluirParticipante();
            }
            else if (!participante.Cpf.ValidarCPF())
            {
                ModelState.AddModelError("Cpf", "Cpf Inválido");
                return IncluirParticipante();
            }
            else
            {
                ParticipantesDao.ProcessarBD(participante, TipoOperacaoBD.Added);

                return RedirectToAction("Index");
            }
        }
    }
}