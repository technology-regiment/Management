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
    public class WeeklyController : BaseApiController
    {
        private readonly IWeeklyLogic _weeklyLogic;
        private readonly IWeeklyDetailLogic _weeklyDetailLogic;

        public WeeklyController(IWeeklyLogic weeklyLogic, IWeeklyDetailLogic weeklyDetailLogic)
        {
            _weeklyLogic = weeklyLogic;
            _weeklyDetailLogic = weeklyDetailLogic;
        }

        [Route("api/weeklys")]
        [HttpPost]
        public void Post([FromBody]CreateWeeklyUICommand command)
        {
            Execute(() =>
            {
                _weeklyLogic.Create(command);
            });
        }

        [Route("api/weeklys/weeklybasicdata/{weeklyDate}")]
        [HttpGet]
        public WeeklyViewModel Get(string weeklyDate)
        {
            return Execute(() => _weeklyLogic.Get(weeklyDate));
        }

        [Route("api/weeklys/weeklyworkcontent/{dailyDate}")]
        [HttpGet]
        public IEnumerable<DailyTodayWorkViewModel> GetWeeklyWorkContentByDailyDate(DateTime dailyDate)
        {
            return Execute(() => _weeklyLogic.GetWeeklyWorkContentByDailyDate(dailyDate));
        }

        [Route("api/weeklys/weeklyworkcontent/{id}")]
        [HttpDelete]
        public void DeleteWeeklyWorkContent(Guid id)
        {
            Execute(() =>
            {
                _weeklyDetailLogic.Delete(id);
            });
        }
    }
}