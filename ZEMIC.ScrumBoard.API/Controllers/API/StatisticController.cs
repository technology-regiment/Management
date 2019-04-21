using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class StatisticController : BaseApiController
    {
        private readonly IStatisticLogic _statisticLogic;

        public StatisticController(IStatisticLogic statisticLogic)
        {
            _statisticLogic = statisticLogic;
        }

        [Route("api/statistic/dailies/")]
        [HttpGet]
        public IEnumerable<DailyStatisticViewModel> GetAllUserDaily()
        {
            return Execute(() => _statisticLogic.GetAllUserDaily());
        }

        [Route("api/statistic/weeklies/")]
        [HttpGet]
        public IEnumerable<WeeklyStatisticViewModel> GetAllUserWeekly()
        {
            return Execute(() => _statisticLogic.GetAllUserWeekly());
        }

        [Route("api/statistic/monthlies/")]
        [HttpGet]
        public IEnumerable<MonthlyStatisticViewModel> GetAllUserMonthly()
        {
            return Execute(() => _statisticLogic.GetAllUserMonthly());
        }
    }
}
