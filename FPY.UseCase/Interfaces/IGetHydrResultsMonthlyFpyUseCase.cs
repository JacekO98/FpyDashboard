using FPY.CoreBussines;

namespace FPY.UseCase
{
    public interface IGetHydrResultsMonthlyFpyUseCase
    {
        Task<List<MonthlyFpy>> ExecuteAsync();
    }
}