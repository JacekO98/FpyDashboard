using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPY.CoreBussines;
using Plugins.EFCoreSql;
using FPY.UseCase.Interfaces;

namespace FPY.UseCase
{
    public class GetHydrBVResultsWeeklyFpyUseCase : IGetHydrBVResultsWeeklyFpyUseCase
    {
        private readonly IFpyEFCoreRepository fpyEFCoreRepository;
        public GetHydrBVResultsWeeklyFpyUseCase(IFpyEFCoreRepository _fPYEFCoreRepository)
        {
            this.fpyEFCoreRepository = _fPYEFCoreRepository;
        }
        public Task<List<WeeklyFpy>> ExecuteAsync()
        {
            return fpyEFCoreRepository.GetHydrBVResultsWeeklyFpyAsync();
        }
    }
}
