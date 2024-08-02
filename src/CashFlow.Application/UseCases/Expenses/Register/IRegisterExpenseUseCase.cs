using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
