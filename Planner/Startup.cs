using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Planner.DependencyInjection.Extensions;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Planner.Entities.JWT;

namespace Planner
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

      services.RegisterServices(Configuration);


      Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                  ValidateIssuer = true,

                  ValidIssuer = JwtConst.ISSUER,

                  ValidateAudience = true,

                  ValidAudience = JwtConst.AUDIENCE,

                  ValidateLifetime = true,

                  ValidateIssuerSigningKey = true,

                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.KEY)),

                };
              });

      services.AddMvc(option => { option.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

      services.Configure<FormOptions>(x =>
      {
        x.ValueLengthLimit = int.MaxValue;
        x.MultipartBodyLengthLimit = int.MaxValue;
      });

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planner", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner V1");
      });

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseAuthentication();
      app.UseMvc();


      app.Run(async (context) =>
      {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "src", "index.html"));
      });
    }
  }

}
