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
    public class TeamController : BaseApiController
    {
        private readonly ITeamLogic _teamLogic;

        public TeamController(ITeamLogic teamLogic)
        {
            _teamLogic = teamLogic;
        }

        [Route("api/teams/{id}")]
        [HttpGet]
        public TeamFormViewModel Get(Guid id)
        {
            return Execute(() => _teamLogic.Get(id));
        }

        [Route("api/teams")]
        [HttpPost]
        public void Post([FromBody]CreateTeamUICommand command)
        {
            Execute(() =>
            {
                _teamLogic.Create(command);
            });
        }

        [Route("api/teams/pagination")]
        [HttpPost]
        public PagedCollection<TeamViewModel> Pagination([FromBody]TeamPageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _teamLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/teams")]
        [HttpPut]
        public void Put([FromBody]UpdateTeamUICommand command)
        {
            Execute(() =>
            {
                _teamLogic.Update(command);
            });
        }

        [Route("api/teams/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _teamLogic.Delete(id);
            });
        }

        [Route("api/teams/userTeam/")]
        [HttpGet]
        public IEnumerable<TeamsDropDownListItem> GetTeams()
        {
            return Execute(() =>
            {
                return _teamLogic.GetTeamsDropDownListItems();
            });
        }

        [Route("api/teams/projectmanagement")]
        [HttpGet]
        public IEnumerable<TeamsDropDownListItem> GetTeamsByProjectManagement()
        {
            return Execute(() => _teamLogic.GetTeamsByProjectManagement());
        }

        [Route("api/teams/teammanagement")]
        [HttpGet]
        public IEnumerable<TeamsByTeamManagementViewModel> GetTeamsByTeamManagement()
        {
            return Execute(() => _teamLogic.GetTeamsByTeamManagement());
        }
    }
}