using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Web.Extensions
{
    public class RegexService
    {
        public string GetFirstGroupMatch(Regex regex, string text, bool throwIfNotFound = true)
        {
            return GetNGroupMatch(1, regex, text, throwIfNotFound);
        }

        public string GetNGroupMatch(int n, Regex regex, string text, bool throwIfNotFound = true)
        {
            var match = regex.Match(text);
            var value = match.Groups[n].Value;

            if (string.IsNullOrEmpty(value) && throwIfNotFound)
                throw new Exception($"The match on {text} with regex {regex} was not successfull");

            return value;
        }
    }

    public static class ClaimsPrincipalExtension
    {
        public static string GetSteamId(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var regEx = new Regex(@".*/openid/id/([\d]{13,25})");
            var steamClaim = user.Claims.ToArray()[0].Value;

            return new RegexService().GetFirstGroupMatch(regEx, steamClaim);
        }
    }
}
