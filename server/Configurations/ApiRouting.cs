using System;
using server.Helpers;
using server.Helpers.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace server.Configurations
{
    public class ApiRouting : StartupConfig
    {

        public ApiRouting(IHostingEnvironment env, IConfiguration config) : base(env, config) { }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            return null;
        }

        public override void Configure(IApplicationBuilder app)
        {

            // Global error handler for API
            app.UseWhen(http => http.Request.Path.StartsWithSegments("/api"), appApi =>
            {
                var routeController = new RouteController(appApi.ApplicationServices);

                // Native error
                appApi.UseExceptionHandler(appB =>
                {
                    appB.Run(async http =>
                    {
                        var exf = http.Features.Get<IExceptionHandlerFeature>();
                        System.Exception error = (exf != null) ? exf.Error : new ErrorException();
                        http.Response.ContentType = "application/json";
                        http.Response.Headers.Add("x-api-standard", "1");
                        await http.Response.WriteAsync(
                          JsonConvert.SerializeObject(
                            routeController.WrapError(error, error.Message)
                          )
                        );
                        // Will log on file on production and console on development

                    });
                });

                // Custom error
                appApi.UseStatusCodePages(async context =>
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    Error error;
                    switch (context.HttpContext.Response.StatusCode)
                    {
                        case 401: error = new Unauthorized(); break;
                        case 404: error = new RouteNotFound(); break;
                        case 403: error = new Forbidden(); break;
                        default: error = new Error(); break;
                    }
                    context.HttpContext.Response.Headers.Add("x-api-standard", "1");
                    await context.HttpContext.Response.WriteAsync(
                      JsonConvert.SerializeObject(
                        routeController.WrapError(error, null)
                      )
                    );
                });

                // Use MVC
                appApi.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                });

                // At this point status code must be already set by MVC
                // If not, respond with 404 Not Found
                appApi.Use(async (context, next) =>
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(
                      JsonConvert.SerializeObject(
                        routeController.WrapError(new RouteNotFound(), null)
                      )
                    );
                });
            });

        }
    }
}