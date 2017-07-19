using System;
using CommonPasswordsValidator.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.Test;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace CommonPasswordsValidator.Tests
{
    public class PasswordListsTests
    {
        [Fact]
        public void CanLoadTop100Passwords()
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var passwords = passwordLists.Top100Passwords.Value;
            Assert.Equal(100, passwords.Count);
        }

        [Fact]
        public void CanLoadTop500Passwords()
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            //Case insensitive, hence not 500
            var passwords = passwordLists.Top500Passwords.Value;
            Assert.Equal(499, passwords.Count);
        }

        [Fact]
        public void CanLoadTop1_000Passwords()
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            //Case insensitive, hence not 500
            var passwords = passwordLists.Top1000Passwords.Value;
            Assert.Equal(998, passwords.Count);
        }

        [Fact]
        public void CanLoadTop10_000Passwords()
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            //Case insensitive, hence not 100, 000
            var passwords = passwordLists.Top10000Passwords.Value;
            Assert.Equal(9_913, passwords.Count);
        }

        [Fact]
        public void CanLoadTop100_000Passwords()
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            //Case insensitive, hence not 100, 000
            var passwords = passwordLists.Top100000Passwords.Value;
            Assert.Equal(96_518, passwords.Count);
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(4, 100)]
        [InlineData(5, 93)]
        [InlineData(6, 91)]
        [InlineData(7, 35)]
        [InlineData(10, 2)]
        [InlineData(11, 0)]
        public void DoesNotLoadPasswordsBelowMinimumLength(int requiredLength, int expectedCount)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions(requiredLength).Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var passwords = passwordLists.Top100Passwords.Value;
            Assert.Equal(expectedCount, passwords.Count);
        }

    }
}
