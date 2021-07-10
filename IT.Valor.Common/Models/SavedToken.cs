using System.Collections.Generic;
using System.Security.Claims;
using IT.Valor.Core.DataTransferObjects.UserAuthentication;

namespace IT.Valor.Core.Settings
{
    public class SavedToken
    {
        public IEnumerable<Claim> Claims { get; set; }

        public LoginResult LoginResult { get; set; } = new LoginResult();
    }
}
