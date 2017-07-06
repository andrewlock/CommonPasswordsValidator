using System;
using CommonPasswordsValidator;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityBuilderExtensions
    {
        public static IdentityBuilder AddTop100PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top100PasswordValidator<TUser>>();
        }

        public static IdentityBuilder AddTop500PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top500PasswordValidator<TUser>>();
        }
        
        public static IdentityBuilder AddTop1000PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top1000PasswordValidator<TUser>>();
        }
        
        public static IdentityBuilder AddTop10000PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top10000PasswordValidator<TUser>>();
        }
        
        public static IdentityBuilder AddTop100000PasswordValidator<TUser>(this IdentityBuilder builder) where TUser : class
        {
            return builder.AddPasswordValidator<Top100000PasswordValidator<TUser>>();
        }
    }
}
