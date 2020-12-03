using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MicroServiceA
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
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseCloudEvents();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        //endpoints.MapGet("/dapr/subscribe", async context =>
        //{
        //  // listen for these events
        //  var subscriptions = new
        //  {
        //    pubsubname = "pubsuba",
        //    topic = Shared.Const.EndPoints.EndPointA.EventTopic.NewOrderCheese,
        //    route = "newordercheese"
        //  };

        //  await context.Response.WriteAsync(JsonConvert.SerializeObject(subscriptions));
        //});

        endpoints.MapSubscribeHandler();
        endpoints.MapControllers();
      }
      );
    }
  }
}