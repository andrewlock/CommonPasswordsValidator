using System;
using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 1,000 most common passwords
    /// </summary>
    public class Top1000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        ///<inheritdoc />
        protected override HashSet<string> Passwords {get;} = PasswordLists.Top1000Passwords.Value;
    }
}
