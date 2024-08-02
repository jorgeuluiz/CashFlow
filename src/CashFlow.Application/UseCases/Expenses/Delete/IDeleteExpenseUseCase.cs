using CashFlow.Communication.Reponses;

namespace CashFlow.Application.UseCases.Expenses.Delete;
public interface IDeleteExpenseUseCase
{
    Task Execute(long id);
}
