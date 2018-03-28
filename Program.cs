using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                        .UseKestrel()
                        .Configure(MyChat)
                        .Build();

            host.Run();
        }
            
        static void MyChat(IApplicationBuilder app)
        {
            app.MapWhen( ctx => {
                return ctx.Request.Query.ContainsKey("beta");
            }, BetaFeature);

            app.Map("/ola", Hello);

            Default(app);            
        }

        static void BetaFeature(IApplicationBuilder app)
        {
            app.Run( async ctx => {
                await ctx.Response.WriteAsync("--BETA VERSION--");                
            });            
        }

        static void Hello(IApplicationBuilder app)
        {
            app.Run( async ctx => {
                await ctx.Response.WriteAsync("Ola!");                
            });            
        }

        static void Default(IApplicationBuilder app)
        {
            app.Run( async ctx => {
                await ctx.Response.WriteAsync("Boa noite!");                
            });            
        }
    }
}
