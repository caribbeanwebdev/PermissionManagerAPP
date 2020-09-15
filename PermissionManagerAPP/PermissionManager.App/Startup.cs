using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PermissionManager.Core.Data;
using PermissionManager.Core.Data.Entity;
using PermissionManager.Core.Mapping;
using PermissionManager.Core.Service;
using PermissionManager.Infrastructure.Database;
using PermissionManager.Infrastructure.Database.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VueCliMiddleware;

namespace PermissionManager.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddControllers();
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp";
      });
      services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "PermissionManagerDb"));
      services.AddScoped<IGenericRepository<Permission>, GenericRepository<Permission>>();
      services.AddScoped<IGenericRepository<PermissionType>, GenericRepository<PermissionType>>();
      services.AddScoped<IPermissionService, PermissionService>();
      services.AddScoped<IPermissionTypeService, PermissionTypeService>();
      services.AddAutoMapper(typeof(MappingProfile));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      // global cors policy
      app.UseCors(x => x
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true) // allow any origin
          .AllowCredentials()); // allow credentials
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSpa(spa =>
      {
        if (env.IsDevelopment())
          spa.Options.SourcePath = "ClientApp";
        else
          spa.Options.SourcePath = "dist";

        if (env.IsDevelopment())
        {
          spa.UseVueCli(npmScript: "serve");
        }

      });
    }
  }
}
