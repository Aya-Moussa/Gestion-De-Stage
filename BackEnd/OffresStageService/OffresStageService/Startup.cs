using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DOMAIN.Models;
using DOMAIN.Queries;
using DOMAIN.Handlers;
using DATA.Repositories;
using DOMAIN.Interface;
using AutoMapper;
using DOMAIN.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using API.Middleware;
using DOMAIN.Services;

namespace OffresStageService
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
            services.AddControllers()
       .AddJsonOptions(options =>
       {
            // This makes enum properties bind from strings like "Refusee"
            options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());

            // Optional: make property names case-insensitive
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
       });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

               
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token.\nExample: Bearer eyJhbGciOiJIUzI1NiIs..."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;  // For development only
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey123")),

            RoleClaimType = ClaimTypes.Role  ,
             NameClaimType = ClaimTypes.NameIdentifier

        };
        
    });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:9001/");
            });



            services.AddTransient(typeof(IRequestHandler<GetAllGenericQuery<OffreDeStage>, IEnumerable<OffreDeStage>>), typeof(GetAllGenericHandlers<OffreDeStage>));
            services.AddTransient(typeof(IRequestHandler<PostGeneric<OffreDeStage>, string>), typeof(AddGenericHandlers<OffreDeStage>));
            services.AddTransient(typeof(IRequestHandler<DeleteGeneric<OffreDeStage>, string>), typeof(DeleteGenericHandlers<OffreDeStage>));
            services.AddTransient(typeof(IRequestHandler<GetGenericQueryById<OffreDeStage>, OffreDeStage>), typeof(GetGenericHandlerById<OffreDeStage>));
            services.AddTransient(typeof(IRequestHandler<PutGeneric<OffreDeStage>, string>), typeof(PutGenericHandlers<OffreDeStage>));

            services.AddTransient(typeof(IRequestHandler<GetAllGenericQuery<Candidature>,IEnumerable<Candidature>>),typeof (GetAllGenericHandlers<Candidature>));
            services.AddTransient(typeof(IRequestHandler<GetGenericQueryById<Candidature>,Candidature>), typeof(GetGenericHandlerById<Candidature>));
            services.AddTransient(typeof(IRequestHandler<PostGeneric<Candidature>, string>), typeof(AddGenericHandlers<Candidature>));
            services.AddTransient(typeof(IRequestHandler<DeleteGeneric<Candidature>, string>), typeof(DeleteGenericHandlers<Candidature>));
            services.AddTransient(typeof(IRequestHandler<PutGeneric<Candidature>, string>), typeof(PutGenericHandlers<Candidature>));

            services.AddTransient(typeof(IRequestHandler<GetAllGenericQuery<Tache>, IEnumerable<Tache>>), typeof(GetAllGenericHandlers<Tache>));
            services.AddTransient(typeof(IRequestHandler<GetGenericQueryById<Tache>, Tache>), typeof(GetGenericHandlerById<Tache>));
            services.AddTransient(typeof(IRequestHandler<PostGeneric<Tache>, string>), typeof(AddGenericHandlers<Tache>));
            services.AddTransient(typeof(IRequestHandler<DeleteGeneric<Tache>, string>), typeof(DeleteGenericHandlers<Tache>));
            services.AddTransient(typeof(IRequestHandler<PutGeneric<Tache>, string>), typeof(PutGenericHandlers<Tache>));

            services.AddTransient(typeof(IRequestHandler<GetAllGenericQuery<Evaluation>, IEnumerable<Evaluation>>), typeof(GetAllGenericHandlers<Evaluation>));
            services.AddTransient(typeof(IRequestHandler<GetGenericQueryById<Evaluation>, Evaluation>), typeof(GetGenericHandlerById<Evaluation>));
            services.AddTransient(typeof(IRequestHandler<PostGeneric<Evaluation>, string>), typeof(AddGenericHandlers<Evaluation>));
            services.AddTransient(typeof(IRequestHandler<DeleteGeneric<Evaluation>, string>), typeof(DeleteGenericHandlers<Evaluation>));
            services.AddTransient(typeof(IRequestHandler<PutGeneric<Evaluation>, string>), typeof(PutGenericHandlers<Evaluation>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseMiddleware<UserExistenceMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty; 
            });
        }
    }
}
