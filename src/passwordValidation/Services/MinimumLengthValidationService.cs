using passwordValidation.Interfaces.Services;

namespace passwordValidation.Services
{
    public class MinimumLengthValidationService : IPasswordValidationService
    {
        private readonly long _minimumLength;

        public MinimumLengthValidationService(long minimumLength)
        {
            _minimumLength = minimumLength;
        }

        public bool IsValid(string password) => password.Length >= _minimumLength;
    }
}
