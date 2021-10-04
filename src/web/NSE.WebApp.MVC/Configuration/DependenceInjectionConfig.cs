using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebAPI.Core.Identidade.Usuario;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using System;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAspNetUser, AspNetUser>();


            #region HttpServices

            services.AddTransient<HttpClientAuthorizationDelegationHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
                .AddPolicyHandler(PollyConfig.PollyConfiguration())
                 .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegationHandler>()
                .AddPolicyHandler(PollyConfig.PollyConfiguration())
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddHttpClient<ICarrinhoService, CarrinhoService>()
               .AddHttpMessageHandler<HttpClientAuthorizationDelegationHandler>()
               .AddPolicyHandler(PollyConfig.PollyConfiguration())
               .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            #endregion
        }
    }
}
