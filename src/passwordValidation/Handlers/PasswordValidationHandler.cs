using Microsoft.Extensions.Logging;
using passwordValidation.Interfaces.Handlers;
using passwordValidation.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace passwordValidation.Handlers
{
    public class PasswordValidationHandler : IPasswordValidationHandler
    {
        private readonly List<IPasswordValidationService> _passwordValidationServices;
        private readonly ILogger<PasswordValidationHandler> _logger;

        public PasswordValidationHandler(
            List<IPasswordValidationService> passwordValidationServices, ILogger<PasswordValidationHandler> logger)
        {
            _passwordValidationServices = passwordValidationServices;
            _logger = logger;
        }

        public bool Validate(string password)
        {
            try
            {
                return _passwordValidationServices.TrueForAll(it => it.IsValid(password));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro validando senha", ex);
                throw;
            }
        }
    }
}
