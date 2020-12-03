using Gvips.API.Interfaces;
using Gvips.API.Services;
using Gvips.Application.Posts.Commands.Handlers;
using Gvips.Application.Posts.Queries.handlers;
using Gvips.Application.Users.Commands.Handlers;
using Gvips.Application.Users.Queries.Handlers;
using Gvips.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Gvips.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<LoginService>();
            services.AddScoped<UserCommandHandler>();
            services.AddScoped<UserQueryHandler>();
            services.AddScoped<PostCommandHandler>();
            services.AddScoped<PostQueryHandler>();
            return services;
        }
    }
}