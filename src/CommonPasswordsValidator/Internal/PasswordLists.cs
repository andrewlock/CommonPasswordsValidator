using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CommonPasswordsValidator.Internal
{
    public class PasswordLists
    {
        private const string Prefix = nameof(CommonPasswordsValidator) + ".PasswordLists.";

        private readonly int _requiredLength;
        private readonly ILogger<PasswordLists> _logger;

        public PasswordLists(IOptions<IdentityOptions> options, ILoggerFactory loggerFactory)
        {
            _requiredLength = options.Value.Password.RequiredLength;
            _logger = loggerFactory.CreateLogger<PasswordLists>();
            Top100Passwords = new Lazy<HashSet<string>>(() => LoadPasswordList("10_million_password_list_top_100.txt"));
            Top500Passwords = new Lazy<HashSet<string>>(() => LoadPasswordList("10_million_password_list_top_500.txt"));
            Top1000Passwords = new Lazy<HashSet<string>>(() => LoadPasswordList("10_million_password_list_top_1000.txt"));
            Top10000Passwords = new Lazy<HashSet<string>>(() => LoadPasswordList("10_million_password_list_top_10000.txt"));
            Top100000Passwords = new Lazy<HashSet<string>>(() => LoadPasswordList("10_million_password_list_top_100000.txt"));
        }

        public Lazy<HashSet<string>> Top100Passwords { get; }
        public Lazy<HashSet<string>> Top500Passwords { get; }
        public Lazy<HashSet<string>> Top1000Passwords { get; }
        public Lazy<HashSet<string>> Top10000Passwords { get; }
        public Lazy<HashSet<string>> Top100000Passwords { get; }

        private HashSet<string> LoadPasswordList(string listName)
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

            _logger.LogDebug("Loaded {NumberCommonPasswords} common passwords from resource {ResourceName}", hashset.Count, listName);
            return hashset;
        }

        private IEnumerable<string> GetLines(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Length >= _requiredLength)
                {
                    yield return line;
                }
            }
        }
    }
}