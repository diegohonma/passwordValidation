using passwordValidation.Interfaces.Services;
using System.Linq;

namespace passwordValidation.Services
{
    public class MinimumLowercaseValidationService : IPasswordValidationService
    {
        private readonly long _minimumLowercase;

        public MinimumLowercaseValidationService(long minimumLowercase)
        {
            _minimumLowercase = minimumLowercase;
        }

        public bool IsValid(string password) => password.Count(it => char.IsLower(it)) >= _minimumLowercase;
    }
}
