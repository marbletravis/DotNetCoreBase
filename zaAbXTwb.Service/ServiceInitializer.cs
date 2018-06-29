using System;
using Microsoft.Extensions.DependencyInjection;
using zaAbXTwb.Service.Services;

namespace zaAbXTwb.Service
{
    public class ServiceInitializer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
    }
    }
}
