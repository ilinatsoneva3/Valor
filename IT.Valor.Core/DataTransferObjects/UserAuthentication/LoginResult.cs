using System;

namespace IT.Valor.Core.DataTransferObjects.UserAuthentication
{
    public class LoginResult
    {
        public string UserId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}
