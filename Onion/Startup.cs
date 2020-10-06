using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;  
using Onion.Infrastructure.Repository;
using Onion.DataAccess;
using Onion.Core.Interfaces.Repository;
using Onion.Infrastructure.ApplicationLog;
using Onion.Helpers;

namespace Onion
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
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
                                    options
                                        .UseLazyLoadingProxies()
                                        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericEFRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddTransient<IProductDetailsRepository, ProductDetailsRepository>();
            
            services.AddScoped<ILoggingRepository, Log4NetRepository>(service =>
            {
                return new Log4NetRepository(Configuration["Log4Net:path"],
                                          Configuration["Log4Net:elementName"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }

        private void setConfigurarionManager()
        {
            ConfigurationManager.LOG4NET_PATH = Configuration["Log4Net:path"];
            ConfigurationManager.LOG4NET_ELEMENTNAME = Configuration["Log4Net:elementName"];
        }
    }
}
