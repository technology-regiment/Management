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
    public class DailyController : BaseApiController
    {
        private readonly IDailyLogic _dailyLogic;
        private readonly IDailyTodayWorkLogic _dailyTodayWorkLogic;
        private readonly IDailyTomorrowWorkLogic _dailyTomorrowWorkLogic;
        private readonly IDailyExistProblemLogic _dailyExistProblemLogic;

        public DailyController(IDailyLogic dailyLogic, IDailyTodayWorkLogic dailyTodayWorkLogic,
            IDailyTomorrowWorkLogic dailyTomorrowWorkLogic, IDailyExistProblemLogic dailyExistProblemLogic)
        {
            _dailyLogic = dailyLogic;
            _dailyTodayWorkLogic = dailyTodayWorkLogic;
            _dailyTomorrowWorkLogic = dailyTomorrowWorkLogic;
            _dailyExistProblemLogic = dailyExistProblemLogic;
        }

        [Route("api/dailys")]
        [HttpPost]
        public void Post([FromBody]CreateDailyUICommand command)
        {
            Execute(() =>
            {
                _dailyLogic.Create(command);
            });
        }

        [Route("api/todayWorks")]
        [HttpPost]
        public void CreateTodayWork([FromBody] CreateTodayWorkUICommand command)
        {
            Execute(() =>
            {
                _dailyLogic.CreateTodayWork(command);
            });
        }

        [Route("api/testerTodayWorks")]
        [HttpPost]
        public void CreateTesterTodayWork([FromBody] CreateTodayWorkUICommand command)
        {
            Execute(() =>
            {
                _dailyLogic.CreateTesterTodayWork(command);
            });
        }

        [Route("api/dailys/{id}")]
        [HttpGet]
        public DailyViewModel Get(Guid id)
        {
            return Execute(() => _dailyLogic.Get(id));
        }

        [Route("api/dailies/dailyExistProblem/{dailyDate}")]
        [HttpGet]
        public IList<DailyExistProblemViewModel> GetDailyExistProblemByDailyDate(DateTime dailyDate)
        {
            return Execute(() => _dailyLogic.GetDailyExistProblemByDailyDate(dailyDate));
        }

        [Route("api/dailies/dailytodayworkdetail/{id}")]
        [HttpDelete]
        public void DeleteDailyTodayWork(Guid id)
        {
            Execute(() =>
            {
                _dailyTodayWorkLogic.Delete(id);
            });
        }

        [Route("api/dailies/dailytomorrowworkdetail/{id}")]
        [HttpDelete]
        public void DeleteDailyTomorrowWork(Guid id)
        {
            Execute(() =>
            {
                _dailyTomorrowWorkLogic.Delete(id);
            });
        }

        [Route("api/dailies/dailyexistproblemdetail/{id}")]
        [HttpDelete]
        public void DeleteDailyExistProblem(Guid id)
        {
            Execute(() =>
            {
                _dailyExistProblemLogic.Delete(id);
            });
        }

        [Route("api/dailyandweeklyandmonthlyreports/currentloginuserdailyandweeklyandmonthlyreports")]
        [HttpGet]
        public CurrentLoginUserDailyAndWeeklyAndMonthlyReportsViewModel GetCurrentLoginUserDailyAndWeeklyAndMonthlyReports()
        {
            return Execute(() =>
                _dailyLogic.GetCurrentLoginUserDailyAndWeeklyAndMonthlyReports()
            );
        }

        [Route("api/dailies/dailystatistics/{dailyDate}")]
        [HttpGet]
        public IList<DailyStatisticsViewModel> GetDailyStatisticsByDailyDate(DateTime dailyDate)
        {
            return Execute(() => _dailyLogic.GetDailyStatisticsByDailyDate(dailyDate));
        }
    }
}