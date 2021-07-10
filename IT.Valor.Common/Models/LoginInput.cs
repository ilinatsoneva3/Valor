using System;

namespace IT.Valor.Core.DataTransferObjects.UserAuthentication
{
    public class LoginInput
    {
        public string UserId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}
