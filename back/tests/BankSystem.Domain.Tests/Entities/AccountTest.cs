using Xunit;

namespace BankSystem.Domain.Tests.Entities
{
    public class AccountTest
    {
        private readonly Account _account = new Account 
        {
            Agency = 1111,
            Number = 99999999,
            Balance = 1500,
            UserId = 1,
        };

        [Fact]
        public void HasBalanceShouldReturnTrueWhenValueIsLessThanBalance() {
            var value = 100;

            Assert.True(_account.hasBalance(value));
        }

        [Fact]
        public void HasBalanceShouldReturnFalseWhenValueIsBiggerThanBalance() {
            var value = 10000;

            Assert.False(_account.hasBalance(value));
        }

        [Fact]
        public void BalanceShouldEncreaseWhenMethodIsCalledWithValue() {
            var value = 1000;
            var expected = 2500;

            _account.EncreaseBalance(value);

            Assert.Equal(expected, _account.Balance);
        }

        [Fact]
        public void BalanceShouldDecreaseWhenMethodIsCalledWithValue() {
            var value = 1000;
            var expected = 500;

            _account.DecreaseBalance(value);

            Assert.Equal(expected, _account.Balance);
        }
    }
}