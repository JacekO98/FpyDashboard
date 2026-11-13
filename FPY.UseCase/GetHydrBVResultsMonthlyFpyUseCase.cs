using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPY.CoreBussines;
using FPY.UseCase.Interfaces;
using Plugins.EFCoreSql;

namespace FPY.UseCase
{
    public class GetHydrBVResultsMonthlyFpyUseCase : IGetHydrBVResultsMonthlyFpyUseCase
    {
        private readonly IFpyEFCoreRepository fpyEFCoreRepository;
        public GetHydrBVResultsMonthlyFpyUseCase(IFpyEFCoreRepository _fpyEFCoreRepository)
        {
            this.fpyEFCoreRepository = _fpyEFCoreRepository;
        }

        public Task<List<MonthlyFpy>> ExecuteAsync()
        {
            return fpyEFCoreRepository.GetHydrBVResultsMonthlyFpyAsync();
        }
    }
}
