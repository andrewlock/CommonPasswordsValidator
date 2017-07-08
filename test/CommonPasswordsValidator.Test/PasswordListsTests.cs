using System;
using CommonPasswordsValidator.Internal;
using Xunit;

namespace CommonPasswordsValidator.Tests
{
    public class PasswordListsTests
    {
        [Fact]
        public void CanLoadTop100Passwords()
        {
            var passwords = PasswordLists.Top100Passwords.Value;
            Assert.Equal(100, passwords.Count);
        }

        [Fact]
        public void CanLoadTop500Passwords()
        {
            //Case insensitive, hence not 500
            var passwords = PasswordLists.Top500Passwords.Value;
            Assert.Equal(499, passwords.Count);
        }

        [Fact]
        public void CanLoadTop1_000Passwords()
        {
            //Case insensitive, hence not 500
            var passwords = PasswordLists.Top1000Passwords.Value;
            Assert.Equal(998, passwords.Count);
        }

        [Fact]
        public void CanLoadTop10_000Passwords()
        {
            //Case insensitive, hence not 100, 000
            var passwords = PasswordLists.Top10000Passwords.Value;
            Assert.Equal(9_913, passwords.Count);
        }

        [Fact]
        public void CanLoadTop100_000Passwords()
        {
            //Case insensitive, hence not 100, 000
            var passwords = PasswordLists.Top100000Passwords.Value;
            Assert.Equal(96_518, passwords.Count);
        }
    }
}
