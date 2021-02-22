using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using passwordValidation.Handlers;
using passwordValidation.Interfaces.Handlers;
using passwordValidation.Interfaces.Services;
using passwordValidation.Services;
using System;
using System.Collections.Generic;

namespace passwordValidation.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterHandlers(services);
            RegisterServices(services, configuration);

            return services;
        }

        private static void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<IPasswordValidationHandler, PasswordValidationHandler>();
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(serviceProvider =>
            {
                return new List<IPasswordValidationService>
                {
                    new MinimumLengthValidationService(Convert.ToInt64(configuration["PasswordValidation:MinimumLength"])),
                    new MinimumDigitsValidationService(Convert.ToInt64(configuration["PasswordValidation:MinimumDigits"])),
                    new MinimumLowercaseValidationService(Convert.ToInt64(configuration["PasswordValidation:MinimumLowercase"])),
                    new MinimumUppercaseValidationService(Convert.ToInt64(configuration["PasswordValidation:MinimumUppercase"])),
                    new MinimumSpecialCharsValidationService(
                        Convert.ToInt64(configuration["PasswordValidation:MinimumSpecialChars"]),
                        configuration["PasswordValidation:ValidSpecialChars"].ToCharArray()),
                    new MinimumRepeatCharsValidationService()
                };
            });
        }
    }
}
