using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using passwordValidation.Handlers;
using passwordValidation.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace passwordValidationTests.Handlers
{
    [ExcludeFromCodeCoverage]
    internal class PasswordValidationHandlerTests
    {
        private List<IPasswordValidationService> _passwordValidationServices;
        private Mock<IPasswordValidationService> _firstPasswordValidationService;
        private Mock<IPasswordValidationService> _secondPasswordValidationService;
        private Mock<ILogger<PasswordValidationHandler>> _logger;
        private PasswordValidationHandler _passwordValidationHandler;

        [SetUp]
        public void SetUp()
        {
            _firstPasswordValidationService = new Mock<IPasswordValidationService>();
            _secondPasswordValidationService = new Mock<IPasswordValidationService>();

            _passwordValidationServices = new List<IPasswordValidationService>()
            {
                _firstPasswordValidationService.Object,
                _secondPasswordValidationService.Object
            };

            _logger = new Mock<ILogger<PasswordValidationHandler>>();

            _passwordValidationHandler = new PasswordValidationHandler(
                _passwordValidationServices, _logger.Object);
        }

        [Test]
        public void Should_Return_True_When_Password_Valid_In_All_Services()
        {
            _firstPasswordValidationService
                .Setup(it => it.IsValid(It.IsAny<string>()))
                .Returns(true);

            _secondPasswordValidationService
                .Setup(it => it.IsValid(It.IsAny<string>()))
                .Returns(true);

            var isValid = _passwordValidationHandler.Validate("password");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isValid);

                _firstPasswordValidationService
                    .Verify(it => it.IsValid(It.IsAny<string>()), Times.Once);

                _secondPasswordValidationService
                    .Verify(it => it.IsValid(It.IsAny<string>()), Times.Once);
            });
        }

        [Test]
        public void Should_Return_False_And_Stop_Validating_When_Password_Invalid_In_AtLeast_One_Service()
        {
            _firstPasswordValidationService
                .Setup(it => it.IsValid(It.IsAny<string>()))
                .Returns(false);

            _secondPasswordValidationService
                .Setup(it => it.IsValid(It.IsAny<string>()))
                .Returns(true);

            var isValid = _passwordValidationHandler.Validate("password");

            Assert.Multiple(() =>
            {
                Assert.IsFalse(isValid);

                _firstPasswordValidationService
                    .Verify(it => it.IsValid(It.IsAny<string>()), Times.Once);

                _secondPasswordValidationService
                    .Verify(it => it.IsValid(It.IsAny<string>()), Times.Never);
            });
        }

        [Test]
        public void LogException_When_ErrorOccurs()
        {
            _firstPasswordValidationService
                .Setup(it => it.IsValid(It.IsAny<string>()))
                .Throws(new Exception());

            Assert.Multiple(() =>
            {
                Assert.Throws<Exception>(() => _passwordValidationHandler.Validate("password"));

                _logger
                    .Verify(l => l.Log(LogLevel.Error,
                        It.IsAny<EventId>(),
                        It.Is<object>(x => x.ToString().Equals("Erro validando senha")),
                        It.IsAny<Exception>(),
                        It.IsAny<Func<object, Exception, string>>()), Times.Once);
            });
        }
    }
}
