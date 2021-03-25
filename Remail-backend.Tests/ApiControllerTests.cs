using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using Xunit;

namespace Remail_backend.Tests
{
    class ApiControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client { get; }

        public ApiControllerTests()
        {
            var fixture = new WebApplicationFactory<Startup>();
            _client = fixture.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Post_Should_Get_Emails()
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var response = await _client.PostAsync("api/get-mails", stringContent);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
    }
}