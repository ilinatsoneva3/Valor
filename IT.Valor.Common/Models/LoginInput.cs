using System;

namespace IT.Valor.Common.Models
{
    public class LoginInput
    {
        public string UserId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}
