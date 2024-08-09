using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Security.Token;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
