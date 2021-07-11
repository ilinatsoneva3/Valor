namespace IT.Valor.Common.Models
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
