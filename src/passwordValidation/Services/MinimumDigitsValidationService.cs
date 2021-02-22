using passwordValidation.Interfaces.Services;
using System.Linq;

namespace passwordValidation.Services
{
    public class MinimumDigitsValidationService : IPasswordValidationService
    {
        private readonly long _minimumDigits;

        public MinimumDigitsValidationService(long minimumDigits)
        {
            _minimumDigits = minimumDigits;
        }

        public bool IsValid(string password) => password.Count(it => char.IsDigit(it)) >= _minimumDigits;
    }
}
