using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Linq;
using Talent.Backend.API.Middleware;
using Talent.Backend.DataAccessEF;

namespace Talent.Backend.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        /// <summary>
        /// Agrega la inyecci�n de dependencias del data access
        /// </summary>
        /// <param name="services">Servicios</param>
        private void ConfigureBackendService(IServiceCollection services)
        {
            RegisterAssembly("Talent.Backend.Service", services);
        }

        /// <summary>
        /// Agrega la inyecci�n de dependencias del data access
        /// </summary>
        /// <param name="services">Servicios</param>
        private void ConfigureBackendBussines(IServiceCollection services)
        {
            RegisterAssembly("Talent.Backend.Bussiness", services);
        }

        /// <summary>
        /// Agrega la inyecci�n de dependencias del data access
        /// </summary>
        /// <param name="services">Servicios</param>
        private void ConfigureBackendDataAccessEF(IServiceCollection services)
        {
            RegisterAssembly("Talent.Backend.DataAccessEF", services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                var frontUrl = Configuration.GetValue<string>("FrontUrl");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontUrl).AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talent.Backend.API", Version = "v1" });
            });

            services.AddDbContext<EFContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Default"))
            );


            //ConfigureBackendDataAccessEF(services);
            //ConfigureBackendBussines(services);
            //ConfigureBackendService(services);
            DependencyInjectionRegister.AddRegistration(services);
        }

        /// <summary>
        /// M�todo auxiliar para registrar la inyecci�n de dependencias
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="services"></param>
        private void RegisterAssembly(string assembly, IServiceCollection services)
        {
            var BackendServiceAssembly = System.Reflection.Assembly.Load(assembly);

            var registrationsDataAccess = from type in BackendServiceAssembly.GetExportedTypes()
                                          where type.GetInterfaces().Any()
                                          select new { service = type.GetInterfaces().First(), implementation = type };

            foreach (var reg in registrationsDataAccess)
            {
                services.AddTransient(reg.service, reg.implementation);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talent.Backend.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHanddlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
