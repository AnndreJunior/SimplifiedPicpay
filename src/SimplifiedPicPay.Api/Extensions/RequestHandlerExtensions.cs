using System.Reflection;

namespace SimplifiedPicPay.Api.Extensions;

public static class RequestHandlerExtensions
{
    public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                     (i.GetGenericTypeDefinition() == typeof(IRequestHandler<>) ||
                      i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))))
            .ToList();
        foreach (var handlerType in handlerTypes)
        {
            var interfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType &&
                       (i.GetGenericTypeDefinition() == typeof(IRequestHandler<>) ||
                        i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, handlerType);
            }
        }

        return services;
    }
}
