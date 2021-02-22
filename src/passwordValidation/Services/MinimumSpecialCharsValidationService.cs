using passwordValidation.Interfaces.Services;
using System.Linq;

namespace passwordValidation.Services
{
    public class MinimumSpecialCharsValidationService : IPasswordValidationService
    {
        private readonly long _minimumSpecialChars;
        private readonly char[] _specialChars;

        public MinimumSpecialCharsValidationService(long minimumSpecialChars, char[] specialChars)
        {
            _minimumSpecialChars = minimumSpecialChars;
            _specialChars = specialChars;
        }

        public bool IsValid(string password) => password.Count(it => _specialChars.Contains(it)) >= _minimumSpecialChars;
    }
}
