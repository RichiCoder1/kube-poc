using System.Net.Http;
using IdentityModel.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IDiscoveryCache>(r => {
                var factory = r.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache("https://ushipapp.oktapreview.com/oauth2/default", () => factory.CreateClient());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var clientFactory = context.RequestServices.GetService<IHttpClientFactory>();
                    var client = clientFactory.CreateClient();
                    var cache = context.RequestServices.GetService<IDiscoveryCache>();

                    var meta = await cache.GetAsync();

                    // var userInfo = client.GetUserInfoAsync(new UserInfoRequest {
                    //     Address = meta.UserInfoEndpoint,
                    //     Token
                    // });

                    context.Response.StatusCode = 200;

                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }

    internal class CheckRequest
    {
        
    }
}
