using System;
using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    public class Top100PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public override HashSet<string> Passwords {get;} = PasswordLists.Top100Passwords.Value;
    }
}
