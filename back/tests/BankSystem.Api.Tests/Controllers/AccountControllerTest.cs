using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BankSystem.Api.Tests.Controllers
{
    [Collection("Sequential")]
    public class AccountControllerTest :
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AccountControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Get_AllAccounts()
        {
            var transactions = await _client.GetAsync("/Account");
            var data = JsonConvert.DeserializeObject<List<AccountDTO>>
            (
                (await transactions.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, transactions.StatusCode);

            var expectedAccount = new AccountDTO()
            {
                Agency = 1111,
                Number = 99999999,
                Balance = 1500,
                UserId = 1,
            };

            Assert.Equal(expectedAccount.Agency, data.FirstOrDefault().Agency);
            Assert.Equal(expectedAccount.Number, data.FirstOrDefault().Number);
            Assert.Equal(expectedAccount.Balance, data.FirstOrDefault().Balance);
            Assert.Equal(expectedAccount.UserId, data.FirstOrDefault().UserId);
        }

        [Fact]
        public async Task Get_AccountById()
        {
            var accountId = 1;
            var account = await _client.GetAsync(String.Format("/Account/{0}", accountId));
            var data = JsonConvert.DeserializeObject<AccountDTO>
            (
                (await account.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, account.StatusCode);

            var expectedAccount = new AccountDTO()
            {
                Agency = 1111,
                Number = 99999999,
                Balance = 1500,
                UserId = 1,
            };

            Assert.Equal(expectedAccount.Agency, data.Agency);
            Assert.Equal(expectedAccount.Number, data.Number);
            Assert.Equal(expectedAccount.Balance, data.Balance);
            Assert.Equal(expectedAccount.UserId, data.UserId);
        }

        [Fact]
        public async Task Get_AccountByIdShouldReturnNotFoundWhenAccountDoestNotExist()
        {
            var accountId = 5;
            var account = await _client.GetAsync(String.Format("/Account/{0}", accountId));
            var data = JsonConvert.DeserializeObject<AccountDTO>
            (
                (await account.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.NotFound, account.StatusCode);
        }

        [Fact]
        public async Task Get_AccountByUserId()
        {
            var userId = 1;
            var account = await _client.GetAsync(String.Format("/Account/User/{0}", userId));
            var data = JsonConvert.DeserializeObject<AccountDTO>
            (
                (await account.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, account.StatusCode);

            var expectedAccount = new AccountDTO()
            {
                Agency = 1111,
                Number = 99999999,
                Balance = 1500,
                UserId = 1,
            };

            Assert.Equal(expectedAccount.Agency, data.Agency);
            Assert.Equal(expectedAccount.Number, data.Number);
            Assert.Equal(expectedAccount.Balance, data.Balance);
            Assert.Equal(expectedAccount.UserId, data.UserId);
        }
        
        [Fact]
        public async Task Get_AccountByUserIdShouldReturnNotFoundWhenUserDoestNotExist()
        {
            var userId = 5;
            var account = await _client.GetAsync(String.Format("/Account/User/{0}", userId));
            var data = JsonConvert.DeserializeObject<AccountDTO>
            (
                (await account.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.NotFound, account.StatusCode);
        }

        [Fact]
        public async Task Post_Account()
        {
            var accountDTOJson = JsonConvert.SerializeObject(new AccountDTO()
            {
                Agency = 1111,
                Number = 99999999,
                Balance = 1500,
                UserId = 2,
            });

            var response = await _client
                .PostAsync
                (
                    "/Account",
                    new StringContent(accountDTOJson, Encoding.UTF8, "application/json")
                );


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal
            (
                "Account created with success!",
                await response.Content.ReadAsStringAsync()
            );
        }
    }
}