using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Teste.ItLAB.Data;
using Teste.ItLAB.Bussines.Interface;
using Teste.ItLAB.Bussines.Repositories;
using Teste.ItLAB.Model.Interfaces.Base;
using Teste.ItLAB.Data.Repositories.Base;
using Teste.ItLAB.Model.Interfaces;
using Teste.ItLAB.Data.Repositories;
using AutoMapper;

namespace Teste.ItLAB.WebAplication
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
            services.AddMvc();
            services.AddAutoMapper();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ContextAplication>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IProdutoBussines, ProdutoBussinesRepository>();
            services.AddScoped<ITipoProdutoBussines, TipoProdutoBussinesRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITipoProdutoRepository, TipoProdutoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Produto}/{action=Index}/{id?}");
            });
        }
    }
}
