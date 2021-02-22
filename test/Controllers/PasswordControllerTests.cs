using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using passwordValidation.Controllers;
using passwordValidation.Interfaces.Handlers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace passwordValidationTests.Controllers
{
    [ExcludeFromCodeCoverage]
    internal class PasswordControllerTests
    {
        private Mock<IPasswordValidationHandler> _passwordValidationHandler;
        private PasswordController _passwordController;

        [SetUp]
        public void SetUp()
        {
            _passwordValidationHandler = new Mock<IPasswordValidationHandler>();
            _passwordController = new PasswordController(_passwordValidationHandler.Object);
        }

        [Test]
        public void Should_Return_Ok_And_True_When_Valid_Password()
        {
            _passwordValidationHandler
                .Setup(it => it.Validate(It.IsAny<string>()))
                .Returns(true);

            var response = _passwordController.Validate("password");

            Assert.Multiple(() =>
            {
                var result = (OkObjectResult)response;

                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
                Assert.IsTrue(Convert.ToBoolean(result.Value));
            });
        }

        [Test]
        public void Should_Return_BadRequest_And_False_When_Invalid_Password()
        {
            _passwordValidationHandler
                .Setup(it => it.Validate(It.IsAny<string>()))
                .Returns(false);

            var response = _passwordController.Validate("invalid_password");

            Assert.Multiple(() =>
            {
                var result = (BadRequestObjectResult)response;

                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
                Assert.IsFalse(Convert.ToBoolean(result.Value));
            });
        }
    }
}
