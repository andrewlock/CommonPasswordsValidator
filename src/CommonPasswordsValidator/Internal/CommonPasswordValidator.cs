using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CommonPasswordsValidator
{
    /// <summary>
    /// Provides an abstraction for validating that the supplied password is not in a list of common passwords
    /// </summary>
    public abstract class CommonPasswordValidator<TUser> : IPasswordValidator<TUser>
           where TUser : class
    {
        /// <summary>
        /// The collection of common passwords which should not be allowed
        /// </summary>
        protected abstract HashSet<string> Passwords { get; }

        ///<inheritdoc />
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                  TUser user,
                                                  string password)
        {
            if (password == null) { throw new ArgumentNullException(nameof(password)); }
            if (manager == null) { throw new ArgumentNullException(nameof(manager )); }
            
            var result = Passwords.Contains(password)
            ? IdentityResult.Failed(new IdentityError
            {
                Code = "CommonPassword",
                Description = "The password you chose is too common."
            })
            : IdentityResult.Success;

            return Task.FromResult(result);
        }

    }
}
