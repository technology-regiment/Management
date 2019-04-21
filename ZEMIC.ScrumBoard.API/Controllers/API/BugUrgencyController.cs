using System;
using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.Enums;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class BugUrgencyController : BaseApiController
    {
        private readonly IBugUrgencyLogic _bugUrgencyLogic;

        public BugUrgencyController(IBugUrgencyLogic bugUrgencyLogic)
        {
            _bugUrgencyLogic = bugUrgencyLogic;
        }

        [Route("api/bugUrgencys")]
        [HttpPost]
        public void Post([FromBody]CreateBugUrgencyUICommand command)
        {
            Execute(() =>
            {
                _bugUrgencyLogic.Create(command);
            });
        }

        [Route("api/bugUrgencys")]
        [HttpPut]
        public void Put([FromBody]UpdateBugUrgencyUICommand command)
        {
            Execute(() =>
            {
                _bugUrgencyLogic.Update(command);
            });
        }

        [Route("api/bugUrgencys/{id}")]
        [HttpGet]
        public BugUrgencyViewModel Get(Guid id)
        {
            return Execute(() => _bugUrgencyLogic.Get(id));
        }

        [Route("api/bugUrgencys/pagination")]
        [HttpPost]
        public PagedCollection<BugUrgencyViewModel> Pagination([FromBody]BugUrgencyPageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _bugUrgencyLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/bugUrgencys")]
        [HttpGet]
        public IEnumerable<BugUrgencyDropDownListItem> GetBugUrgencyDropDown()
        {
            return Execute(() => _bugUrgencyLogic.GetBugUrgencyDropDown());
        }
    }
}