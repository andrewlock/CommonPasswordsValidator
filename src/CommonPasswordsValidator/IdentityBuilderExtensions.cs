using System;
using CommonPasswordsValidator;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityBuilderExtensions
    {        
        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 100 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop100PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top100PasswordValidator<TUser>>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 500 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop500PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top500PasswordValidator<TUser>>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 1,000 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop1000PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top1000PasswordValidator<TUser>>();
        }
        
        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 10,000 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop10000PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top10000PasswordValidator<TUser>>();
        }
        
        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 100,000 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop100000PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top100000PasswordValidator<TUser>>();
        }
    }
}
