using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unified.Domain.Interfaces;
using Unified.Infra.MrgreenAdapter;
using Unified.Presentation.AutoMapper;
using AutoMapper;

namespace Unified.Presentation
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper();
            //AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ViewModelToDomainMappingProfile>();
            //});
            //services.AddSingleton(config);
            //services.AddScoped<IMapper, Mapper>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IMrgreenAdapterSettings>(c => new MrgreenAdapterSettings(
                    Configuration.GetValue<string>("MrgreenUrl")
                ));

            services.AddScoped<IMrgreenAdapter, MrgreenAdapter>();
            //services.AddScoped<IRedbetAdapter, RedbetAdapter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Customer}/{action=Index}/{id?}");
            });
        }
    }
}
