using System;
using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 500 most common passwords
    /// </summary>
    public class Top500PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public Top500PasswordValidator(PasswordLists passwords)
            :base(passwords.Top500Passwords.Value)
        { }
    }
}
