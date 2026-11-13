using FPY.CoreBussines;

namespace FPY.UseCase.Interfaces
{
    public interface IGetPneuResultsMonthlyFpyUseCase
    {
        Task<List<MonthlyFpy>> ExecuteAsync();
    }
}