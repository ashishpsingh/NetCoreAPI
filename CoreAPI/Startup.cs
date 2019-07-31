using CoreAPI.DatabaseModels;
using CoreAPI.Filters;
using CoreAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
