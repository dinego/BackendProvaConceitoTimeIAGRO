using bookstore.api.Middleware;
using Bookstore.Application.AppServices;
using Bookstore.Application.AppServices.Book;
using Bookstore.Application.Interfaces.Book;
using Bookstore.Application.Interfaces.Shipping;
using Infra.Interfaces;
using Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Service.Interfaces;
using Service.Interfaces.Shipping;
using Service.Interfaces.Shipping.Strategy;
using Service.Services.Book;
using Service.Services.Shipping;
using Service.Services.Shipping.Strategy;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace bookstore.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona o serviço do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookstore.API", Version = "v1" });
                c.DocumentFilter<SwaggerSummaryDocumentFilter>();
            });

            services.AddMvcCore()
                .AddApiExplorer();

            // AppServices
            services.AddTransient<IBookAppService, BookAppService>();
            services.AddTransient<IShippingAppService, ShippingAppService>();

            // Services
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IShippingService, ShippingService>();
            services.AddTransient<IShippingStrategy, ShippingNormalStrategy>();
            services.AddTransient<IShippingStrategy, ShippingExpressStrategy>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configurações para ambiente de produção...
            }

            // Configuração do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome do Seu API V1");
                c.DocExpansion(DocExpansion.List);
            });

            // Outras configurações de middleware...

            // ativando o middleware de error
            app.UseMiddleware(typeof(ErrorMiddleware));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}