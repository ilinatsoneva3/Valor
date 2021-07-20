using System;

namespace IT.Valor.Common.Models.Authentication
{
    public class LoginInput
    {
        public string UserId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}
