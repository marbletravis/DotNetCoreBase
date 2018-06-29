using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using zaAbXTwb.Data;
using zaAbXTwb.Data.Models;
using zaAbXTwb.Service;

namespace zaAbXTwb.Client
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
      services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<MyDbContext>()
        .AddDefaultTokenProviders();

      ServiceInitializer.ConfigureServices(services);
      services.Configure<AuthMessageSenderOptions>(Configuration);

      services.AddMvc();

      // In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });

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
      }

      app.UseStaticFiles();
      app.UseSpaStaticFiles();



      app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
        {
          appBuilder.UseMiddleware(typeof(ErrorHandlingMiddleware));
        });

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
      });



      app.UseSpa(spa =>
      {
              // To learn more about options for serving an Angular SPA from ASP.NET Core,
              // see https://go.microsoft.com/fwlink/?linkid=864501

              spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          //spa.UseAngularCliServer(npmScript: "start");
          spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
        }

      });
    }
  }
}
