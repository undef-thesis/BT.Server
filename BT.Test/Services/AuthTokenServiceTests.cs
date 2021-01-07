using System;
using System.IO;
using BT.Application.Options;
using BT.Application.Services.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace BT.Test.Services
{
    public class AuthTokenServiceTests
    {
        private IOptions<IdentityOptions> _identityOptions;

        public AuthTokenServiceTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            _identityOptions = Options.Create(configuration.GetSection("IdentityOptions").Get<IdentityOptions>());
        }

        [Fact]
        public void GenerateToken_WhenTokenIsCreated_ThenValidationPass()
        {
            var authTokenService = new AuthTokenService(_identityOptions);
            var token = authTokenService.GenerateToken(Guid.NewGuid(), "test@mail.com");

            bool validate = authTokenService.Validate(token.Token);

            Assert.True(validate);
        }

        [Fact]
        public void Validate_WhenPutFakeToken_ThenValidationFailed()
        {
            var authTokenService = new AuthTokenService(_identityOptions);

            bool validate = authTokenService.Validate("fake_token");

            Assert.False(validate);
        }

        [Fact]
        public void GenerateRefreshToken_WhenRefreshTokenIsCreated_ShouldRefreshNewRefreshToken()
        {
            var authTokenService = new AuthTokenService(_identityOptions);
            var refreshToken = authTokenService.GenerateRefreshToken(Guid.NewGuid());

            Assert.True(refreshToken is Object);
        }
    }
}