using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Builder;
using Okta.AspNet.Abstractions;

namespace Willcord.Services.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                       .AddJsonFile("ocelot.json")
                       .AddEnvironmentVariables();
               })
               .ConfigureServices(s =>
               {
                   s.AddCors(options =>
                   {
                       // The CORS policy is open for testing purposes. In a production application, you should restrict it to known origins.
                       options.AddPolicy(
                           "AllowAll",
                           builder => builder.AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader());
                   });
                   s.AddAuthentication(sharedOptions =>
                   {
                       sharedOptions.DefaultAuthenticateScheme = Okta.AspNetCore.OktaDefaults.ApiAuthenticationScheme;
                       sharedOptions.DefaultChallengeScheme = Okta.AspNetCore.OktaDefaults.ApiAuthenticationScheme;
                       sharedOptions.DefaultSignInScheme = Okta.AspNetCore.OktaDefaults.ApiAuthenticationScheme;
                   })
                   .AddOktaWebApiTest(new OktaWebApiOptions
                   {
                       
                   });
                   s.AddAuthorization();
                   s.AddOcelot();
               })
               .UseIISIntegration()
               .Configure(app =>
               {
                   app.UseCors(builder =>
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                   app.UseAuthentication();
                   app.UseAuthorization();
                   app.UseOcelot().Wait();
               })
               .Build()
               .Run();
        }
    }
}