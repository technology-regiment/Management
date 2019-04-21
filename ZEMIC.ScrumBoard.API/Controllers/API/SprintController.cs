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
    public class SprintController:BaseApiController
    {
        private readonly ISprintLogic _sprintLogic;

        public SprintController(ISprintLogic sprintLogic)
        {
            _sprintLogic = sprintLogic;
        }
        [Route("api/sprints")]
        [HttpGet]
        public IEnumerable<SprintslistItems> GetSprints()
        {
            return Execute(() => _sprintLogic.GetSprintslistItems());
        }

        [Route("api/sprints")]
        [HttpPost]
        public void Post([FromBody] CreateSprintUICommand command)
        {
            Execute(() =>
            {
                _sprintLogic.Create(command);
            });
        }
        [Route("api/sprints/pagination")]
        [HttpPost]
        public PagedCollection<SprintViewModel> Pagination([FromBody]SprintPageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _sprintLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/sprints")]
        [HttpPut]
        public void Put([FromBody]UpdateSprintUIConmmand command)
        {
            Execute(() =>
            {
                _sprintLogic.Update(command);
            });
        }

        [Route("api/sprints/{id}")]
        [HttpGet]
        public SprintViewModel GetById(Guid id)
        {
            return Execute(() => _sprintLogic.Get(id));
        }
    }
}