using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CoreAPI.DatabaseModels;
using CoreAPI.Filters;
using CoreAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CoreAPI
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
            services.Configure<MyAppSettings>(Configuration.GetSection("MyAppSettings"));//##Dependency Injection

            //services.AddScoped<CustomAuthorization>(); //## IF WE NEED CONTROLLER LEVEL Authorization

            //#### Entity Framework : #####
            var appSettings = new MyAppSettings();
            ConfigurationBinder.Bind(Configuration.GetSection("MyAppSettings"), appSettings);
            services.AddSingleton<MyAppSettings>();
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(appSettings.ConnectionString));
            //#### Entity Framework #####

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Application level Autorization
            services.AddMvc( 
                x=>
                {
                    x.Filters.Add<CustomAuthorization>(); //## added Custom Authorization application level

                    //x.Filters.Add<CustomExceptionFilter>();  //## added Filter based exception or use Middleware
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            #region Swagger
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My Core API",
                    Version = "v1",
                    Description = "ASP.NET Core API",
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);



                // https://stackoverflow.com/questions/56234504/migrating-to-swashbuckle-aspnetcore-version-5

                //https://github.com/OAI/OpenAPI-Specification/blob/master/versions/2.0.md
                c.AddSecurityDefinition("apiKey", new OpenApiSecurityScheme
                {
                    Description = "",
                    Name = "apiKey", //Required. The name of the header or query parameter to be used.
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "apiKey"
                });

                //c.AddSecurityRequirement(xx);

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,

                //        },
                //        new List<string>() { "123" }
                //    }
                //});

            });


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            #region Swagger
            app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            #endregion

            app.UseMyLoggerMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMyCustomExceptionMiddleware(); //## added CustomExceptionMiddleware or use filter

            app.UseMvc();

           
        }
    }
}
