using System;
using System.Collections.Generic;
using CommonPasswordsValidator.Internal;
using Microsoft.Extensions.Options;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 500 most common passwords
    /// </summary>
    public class Top500PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public Top500PasswordValidator(PasswordLists passwords, IOptions<CommonPasswordValidatorOptions> options)
            :base(passwords.Top500Passwords.Value, options)
        { }
    }
}
