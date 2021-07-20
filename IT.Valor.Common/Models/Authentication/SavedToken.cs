using System.Collections.Generic;
using System.Security.Claims;

namespace IT.Valor.Common.Models.Authentication
{
    public class SavedToken
    {
        public IEnumerable<Claim> Claims { get; set; }

        public LoginInput LoginResult { get; set; } = new LoginInput();
    }
}
