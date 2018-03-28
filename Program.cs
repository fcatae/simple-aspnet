using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
            app.Run( async ctx => {
                await ctx.Response.WriteAsync("Boa noite");
            });
        }
    }
}
