using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EMigrant.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authentication;

namespace EMigrant.App.Frontend
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
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddSingleton<RepositorioMigrante>(new RepositorioMigrante(new EMigrant.App.Persistencia.AppContext()));
            services.AddSingleton<RepositorioFamiliares>(new RepositorioFamiliares(new EMigrant.App.Persistencia.AppContext()));
            services.AddSingleton<RepositorioAmigos>(new RepositorioAmigos(new EMigrant.App.Persistencia.AppContext()));
            services.AddSingleton<RepositorioParientes>(new RepositorioParientes(new EMigrant.App.Persistencia.AppContext()));
            services.AddSingleton<RepositorioEntidades>(new RepositorioEntidades(new EMigrant.App.Persistencia.AppContext()));
            services.AddSingleton<RepositorioServicio>(new RepositorioServicio(new EMigrant.App.Persistencia.AppContext()));
            //services.AddSingleton<RepositorioMigrante>();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseAuthentication();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
/*
dotnet ef migrations add IdentityAzure --context IdentityDataContext
dotnet ef database update --context IdentityDataContext
*/