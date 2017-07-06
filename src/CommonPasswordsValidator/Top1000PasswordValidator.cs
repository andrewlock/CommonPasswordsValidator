using System;
using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    public class Top1000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public override HashSet<string> Passwords {get;} = PasswordLists.Top1000Passwords.Value;
    }
}
