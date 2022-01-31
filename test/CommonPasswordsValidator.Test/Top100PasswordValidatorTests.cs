using System;
using System.Threading.Tasks;
using CommonPasswordsValidator.Internal;
using Microsoft.AspNetCore.Identity.Test;
using Microsoft.Extensions.Options;
using Xunit;

namespace CommonPasswordsValidator.Test
{
    public class Top100PasswordValidatorTests
    {
        const string _error = "The password you chose is too common.";
        
        [Fact]
        public async Task ValidateThrowsWithNullTest()
        {
            // Setup
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var validator = new Top100PasswordValidator<TestUser>(passwordLists, new OptionsStub());

            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>("password", () => validator.ValidateAsync(null, null, null));
            await Assert.ThrowsAsync<ArgumentNullException>("manager", () => validator.ValidateAsync(null, null, "foo"));
        }

        [Theory]
        [InlineData("qwerty")]
        [InlineData("football")]
        [InlineData("987654321")]
        public async Task FailsIfCommon100(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top100PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsFailure(await valid.ValidateAsync(manager, null, input), _error);
        }
        
        [Theory]
        [InlineData("redwings")]
        [InlineData("pakistan")]
        [InlineData("blink182")]
        public async Task SuccessIfNotCommon100(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top100PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsSuccess(await valid.ValidateAsync(manager, null, input));
        }

        [Theory]
        [InlineData("redwings")]
        [InlineData("pakistan")]
        [InlineData("blink182")]
        public async Task FailsIfCommon500(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top500PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsFailure(await valid.ValidateAsync(manager, null, input), _error);
        }
        
        [Theory]
        [InlineData("freepass")]
        [InlineData("polina")]
        [InlineData("zxc123")]
        public async Task SuccessIfLessCommonThan500(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top500PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsSuccess(await valid.ValidateAsync(manager, null, input));
        }

        [Theory]
        [InlineData("freepass")]
        [InlineData("polina")]
        [InlineData("zxc123")]
        public async Task FailsIfCommon1000(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top1000PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsFailure(await valid.ValidateAsync(manager, null, input), _error);
        }
        
        [Theory]
        [InlineData("brady")]
        [InlineData("brook")]
        [InlineData("bubbles1")]
        public async Task SuccessIfLessCommonThan1000(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top1000PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsSuccess(await valid.ValidateAsync(manager, null, input));
        }

        [Theory]
        [InlineData("brady")]
        [InlineData("brook")]
        [InlineData("bubbles1")]
        public async Task FailsIfCommon10000(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top10000PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsFailure(await valid.ValidateAsync(manager, null, input), _error);
        }
        
        [Theory]
        [InlineData("070162")]
        [InlineData("070175")]
        [InlineData("09080908")]
        public async Task SuccessIfLessCommonThan10000(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top10000PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsSuccess(await valid.ValidateAsync(manager, null, input));
        }

        [Theory]
        [InlineData("070162")]
        [InlineData("070175")]
        [InlineData("09080908")]
        public async Task FailsIfCommon100000(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top100000PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsFailure(await valid.ValidateAsync(manager, null, input), _error);
        }
        
        [Theory]
        [InlineData("$2fy%gD1")]
        [InlineData("gDVa5£g")]
        [InlineData("fSHR^£g")]
        public async Task SuccessIfLessCommonThan100000(string input)
        {
            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object, 
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var valid = new Top100000PasswordValidator<TestUser>(passwordLists, new OptionsStub());
            
            IdentityResultAssert.IsSuccess(await valid.ValidateAsync(manager, null, input));
        }

        [Fact]
        public async Task CanReplaceErrorMessage()
        {
            var error = "Oops, no good!";
            var options = new OptionsStub();
            options.Value.ErrorMessage = error;
            var input = "qwerty";

            var passwordLists = new PasswordLists(
                MockHelpers.MockOptions().Object,
                MockHelpers.MockILogger<PasswordLists>().Object);
            var manager = MockHelpers.TestUserManager<TestUser>();
            var validator = new Top100PasswordValidator<TestUser>(passwordLists, options);

            var result = await validator.ValidateAsync(manager, null, input);
            IdentityResultAssert.IsFailure(result, error);

        }

        class OptionsStub : IOptions<CommonPasswordValidatorOptions>
        {
            public CommonPasswordValidatorOptions Value { get; } = new();
        }
    }
}