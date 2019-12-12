using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DesenvolvimentoWeb.Projeto02.Data;
using DesenvolvimentoWeb.Projeto02.Models;
using DesenvolvimentoWeb.Projeto02.Services;
using DesenvolvimentoWeb.Projeto02.Dados;

namespace DesenvolvimentoWeb.Projeto02
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<EventosContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EventosConnection")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UsuariosDbContext>(options =>
                options.UseSqlServer(Configuration
                .GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<UsuariosDbContext>()
                .AddDefaultTokenProviders();

            //Após o AddIdentity, modificamos o caminho do login e 
            //opcionalmente, do logout (Padrão: /Account/Login)
            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Usuarios/Login";
                options.LogoutPath = "/Usuarios/Logout";
                options.AccessDeniedPath = "/Usuarios/AccessDenied";
            });


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRoles(serviceProvider).Wait();
        }
        //Defini metodo parar incluir novos perfis(role)
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();
            string[] roleNames = { "ADMIN", "USER", "GUEST" };
            IdentityResult result;
            foreach (var item in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(item);
                if (!roleExists)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
        }
    }
}
