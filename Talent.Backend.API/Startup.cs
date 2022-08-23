using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using Talent.Backend.DataAccessEF;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.Email;
using Talent.Backend.Email.Contracts;
using Talent.Backend.Email.Models;
using Talent.Backend.Service.Dtos;

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

            services.AddControllers().ConfigureApiBehaviorOptions(o =>
            {
                //o.InvalidModelStateResponseFactory = context =>
                //{
                //    var _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();
                //    var ex = new Exception(context.ModelState.Values.First().Errors.First().ErrorMessage);
                //    _logger.Log(LogLevel.Error, ex, ex.Message);


                //    var responseModel = ResponseDto<string>.Fail(ex.Message, ex.StackTrace);
                //    context.HttpContext.Response.ContentType = "application/json";
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                //    var result = JsonSerializer.Serialize(responseModel);
                //    //return HttpContext.Response.WriteAsync(result);

                //    return (IActionResult)context.HttpContext.Response.WriteAsync(result);

                //    //context.HttpContext.Response.WriteAsync(responseModel.ToString());
                //    //return new EmptyResult();
                //};
            });

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<EFContext>()
            .AddDefaultTokenProviders();

            #region Email configuration
            var emailConfig = Configuration
               .GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            #endregion

            #region JWT Configuration
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opciones =>
                {
                    opciones.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["llavejwt"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talent.Backend.API", Version = "v1" });
            });

            services.AddDbContext<EFContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            //services.AddDbContext<EFContext>(options => options
            //    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            //    .UseSqlServer(Configuration.GetConnectionString("Default")));


            //ConfigureBackendDataAccessEF(services);
            //ConfigureBackendBussines(services);
            //ConfigureBackendService(services);
            DependencyInjectionRegister.AddRegistration(services);
            services.AddApplicationInsightsTelemetry(Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var ex = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
                    var responseModel = ResponseDto<string>.Fail(ex.Message, ex.InnerException.ToString());

                    context.Response.ContentType = "application/json";
                    responseModel.Title = "One or more errors occurred.";
                    if (ex is DbException) // we only care about this particular exception
                    {
                        // Send exception message as plain message
                        // _logger.Log(LogLevel.Error, ex.Message);

                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Type = "DbException";
                        responseModel.Status = context.Response.StatusCode;
                    }
                    else
                    {
                        // Send generic error as plain message
                        //_logger.Log(LogLevel.Error, ex, ex.Message);
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Type = "Exception";
                        responseModel.Status = context.Response.StatusCode;
                    }

                    var result = JsonSerializer.Serialize(responseModel);
                    await context.Response.WriteAsync(result);
                });
            });

            //app.UseMiddleware<ErrorHanddlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/health");
            });
        }
    }
}
