using Globomantics.Filters;
using Globomantics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Globomantics
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton<ILoanService, LoanService>();
            services.AddTransient<IQuoteService, QuoteService>();
            services.AddTransient<IFeatureService, FeatureService>(sp => new FeatureService(_env.WebRootPath));
            services.AddTransient<IRateService, RateService>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ModelValidationFilter>();
            });
            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });

            services.AddLogging(builder =>
            {
                builder.AddConsole(options =>
                {
                    Configuration.GetSection("Logging").Bind(options);
                });
                builder.AddDebug();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
                builder.MapControllerRoute("default",
                    "/{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
