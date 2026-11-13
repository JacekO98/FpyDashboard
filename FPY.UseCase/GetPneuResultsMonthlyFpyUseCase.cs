using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPY.CoreBussines;
using Plugins.EFCoreSql;
using FPY.UseCase.Interfaces;
using Plugins.EFCoreSql;

namespace FPY.UseCase
{
    public class GetPneuResultsMonthlyFpyUseCase : IGetPneuResultsMonthlyFpyUseCase
    {
        private readonly IFpyEFCoreRepository fpyEFCoreRepository;
        public GetPneuResultsMonthlyFpyUseCase(IFpyEFCoreRepository fpyEFCoreRepository)
        {
            this.fpyEFCoreRepository = fpyEFCoreRepository;
        }

        public Task<List<MonthlyFpy>> ExecuteAsync()
        {
            return fpyEFCoreRepository.GetPneuResultsMonthlyFpyAsync();
        }


    }
}
