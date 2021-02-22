using NUnit.Framework;
using passwordValidation.Services;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Services
{
    [ExcludeFromCodeCoverage]
    internal class MinimumUppercaseValidationServiceTests
    {
        [TestCase(1, "Password", ExpectedResult = true)]
        [TestCase(1, "password", ExpectedResult = false)]
        public bool Should_Return_ExpectedResult(long minimumUppercase, string password)
        {
            var minimumUppercaseValidationService = new MinimumUppercaseValidationService(minimumUppercase);
            return minimumUppercaseValidationService.IsValid(password);
        }
    }
}
