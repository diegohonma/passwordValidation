using NUnit.Framework;
using passwordValidation.Services;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Services
{
    [ExcludeFromCodeCoverage]
    internal class MinimumRepeatCharsValidationServiceTests
    {
        [TestCase("pas", ExpectedResult = true)]
        [TestCase("pass", ExpectedResult = false)]
        public bool Should_Return_ExpectedResult(string password)
        {
            var minimumRepeatCharsValidationService = new MinimumRepeatCharsValidationService();
            return minimumRepeatCharsValidationService.IsValid(password);
        }
    }
}
