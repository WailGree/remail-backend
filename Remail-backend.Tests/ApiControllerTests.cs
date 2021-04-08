using System.Collections.Generic;
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
        public async Task Get_Authentication_Should_Return_Ok()
        {
            // Arrange
            string url = "api/login";
            var keyValuePairs = new List<KeyValuePair<string, string>>();
            // Dummy Gmail account credentials
            keyValuePairs.Add(new KeyValuePair<string, string>("username", "tom1.wales2@gmail.com"));
            keyValuePairs.Add(new KeyValuePair<string, string>("password", "Almafa1234"));
            var req = new HttpRequestMessage(HttpMethod.Post, url) {Content = new FormUrlEncodedContent(keyValuePairs)};

            // Act
            var response = await _client.SendAsync(req);

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task Post_Should_Get_Emails()
        {
            // Arrange
            var stringContent = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8,
                "application/x-www-form-urlencoded");

            // Act
            var response = await _client.PostAsync("api/get-mails", stringContent);

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }


        [Test]
        public async Task Post_Should_LogOut_ReturnOK()
        {
            // Arrange
            var stringContent = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8,
                "application/x-www-form-urlencoded");

            // Act
            var response = await _client.PostAsync("api/log-out", stringContent);

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task Send_Mail_Should_Return_Ok()
        {
            // Arrange
            string url = "api/send-email";
            var keyValuePairs = new List<KeyValuePair<string, string>>();
            // Dummy Gmail account credentials
            keyValuePairs.Add(new KeyValuePair<string, string>("body", "This is a test"));
            keyValuePairs.Add(new KeyValuePair<string, string>("subject", "Test"));
            keyValuePairs.Add(new KeyValuePair<string, string>("to", "tom1.wales2@gmail.com"));
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(keyValuePairs) };

            // Act
            var response = await _client.SendAsync(req);

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
    }
}