using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BT.Api;
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
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

[Fact]
public async Task Register_TryToCreateNewAccount_ThenUserShouldBeCreated()
{
    var command = new RegisterCommand
    {
        Email = "kontakt@aleksanderszatko.com",
        Firstname = "w12",
        Lastname = "wemif",
        Password = "ala_ma_kotaW12",
        ConfirmPassword = "ala_ma_kotaW12"
    };

    var payload = GetPayload(command);

    var response = await _client.PostAsync("/api/v1/identity/register", payload);
    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
}

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}