using NUnit.Framework;
using passwordValidation.Services;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Services
{
    [ExcludeFromCodeCoverage]
    internal class MinimumSpecialCharsValidationServiceTests
    {
        [TestCase(1, "!@#$%^&*()-+", "password@", ExpectedResult = true)]
        [TestCase(1, "!@#$%^&*()-+", "password", ExpectedResult = false)]
        public bool Should_Return_ExpectedResult(long minimumUppercase, string specialChars, string password)
        {
            var minimumSpecialCharsValidationService = new MinimumSpecialCharsValidationService(minimumUppercase, specialChars.ToCharArray());
            return minimumSpecialCharsValidationService.IsValid(password);
        }
    }
}
