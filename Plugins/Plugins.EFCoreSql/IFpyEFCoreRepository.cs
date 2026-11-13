
using FPY.CoreBussines;

namespace Plugins.EFCoreSql
{
    public interface IFpyEFCoreRepository
    {
        Task<List<MonthlyFpy>> GetHydrBVResultsMonthlyFpyAsync();

        Task<List<WeeklyFpy>> GetHydrBVResultsWeeklyFpyAsync();
        Task<List<MonthlyFpy>> GetHydrResultsMonthlyFpyAsync();
        Task<List<WeeklyFpy>> GetHydrResultsWeeklyFpyAsync();
        Task<List<MonthlyFpy>> GetPneuResultsMonthlyFpyAsync();
        Task<List<WeeklyFpy>> GetPneuResultsWeeklyFpyAsync();
    }
}
