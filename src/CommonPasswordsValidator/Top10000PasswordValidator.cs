using System.Collections.Generic;
using CommonPasswordsValidator.Internal;
using Microsoft.Extensions.Options;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 10,000 most common passwords
    /// </summary>
    public class Top10000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public Top10000PasswordValidator(PasswordLists passwords, IOptions<CommonPasswordValidatorOptions> options)
            :base(passwords.Top10000Passwords.Value, options)
        { }
    }
}
