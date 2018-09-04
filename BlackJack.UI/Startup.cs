using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
using BlackJack.DAL;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using BlackJack.EntitiesLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlackJack.UI
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddDbContext<BlackJackContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BlackJackContext"]));
      services.AddTransient<ICardRepository<Card>, CardRepository>();
      services.AddTransient<IPlayerRepository<Player>, PlayerRepository>();
      services.AddTransient<IPlayerCardRepository, PlayerCardRepository>();
      services.AddTransient<IGameSet, GameSetService>();
      services.AddTransient<IGameLogic, GameLogicService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
        }
      });

      app.UseMvcWithDefaultRoute();
      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
