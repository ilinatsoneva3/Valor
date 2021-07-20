namespace IT.Valor.Common.Models.Authentication
{
    public class UserAuthenticatedArgs
    {
        public UserAuthenticatedArgs(string id)
        {
            UserId = id;
        }

        public string UserId { get; }
    }
}
