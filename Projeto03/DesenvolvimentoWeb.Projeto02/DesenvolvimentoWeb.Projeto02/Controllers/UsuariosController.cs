using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesenvolvimentoWeb.Projeto02.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsuariosController(UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //métodos auxiliares
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);               
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //métodos de registro
        [HttpGet]
        public IActionResult Registrar(string returnUrl = null)
        {
            var list = _roleManager.Roles.Select(p => p.Name).ToList();
            ViewBag.Roles = new SelectList(list);
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model, string perfil,
            string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    UserName = model.Nome
                };

                var result = await _userManager
                    .CreateAsync(user, model.Senha);

                if (result.Succeeded)
                {
                    var approle = await _roleManager.FindByNameAsync(perfil);
                    if (approle != null)
                    {
                        await _userManager.AddToRoleAsync(user, perfil);
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
            return View(model);
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            LogonViewModel model, string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(
                        model.Nome, model.Senha, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(
                        string.Empty, "Usuário ou senha inválidos.");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied() {
            ViewData["MensagemErro"] = "Você não tem permissão para acessar este recurso!";
            return View("_Erro");
        }
    }
}