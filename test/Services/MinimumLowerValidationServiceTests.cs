using NUnit.Framework;
using passwordValidation.Services;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Services
{
    [ExcludeFromCodeCoverage]
    internal class MinimumLowercaseValidationServiceTests
    {
        [TestCase(1, "Password", ExpectedResult = true)]
        [TestCase(1, "PASSWORD", ExpectedResult = false)]
        public bool Should_Return_ExpectedResult(long minimumLowercase, string password)
        {
            var minimumLowercaseValidationService = new MinimumLowercaseValidationService(minimumLowercase);
            return minimumLowercaseValidationService.IsValid(password);
        }
    }
}
