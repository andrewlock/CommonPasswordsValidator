namespace Microsoft.AspNetCore.Builder
{
    public static class IdentityOptionsExtensions
    {
        /// <summary>
        /// Remove the character type requirements, and use length restrictions only.
        /// </summary>
        /// <param name="options">The Microsoft.AspNetCore.Identity.IdentityOptions instance this method extends</param>
        /// <param name="requiredLength">The minimum length a password must be</param>
        /// <param name="requiredUniqueChars">The minimum number of unique chars a password must comprised of</param>
        /// <returns>The current Microsoft.AspNetCore.Identity.IdentityOptions instance</returns>
        public static IdentityOptions UseLengthOnlyOptions(
            this IdentityOptions options, 
            int requiredLength = 10, 
            int requiredUniqueChars = 6)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = requiredLength;
            options.Password.RequiredUniqueChars = requiredUniqueChars;
            
            return options;
        }
    }
}
