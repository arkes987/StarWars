using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Starwars.Abstraction.Dto.Character;
using Starwars.Abstraction.Interfaces.Logic;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Controllers.Mappings.Character;
using Starwars.Controllers.Mappings.Paging;
using Starwars.Data;
using Starwars.Data.Models.Character;
using Starwars.Logic.Character;

namespace Starwars
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Starwars", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.Controllers.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            }); 
            services.AddHealthChecks();
            ConfigureOwnServices(services);

            services.AddEntityFrameworkSqlServer().AddDbContext<StarwarsContext>(options => options.UseSqlServer(Configuration["AppSettings:ConnectionString"]));

            services.AddScoped<IStarwarsContext, StarwarsContext>();

        }

        private void ConfigureOwnServices(IServiceCollection services)
        {
            services.AddScoped<ICharacterLogic, CharacterLogic>();
            services.AddSingleton<ICharacterMapping, CharacterMapping>();

            services
                .AddSingleton<IPagingMapping<CharacterResponseDto, CharacterModel>,
                    PagingMapping<CharacterResponseDto, CharacterModel>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Starwars");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
