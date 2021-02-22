using passwordValidation.Interfaces.Services;
using System.Linq;

namespace passwordValidation.Services
{
    public class MinimumUppercaseValidationService : IPasswordValidationService
    {
        private readonly long _minimumUppercase;

        public MinimumUppercaseValidationService(long minimumUppercase)
        {
            _minimumUppercase = minimumUppercase;
        }

        public bool IsValid(string password) => password.Count(it => char.IsUpper(it)) >= _minimumUppercase;
    }
}
