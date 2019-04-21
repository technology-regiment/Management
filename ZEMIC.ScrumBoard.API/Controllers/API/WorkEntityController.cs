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
    public class WorkEntityController : BaseApiController
    {
        private readonly IWorkEntityLogic _workEntityLogic;

        public WorkEntityController(IWorkEntityLogic workEntityLogic)
        {
            _workEntityLogic = workEntityLogic;
        }

        [Route("api/works/{id}")]
        [HttpGet]
        public WorkInfoViewModel GetWorkInfos(Guid id)
        {
            return Execute(() => _workEntityLogic.GetWorkInfos(id));
        }

        [Route("api/works/block/{id}")]
        [HttpGet]
        public IEnumerable<BlockInfoViewModel> GetBlockInfos(Guid id)
        {
            return Execute(() => _workEntityLogic.GetBlockInfos(id));
        }

        [Route("api/works/history/{id}")]
        [HttpGet]
        public IEnumerable<HistoryInfoViewModel> GetHistoryInfos(Guid id)
        {
            return Execute(() => _workEntityLogic.GetHistoryInfos(id));
        }

        [Route("api/works/testcase/{id}")]
        [HttpGet]
        public IEnumerable<TestCaseInfoViewModel> GetTestCaseInfos(Guid id)
        {
            return Execute(() => _workEntityLogic.GetTestCaseInfos(id));
        }

        [Route("api/works")]
        [HttpPut]
        public void Put([FromBody]UpdateWorkInfoUICommand command)
        {
            Execute(() =>
            {
                _workEntityLogic.Update(command);
            });
        }
        [Route("api/works/comment")]
        [HttpPut]
        public void Put([FromBody]CreateWorkCommentInfoUICommand command)
        {
            Execute(() =>
            {
                _workEntityLogic.CreateComment(command);
            });
        }

        [Route("api/workdescriptions")]
        [HttpPut]
        public void PutDescription([FromBody]UpdateDescriptionUICommand command)
        {
            Execute(() =>
            {
                _workEntityLogic.UpdateDescription(command);
            });
        }

        [Route("api/workconditions")]
        [HttpPut]
        public void PutCondition([FromBody]UpdateConditionUICommand command)
        {
            Execute(() =>
            {
                _workEntityLogic.UpdateCondition(command);
            });
        }

        [Route("api/worktestcasedescriptions")]
        [HttpPut]
        public void PutTestCaseDescription([FromBody]UpdateTestCaseDescriptionUICommand command)
        {
            Execute(() =>
            {
                _workEntityLogic.UpdateTestCaseDescription(command);
            });
        }

        [Route("api/works/delete/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _workEntityLogic.Delete(id);
            });
        }

        [Route("api/works/usertodayworkstoryortask/{dailyDate}")]
        [HttpGet]
        public IEnumerable<DailyReportViewModel> GetDailyTodayWork(DateTime dailyDate)
        {
            return Execute(() => _workEntityLogic.GetDailyTodayWork(dailyDate));
        }

        [Route("api/works/usertomorrowworkstoryortask/{dailyDate}")]
        [HttpGet]
        public IEnumerable<DailyReportViewModel> GetDailyTomorrowWork(DateTime dailyDate)
        {
            return Execute(() => _workEntityLogic.GetDailyTomorrowWork(dailyDate));
        }

        [Route("api/works/clone/{id}")]
        [HttpGet]
        public void Clone(Guid id)
        {
            Execute(() => _workEntityLogic.Clone(id));
        }

        [Route("api/works/pagination")]
        [HttpPost]
        public PagedCollection<UserPointViewModel> Pagination([FromBody]UserPointPageAndSortingUICommand command)
        {
            return Execute(() => _workEntityLogic.GetUserPoint(command));
        }

        [Route("api/worktags")]
        [HttpPut]
        public void UpdateWorkEntityTag([FromBody] UpdateWorkEntityTagUICommand command)
        {
            Execute(() => _workEntityLogic.UpdateWorkEntityTag(command));
        }

        [Route("api/suggestions")]
        [HttpGet]
        public IEnumerable<TagViewModel> GetSuggestions()
        {
            return Execute(() => _workEntityLogic.GetSuggestions());
        }

        [Route("api/worktags/{id}")]
        [HttpGet]
        public IEnumerable<TagViewModel> GetWorkEntityTags(Guid id)
        {
            return Execute(() => _workEntityLogic.GetWorkEntityTags(id));
        }

        [Route("api/works/title")]
        [HttpPut]
        public void UpdateWorkEntityTitle(UpdateWorkEntityTitleUICommand command)
        {
            Execute(() => _workEntityLogic.UpdateWorkEntityTitle(command));
        }
    }
}