using System;
using CommonPasswordsValidator;
using CommonPasswordsValidator.Internal;
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
            AddPasswordLists(builder);
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
            AddPasswordLists(builder);
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
            AddPasswordLists(builder);
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
            AddPasswordLists(builder);
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
            AddPasswordLists(builder);
            return builder.AddPasswordValidator<Top100000PasswordValidator<TUser>>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 100 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <param name="errorMessage">The error message to display when validation fails</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop100PasswordValidator<TUser>(this IdentityBuilder builder, string errorMessage) where TUser : class
        {
            ConfigureOptions(builder, errorMessage);
            return builder.AddTop100PasswordValidator<TUser>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 500 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <param name="errorMessage">The error message to display when validation fails</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop500PasswordValidator<TUser>(this IdentityBuilder builder, string errorMessage) where TUser : class
        {
            ConfigureOptions(builder, errorMessage);
            return builder.AddTop500PasswordValidator<TUser>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 1,000 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <param name="errorMessage">The error message to display when validation fails</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop1000PasswordValidator<TUser>(this IdentityBuilder builder, string errorMessage) where TUser : class
        {
            ConfigureOptions(builder, errorMessage);
            return builder.AddTop1000PasswordValidator<TUser>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 10,000 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <param name="errorMessage">The error message to display when validation fails</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop10000PasswordValidator<TUser>(this IdentityBuilder builder, string errorMessage) where TUser : class
        {
            ConfigureOptions(builder, errorMessage);
            return builder.AddTop10000PasswordValidator<TUser>();
        }

        /// <summary>
        /// Adds a password validator that checks the password is not one of the top 100,000 most common passwords
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Identity.IdentityBuilder instance this method extends</param>
        /// <param name="errorMessage">The error message to display when validation fails</param>
        /// <typeparam name="TUser">The user type whose password will be validated.</typeparam>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityBuilder instance.</returns>
        public static IdentityBuilder AddTop100000PasswordValidator<TUser>(this IdentityBuilder builder, string errorMessage) where TUser : class
        {
            ConfigureOptions(builder, errorMessage);
            return builder.AddTop100000PasswordValidator<TUser>();
        }

        private static void ConfigureOptions(IdentityBuilder builder, string errorMessage)
        {
            builder.Services.Configure<CommonPasswordValidatorOptions>(x => x.ErrorMessage = errorMessage);
        }

        private static void AddPasswordLists(IdentityBuilder builder)
        {
            builder.Services.AddSingleton<PasswordLists>();
        }
    }
}