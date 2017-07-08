using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CommonPasswordsValidator.Internal
{
    internal static class PasswordLists
    {
        private const string Prefix = nameof(CommonPasswordsValidator) + ".PasswordLists.";

        public static readonly Lazy<HashSet<string>> Top100Passwords = 
            new Lazy<HashSet<string>>(()=> LoadPasswordList("10_million_password_list_top_100.txt"));

        public static readonly Lazy<HashSet<string>> Top500Passwords = 
            new Lazy<HashSet<string>>(()=> LoadPasswordList("10_million_password_list_top_500.txt"));

        public static readonly Lazy<HashSet<string>> Top1000Passwords = 
            new Lazy<HashSet<string>>(()=> LoadPasswordList("10_million_password_list_top_1000.txt"));

        public static readonly Lazy<HashSet<string>> Top10000Passwords = 
            new Lazy<HashSet<string>>(()=> LoadPasswordList("10_million_password_list_top_10000.txt"));

        public static readonly Lazy<HashSet<string>> Top100000Passwords = 
            new Lazy<HashSet<string>>(()=> LoadPasswordList("10_million_password_list_top_100000.txt"));
        
        private static HashSet<string> LoadPasswordList(string listName)
        {
            HashSet<string> hashset;

            var assembly = typeof(PasswordLists).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(Prefix + listName))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    hashset = new HashSet<string>(
                        GetLines(streamReader),
                        StringComparer.OrdinalIgnoreCase);
                }
            }
            return hashset;
        }

        private static IEnumerable<string> GetLines(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                yield return reader.ReadLine();
            }
        }
    }
}