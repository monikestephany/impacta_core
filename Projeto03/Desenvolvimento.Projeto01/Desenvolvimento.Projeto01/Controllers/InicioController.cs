using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desenvolvimento.Projeto01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desenvolvimento.Projeto01.Controllers
{
    public class InicioController : Controller
    {
        public string MostrarTexto()
        {
            return "<h1> Conceitos MVC</h1>";
        }

        public IActionResult MostrarPDF()
        {
            return File("~/arquivos/Desenvolvimento Web com Asp.Net Core - Rev03.pdf", "application/pdf");
        }
        public IActionResult MostrarImagem()
        {
            return File("~/arquivos/bolas-de-natal-boneco-de-neve-arvore-de-natal.jpg", "image/jpeg");
        }
        public ViewResult MostrarConteudo()
        {
            return View("MostrarConteudo");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MostrarProduto()
        {
            Produto produto = new Produto { Codigo = 111, Descricao = "TV 55", Preco = 1500.00 };
            return View(produto);
        }
        public IActionResult ListarProdutos1()
        {
            List<Produto> produtos = new List<Produto>
            { new Produto { Codigo = 111, Descricao = "TV 55", Preco = 1500.00 },
             new Produto { Codigo = 222, Descricao = "Radio", Preco = 1500.00 },
             new Produto { Codigo = 333, Descricao = "Celular", Preco = 1500.00 },
             new Produto { Codigo = 444, Descricao = "Tablet", Preco = 1500.00 }};

            return View(produtos);
        }
        public IActionResult ListarProdutos2()
        {
            ViewData["Title"] = "ListarProdutos2";
            HashSet<Produto> produtos = new HashSet<Produto>
            { new Produto { Codigo = 111, Descricao = "TV 55", Preco = 1500.00 },
             new Produto { Codigo = 222, Descricao = "Radio", Preco = 1500.00 },
             new Produto { Codigo = 333, Descricao = "Celular", Preco = 1500.00 },
             new Produto { Codigo = 444, Descricao = "Tablet", Preco = 1500.00 }};

            return View("ListarProdutos1", produtos);
        }
        [HttpGet]
        public IActionResult CadastroProduto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastroProduto(Produto produto)
        {
            if(!ModelState.IsValid)
                return View();
            else
                return View("MostrarProduto",produto);
        }
    }
}