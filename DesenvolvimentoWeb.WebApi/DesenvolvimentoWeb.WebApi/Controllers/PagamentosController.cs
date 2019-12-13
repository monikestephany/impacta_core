using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.WebApi.Data;
using DesenvolvimentoWeb.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesenvolvimentoWeb.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Pagamentos")]
    public class PagamentosController : Controller
    {
        private readonly PagamentoContext context;

        public PagamentosController(PagamentoContext context)
        {
            this.context = context;
        }
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Pagamento> GetPagamentos() {
            return context.Pagamentos.ToList();
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetIdPagamento(int id)
        {
            return Ok(context.Pagamentos.FirstOrDefault(p => p.Id == id));
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult IncluirPagamento([FromBody]Pagamento pagamento)
        {
            try
            {
                if (context.Pagamentos.Any(p => p.Id == pagamento.Id))
                {
                    return BadRequest();
                }
                var pag = context.Pagamentos.Add(pagamento);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AtualizarPagamento([FromBody]Pagamento pagamento)
        {
            try
            {
                context.Pagamentos.Update(pagamento);
                context.SaveChanges();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult DeletarPagamento(int id)
        {

            try
            {
                context.Pagamentos.Remove(context.Pagamentos.FirstOrDefault(p => p.Id == id));
                context.SaveChanges();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}