using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _writeOnlyrepository;
    private readonly IExpensesReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;

    public DeleteExpenseUseCase(
        IExpensesWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser,
        IExpensesReadOnlyRepository readOnlyRepository)
    {
        _writeOnlyrepository = repository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();

        var expenses = await _readOnlyRepository.GetById(loggedUser, id);

        if (expenses is null)
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        await _writeOnlyrepository.Delete(id);      

        await _unitOfWork.Commit();
    }
}
