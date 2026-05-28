using CleanArt.Application.Abstractions.Behaviors;
using CleanArt.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(LoggingBehaivor<,>));
            });
            services.AddTransient<PricingService>();
            return services;
        }
    }

    public interface ICachable<TKey, TValue>
    {
        string Get(TKey key,TValue value);
    }
}
