using NUnit.Framework;
using passwordValidation.Services;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Services
{
    [ExcludeFromCodeCoverage]
    internal class MinimumLengthValidationServiceTests
    {
        [TestCase(5, "passw", ExpectedResult = true)]
        [TestCase(6, "password", ExpectedResult = true)]
        [TestCase(5, "pass", ExpectedResult = false)]
        public bool Should_Return_ExpectedResult(long minimumLength, string password)
        {
            var minimumLengthValidationService = new MinimumLengthValidationService(minimumLength);
            return minimumLengthValidationService.IsValid(password);
        }
    }
}
