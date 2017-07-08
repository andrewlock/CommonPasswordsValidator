using System.Collections.Generic;
using CommonPasswordsValidator.Internal;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Validates that the supplied password is not one of the 10,000 most common passwords
    /// </summary>
    public class Top10000PasswordValidator<TUser> 
        : CommonPasswordValidator<TUser> where TUser : class
    {
        ///<inheritdoc />
        protected override HashSet<string> Passwords {get;} = PasswordLists.Top10000Passwords.Value;
    }
}
