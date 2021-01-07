using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BT.Api;
using BT.Application.Features.AuthFeatures.Commands.Login;
using BT.Application.Features.AuthFeatures.Commands.Register;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace BT.Test.Controllers
{
    public class IdentityControllerTests
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public IdentityControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Register_TryToCreateNewAccount_ThenUserShouldBeCreated()
        {
            var command = new RegisterCommand
            {
                Email = "kontakt@mail.com",
                Firstname = "w12",
                Lastname = "wemif",
                Password = "ala_ma_kotaW12",
                ConfirmPassword = "ala_ma_kotaW12"
            };

            var payload = GetPayload(command);

            var response = await _client.PostAsync("/api/v1/identity/register", payload);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Register_TryToCreateNewAccountWithDiffretPassword_ThenShouldThrowError()
        {
            var command = new RegisterCommand
            {
                Email = "kontakt1@mail.com",
                Firstname = "w13",
                Lastname = "wemif",
                Password = "ala_ma_kotaW12",
                ConfirmPassword = "ala_ma_kotaW13"
            };

            var payload = GetPayload(command);

            var response = await _client.PostAsync("/api/v1/identity/register", payload);
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Fact]
        public async Task Login_TryToLoginToNotExistingAccount_ThenReturnNotFound()
        {
            var command = new LoginCommand
            {
                Email = "kontakt.wemif@mail.com",
                Password = "ZAQ!2wsx"
            };

            var payload = GetPayload(command);

            var response = await _client.PostAsync("/api/v1/identity/login", payload);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}