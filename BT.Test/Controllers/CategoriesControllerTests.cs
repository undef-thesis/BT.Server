using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BT.Api;
using BT.Api.Controllers;
using BT.Application.Features.CategoryFeatures.Commands.AddCategory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BT.Test.Controllers
{
    public class CategoriesControllerTests
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public CategoriesControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetCategories_TryToGetCategories_ThenShouldReturnListWithCategories()
        {
            var response = await _client.GetAsync("/api/v1/categories");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Create_TryCreateNewCategory_ShouldAddNewCategoryToDatabase()
        {
            var command = new AddCategoryCommand
            {
                Name = "TestCategory"
            };

            var payload = GetPayload(command);

            var response = await _client.PostAsync("/api/v1/categories", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}