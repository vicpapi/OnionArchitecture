using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Onion.Infrastructure.Repository;
using Onion.DataAccess;
using Onion.Core.Interfaces.Repository;
using Onion.Infrastructure.ApplicationLog;
using Onion.Core.Interfaces.Services;
using Onion.Infrastructure.Services;
using Onion.Infrastructure.ApplicationLog.Helper;

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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<CustomAttributes.LogAttribute>();

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

            SetConfigurarionManager();
        }

        private void SetConfigurarionManager()
        {
            ConfigurationManager.LOG4NET_PATH = Configuration["Log4Net:path"];
            ConfigurationManager.LOG4NET_ELEMENTNAME = Configuration["Log4Net:elementName"];
            ConfigurationManager.LOG4NET_EMAIL_TO = Configuration["Log4Net:EmailLogger:to"];
            ConfigurationManager.LOG4NET_EMAIL_FROM = Configuration["Log4Net:EmailLogger:from"];
            ConfigurationManager.LOG4NET_EMAIL_SUBJECT = Configuration["Log4Net:EmailLogger:subject"];
            ConfigurationManager.LOG4NET_EMAIL_BODY = Configuration["Log4Net:EmailLogger:body"];
            ConfigurationManager.LOG4NET_EMAIL_SMTPHOST = Configuration["Log4Net:EmailLogger:smtpHost"];
            ConfigurationManager.LOG4NET_EMAIL_PORT = Configuration["Log4Net:EmailLogger:port"].ToInt32();
            ConfigurationManager.LOG4NET_EMAIL_USERNAME = Configuration["Log4Net:EmailLogger:username"];
            ConfigurationManager.LOG4NET_EMAIL_PASSWORD = Configuration["Log4Net:EmailLogger:password"];
            ConfigurationManager.LOG4NET_EMAIL_ENABLEDSSL = Configuration["Log4Net:EmailLogger:enableSsl"].ToBool();
       }
    }
}
