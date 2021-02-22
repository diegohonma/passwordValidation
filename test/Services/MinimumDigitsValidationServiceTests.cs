using NUnit.Framework;
using passwordValidation.Services;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Services
{
    [ExcludeFromCodeCoverage]
    internal class MinimumDigitsValidationServiceTests
    {
        [TestCase(1, "password1", ExpectedResult = true)]
        [TestCase(2, "password1", ExpectedResult = false)]
        public bool Should_Return_ExpectedResult(long minimumDigits, string password)
        {
            var minimumDigitsValidationService = new MinimumDigitsValidationService(minimumDigits);
            return minimumDigitsValidationService.IsValid(password);
        }
    }
}
