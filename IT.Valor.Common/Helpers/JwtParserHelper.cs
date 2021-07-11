using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace IT.Valor.Common.Helpers
{
    public static class JwtParserHelper
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();

            if (jwt.Length > 0)
            {
                var payload = jwt.Split(".")[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var kvp = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                kvp.TryGetValue(ClaimTypes.Role, out object roles);

                if (roles is not null)
                {
                    if (roles.ToString().Trim().StartsWith("["))
                    {
                        var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                        foreach (var role in parsedRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                    }

                    kvp.Remove(ClaimTypes.Role);
                }

                claims.AddRange(kvp.Select(x => new Claim(x.Key, x.Value.ToString())));
            }

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string payload)
        {
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 4: payload += "="; break;
            }

            return Convert.FromBase64String(payload);
        }
    }
}
