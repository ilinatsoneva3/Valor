namespace IT.Valor.Core.Interfaces
{
    public interface ICustomHttpContext
    {
        bool IsAuthenticated { get; }

        string UserId { get; }
    }
}