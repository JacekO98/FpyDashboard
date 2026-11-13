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
    public class GetHydrResultsMonthlyFpyUseCase : IGetHydrResultsMonthlyFpyUseCase
    {
        private readonly IFpyEFCoreRepository fpyEFCoreRepository;
        public GetHydrResultsMonthlyFpyUseCase(IFpyEFCoreRepository fpyEFCoreRepository)
        {
            this.fpyEFCoreRepository = fpyEFCoreRepository;
        }

        public Task<List<MonthlyFpy>> ExecuteAsync()
        {
            return fpyEFCoreRepository.GetHydrResultsMonthlyFpyAsync();
        }


    }
}
