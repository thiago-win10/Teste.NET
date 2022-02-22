using CamadaServices.Interfaces;
using CamadaServices.Services;
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
using Teste.NET.Domain;
using PadraoRepository.Interfaces;
using PadraoRepository.Repositorios;
using MySql.Data.EntityFramework;
using Domain.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Teste.NET.CamadaServices.Authorization;
using Teste.NET.CamadaServices.Services;
using Teste.NET.CamadaServices.Interfaces;
using Teste.NET.CamadaServices.Helpers;

namespace XYZ
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

            services.AddCors();
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes("AppSettings");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            //AutoMapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAutoMapper(typeof(Program));


            //Banco de Dados

            services.AddDbContext<XYZContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("XYZContext"), builder =>
                        builder.MigrationsAssembly("XYZ")));


            //Injeção de Dependencia

            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<SeedingProdutos>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IClienteEnderecoRepository, ClienteEnderecoRepository>();
            services.AddScoped<IClienteEnderecoService, ClienteEnderecoService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Teste.NET - Projeto/XYZ",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago Santos",
                        Email = "thiago.soares.dev@gmail.com",
                        Url = new Uri("https://github.com/thiago-win10/Teste.NET") 
                    }

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingProdutos seedingProdutos)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingProdutos.Seed();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "XYZ v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMiddleware<ErrorMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
