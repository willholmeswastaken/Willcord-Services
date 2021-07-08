using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Willcord.Services.Common
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddCommon(this IServiceCollection services)
        {
            services.AddSingleton<IDynamoDbContextFactory, DynamoDbContextFactory>();
        }
    }
}