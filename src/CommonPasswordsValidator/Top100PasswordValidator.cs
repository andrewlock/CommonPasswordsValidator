using System;
using System.Collections.Generic;
using CommonPasswordsValidator.Internal;
using Microsoft.Extensions.Options;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 100 most common passwords
    /// </summary>
    public class Top100PasswordValidator<TUser>
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public Top100PasswordValidator(PasswordLists passwords, IOptions<CommonPasswordValidatorOptions> options)
            :base(passwords.Top100Passwords.Value, options)
        { }
    }
}
