using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BankSystem.Api.Tests.Controllers
{
    public class TransactionControllerTest:
        IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public TransactionControllerTest(CustomWebApplicationFactory<Startup> factory)
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
            var users = await _client.GetAsync("/Transaction");
            var data = JsonConvert.DeserializeObject<List<Transaction>>
            (
                (await users.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, users.StatusCode);

            var expectedFirstTransaction = new TransactionDTO() 
            {
                Value = 1000,
                TransactionType = TransactionType.Withdraw,
                Description = "Test Description Withdraw",
                AccountId = 1
            };
            
            var firstData = data.FirstOrDefault();
            Assert.Equal(expectedFirstTransaction.Value, firstData.Value);
            Assert.Equal(expectedFirstTransaction.TransactionType, firstData.TransactionType);
            Assert.Equal(expectedFirstTransaction.Description, firstData.Description);
            Assert.Equal(expectedFirstTransaction.AccountId, firstData.AccountId);
        }

        [Fact]
        public async Task Get_TransactionById()
        {
            var transactionId = 1;
            var transaction = await _client.GetAsync(String.Format("/Transaction/{0}", transactionId));
            var data = JsonConvert.DeserializeObject<TransactionDTO>
            (
                (await transaction.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.OK, transaction.StatusCode);

            var expectedTransaction = new TransactionDTO() 
            {
                Value = 1000,
                TransactionType = TransactionType.Withdraw,
                Description = "Test Description Withdraw",
                AccountId = 1
            };
            
            Assert.Equal(expectedTransaction.Value, data.Value);
            Assert.Equal(expectedTransaction.TransactionType, data.TransactionType);
            Assert.Equal(expectedTransaction.Description, data.Description);
            Assert.Equal(expectedTransaction.AccountId, data.AccountId);

        }

        [Fact]
        public async Task Get_TransactionByIdShouldReturnNotFoundWhenIdDoestNotExist()
        {
            var transactionId = 50;
            var transaction = await _client.GetAsync(String.Format("/Transaction/{0}", transactionId));
            var data = JsonConvert.DeserializeObject<TransactionDTO>
            (
                (await transaction.Content.ReadAsStringAsync())
            );

            Assert.Equal(HttpStatusCode.NotFound, transaction.StatusCode);
        }

        [Fact]
        public async Task Post_Transaction()
        {
            var transactionDTOJson = JsonConvert.SerializeObject(new TransactionDTO()
            {
                Value = 1000,
                TransactionType = TransactionType.Withdraw,
                Description = "Test Description Withdraw",
                AccountId = 1
            });

            var response = await _client
                .PostAsync
                (
                    "/Transaction",
                    new StringContent(transactionDTOJson, Encoding.UTF8, "application/json")
                );


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal
            (
                "Transaction created with success!", 
                await response.Content.ReadAsStringAsync()
            );
        }

        [Fact]
        public async Task Post_TransactionDeposit()
        {
            var transactionDTOJson = JsonConvert.SerializeObject(new TransactionDTO()
            {
                Value = 1000,
                Description = "Test Description Deposit",
                AccountId = 1
            });

            var response = await _client
                .PostAsync
                (
                    "/Transaction/Deposit",
                    new StringContent(transactionDTOJson, Encoding.UTF8, "application/json")
                );


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal
            (
                "Transaction Deposit was a success!", 
                await response.Content.ReadAsStringAsync()
            );
        }

        [Fact]
        public async Task Post_TransactionWithdraw()
        {
            var transactionDTOJson = JsonConvert.SerializeObject(new TransactionDTO()
            {
                Value = 500,
                Description = "Test Description Withdraw",
                AccountId = 1
            });

            var response = await _client
                .PostAsync
                (
                    "/Transaction/Withdraw",
                    new StringContent(transactionDTOJson, Encoding.UTF8, "application/json")
                );

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal
            (
                "Transaction Withdraw was a success!", 
                await response.Content.ReadAsStringAsync()
            );
        }

        [Fact]
        public async Task Post_TransactionPayment()
        {
            var transactionDTOJson = JsonConvert.SerializeObject(new TransactionDTO()
            {
                Value = 100,
                Description = "Test Description Payment",
                AccountId = 1
            });

            var response = await _client
                .PostAsync
                (
                    "/Transaction/Payment",
                    new StringContent(transactionDTOJson, Encoding.UTF8, "application/json")
                );


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal
            (
                "Transaction Payment was a success!", 
                await response.Content.ReadAsStringAsync()
            );
        }

        [Fact]
        public async Task Post_TransactionPaymentShouldReturnBadRequestWhenAccountDoesNotHaveBalance()
        {
            var transactionDTOJson = JsonConvert.SerializeObject(new TransactionDTO()
            {
                Value = 10000,
                Description = "Test Description Payment",
                AccountId = 1
            });

            var response = await _client
                .PostAsync
                (
                    "/Transaction/Payment",
                    new StringContent(transactionDTOJson, Encoding.UTF8, "application/json")
                );


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal
            (
                "Sorry, but you don't have enough money in your account!", 
                await response.Content.ReadAsStringAsync()
            );
        }

        [Fact]
        public async Task Post_TransactionWithdrawShouldReturnBadRequestWhenAccountDoesNotHaveBalance()
        {
            var transactionDTOJson = JsonConvert.SerializeObject(new TransactionDTO()
            {
                Value = 10000,
                Description = "Test Description Withdraw",
                AccountId = 1
            });

            var response = await _client
                .PostAsync
                (
                    "/Transaction/Withdraw",
                    new StringContent(transactionDTOJson, Encoding.UTF8, "application/json")
                );


            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal
            (
                "Sorry, but you don't have enough money in your account!", 
                await response.Content.ReadAsStringAsync()
            );
        }
    }
}