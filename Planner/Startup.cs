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
using System;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Planner.Data.Context;

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

      //// получаем строку подключения из файла конфигурации
      //string connection = Configuration.GetConnectionString("DefaultConnection");
      //// добавляем контекст в качестве сервиса в приложение
      //services.AddDbContext<AppDbContext>(options =>
      //  options.UseSqlServer(connection));


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


      services.AddMvc();
      services.Configure<FormOptions>(x =>
      {
        x.ValueLengthLimit = Int32.MaxValue;
        x.MultipartBodyLengthLimit = Int32.MaxValue;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

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
