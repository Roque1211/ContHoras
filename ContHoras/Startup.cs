using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using BL.Contracts;
using BL.Implementations;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Contracts;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ContHoras
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
            //inyección del contexto
            services.AddDbContext<conthorasContext>(opts => opts.UseMySql(Configuration["ConnectionString:conthoras"]));

            // aqui las inyecciones interfaz-clase
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // directivas CORS para permitir comunicaciones entre orígenes del mismo tipo
            // entre localhost de Angular y el backend
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCorsForLocalhost",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            // CONFIGURACIÓN DEL SERVICIO DE AUTENTICACIÓN JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
                        )
                    };
                });

            // controllers
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ContHoras",
                    Description = "A simple App ASP.NET Core Web API that controls staff works hour per project",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Roque Flores",
                        Email = "roque1211@gmail.com",
                        Url = new Uri("https://github.com/RoqueDesIn/ContHoras"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                            // add Basic Authentication
                            var basicSecurityScheme = new OpenApiSecurityScheme
                            {
                                Type = SecuritySchemeType.Http,
                                Scheme = "basic",
                                Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
                            };
                            c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {basicSecurityScheme, new string[] { }}
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            // development enviroment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContHoras v1"));
            }

            app.UseHttpsRedirection();
            // AÑADIMOS EL MIDDLEWARE DE AUTENTICACIÓN
            // DE USUARIOS AL PIPELINE DE ASP.NET CORE
            app.UseAuthentication();

            //
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
