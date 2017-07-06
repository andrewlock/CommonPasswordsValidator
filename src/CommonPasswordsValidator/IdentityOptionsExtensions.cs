namespace Microsoft.AspNetCore.Builder
{
    public static class IdentityOptionsExtensions
    {
        public static IdentityOptions UseLengthOnlyOptions(this IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 10;
            options.Password.RequiredUniqueChars = 6;
            
            return options;
        }
    }
}
