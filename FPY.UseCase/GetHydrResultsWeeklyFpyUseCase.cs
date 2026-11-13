using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPY.CoreBussines;
using Plugins.EFCoreSql;
using Plugins.EFCoreSql;

namespace FPY.UseCase
{
    public class GetHydrResultsWeeklyFpyUseCase : IGetHydrResultsWeeklyFpyUseCase
    {
        private readonly IFpyEFCoreRepository fpyEFCoreRepository;
        public GetHydrResultsWeeklyFpyUseCase(IFpyEFCoreRepository fpyEFCoreRepository)
        {
            this.fpyEFCoreRepository = fpyEFCoreRepository;
        }

        public Task<List<WeeklyFpy>> ExecuteAsync()
        {
            return fpyEFCoreRepository.GetHydrResultsWeeklyFpyAsync();
        }


    }
}
