using System.Collections.Generic;
using CommonPasswordsValidator.Internal;
using Microsoft.Extensions.Options;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 100,000 most common passwords
    /// </summary>
    public class Top100000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public Top100000PasswordValidator(PasswordLists passwords, IOptions<CommonPasswordValidatorOptions> options)
            :base(passwords.Top100000Passwords.Value, options)
        { }
    }
}
