using CashFlow.Communication.Reponses;

namespace CashFlow.Application.UseCases.Users.Profile;

public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
