using FPY.CoreBussines;

namespace FPY.UseCase
{
    public interface IGetHydrResultsWeeklyFpyUseCase
    {
        Task<List<WeeklyFpy>> ExecuteAsync();
    }
}