using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    public class Top10000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public override HashSet<string> Passwords {get;} = PasswordLists.Top10000Passwords.Value;
    }
    
    public class Top100000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        public override HashSet<string> Passwords {get;} = PasswordLists.Top100000Passwords.Value;
    }
}
