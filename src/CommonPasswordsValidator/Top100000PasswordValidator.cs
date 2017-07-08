using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 100,000 most common passwords
    /// </summary>
    public class Top100000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        ///<inheritdoc />
        protected override HashSet<string> Passwords {get;} = PasswordLists.Top100000Passwords.Value;
    }
}
