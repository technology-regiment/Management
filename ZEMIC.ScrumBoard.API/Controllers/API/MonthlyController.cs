using System;
using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class MonthlyController : BaseApiController
    {
        private readonly IMonthlyLogic _monthlyLogic;
        private readonly IMonthlyDetailLogic _monthlyDetailLogic;

        public MonthlyController(IMonthlyLogic monthlyLogic, IMonthlyDetailLogic monthlyDetailLogic)
        {
            _monthlyLogic = monthlyLogic;
            _monthlyDetailLogic = monthlyDetailLogic;
        }

        [Route("api/monthlys")]
        [HttpPost]
        public void Post([FromBody]CreateMonthlyUICommand command)
        {
            Execute(() =>
            {
                _monthlyLogic.Create(command);
            });
        }

        [Route("api/monthlys/monthlybasicdata/{weeklyDate}")]
        [HttpGet]
        public MonthlyViewModel Get(string weeklyDate)
        {
            return Execute(() => _monthlyLogic.Get(weeklyDate));
        }

        [Route("api/monthlys/monthlyworkcontent/{dailyDate}")]
        [HttpGet]
        public IEnumerable<WeeklyDetaiViewModel> GetMonthlyWorkContentByDailyDate(string dailyDate)
        {
            return Execute(() => _monthlyLogic.GetMonthlyWorkContentByDailyDate(dailyDate));
        }

        [Route("api/monthlys/monthlyworkcontent/{id}")]
        [HttpDelete]
        public void DeleteMonthlyWorkContent(Guid id)
        {
            Execute(() =>
            {
                _monthlyDetailLogic.Delete(id);
            });
        }
    }
}