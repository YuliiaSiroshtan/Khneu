using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Planner.Common.Constants;
using Planner.DependencyInjection.Extensions;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using static System.Int32;

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
                  // укзывает, будет ли валидироваться издатель при валидации токена
                  ValidateIssuer = true,
                  // строка, представляющая издателя
                  ValidIssuer = JwtConst.ISSUER,
                  // будет ли валидироваться потребитель токена
                  ValidateAudience = true,
                  //// установка потребителя токена
                  ValidAudience = JwtConst.AUDIENCE,
                  // будет ли валидироваться время существования
                  //ValidateLifetime = true,
                  // установка ключа безопасности
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.SECURITY_KEY)),
                  // валидация ключа безопасности
                  ValidateIssuerSigningKey = true,
                };
              });

      services.AddMvc(option=> { option.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

      services.Configure<FormOptions>(x =>
      {
        x.ValueLengthLimit = MaxValue;
        x.MultipartBodyLengthLimit = MaxValue;
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
