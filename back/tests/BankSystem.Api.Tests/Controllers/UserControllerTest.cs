using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BankSystem.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BankSystem.Api.Tests.Controllers
{
    public class UserControllerTest :
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UserControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Get_AllUsers()
        {
            var users = await _client.GetAsync("/User");
            var data = JsonConvert.DeserializeObject<List<UserDTO>>
            (
                (await users.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, users.StatusCode);

            var expected = "Gabriela";
            Assert.Equal(expected, data.FirstOrDefault().Name);
        }

        [Fact]
        public async Task Get_UserById()
        {
            var userId = 1;
            var user = await _client.GetAsync(String.Format("/User/{0}", userId));
            var data = JsonConvert.DeserializeObject<UserDTO>
            (
                (await user.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, user.StatusCode);

            var expected = "Gabriela";
            Assert.Equal(expected, data.Name);
        }

        [Fact]
        public async Task Get_UserByIdShouldReturnNotFoundWhenIdDoestNotExist()
        {
            var userId = 5;
            var user = await _client.GetAsync(String.Format("/User/{0}", userId));
            var data = JsonConvert.DeserializeObject<UserDTO>
            (
                (await user.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.NotFound, user.StatusCode);
        }
    }
}