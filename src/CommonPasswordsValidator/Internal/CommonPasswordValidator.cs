using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CommonPasswordsValidator
{
    public abstract class CommonPasswordValidator<TUser> : IPasswordValidator<TUser>
           where TUser : class
    {
        public abstract HashSet<string> Passwords { get; }

        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                  TUser user,
                                                  string password)
        {
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
