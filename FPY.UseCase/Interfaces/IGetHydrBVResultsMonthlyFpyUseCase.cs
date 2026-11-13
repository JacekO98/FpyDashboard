using FPY.CoreBussines;

namespace FPY.UseCase.Interfaces
{
    public interface IGetHydrBVResultsMonthlyFpyUseCase
    {
        Task<List<MonthlyFpy>> ExecuteAsync();
    }
}