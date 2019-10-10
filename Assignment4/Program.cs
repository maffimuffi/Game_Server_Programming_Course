﻿using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Assignment3
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
           
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
                //.UseKestrel(o => o.Listen(IPAddress.Loopback, 5000))
    }
}