using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Dados;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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
        [HttpGet]
        public IActionResult EfetuarPagamento(int id ,int idEvento)
        {
            var participante = ParticipantesDao.BuscarPorId(id);
            var evento = EventosDao.BuscarPorId(idEvento);

            PagamentoEvento pagamento = new PagamentoEvento {
                Cpf = participante.Cpf,
                IdEvento = idEvento,
                Valor = evento.Preco,
                Status = 1,
                NumeroCartao = "11111111"
            };
            return View(pagamento);
        }
        [HttpPost]
        public async Task<IActionResult> EfetuarPagamento(PagamentoEvento pagamento)
        {
            //a ser implementado
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49728/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(pagamento);

                HttpContent content = new StringContent(json,
                Encoding.Unicode, "application/json");
                var response = await client.PostAsync("api/Pagamentos/IncluirPagamento",content);
                if (response.IsSuccessStatusCode)
                {                    
                    return RedirectToAction("ListarParticipantes");
                }
                else
                {
                    string msg = response.StatusCode + " - " +
                    response.ReasonPhrase;
                  
                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = ex.Message;
                return View("_Erro");
            }
        }

    }
}