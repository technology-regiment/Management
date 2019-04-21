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
    public class ProjectController : BaseApiController
    {
        private readonly IProjectLogic _projectLogic;

        public ProjectController(IProjectLogic projectLogic)
        {
            _projectLogic = projectLogic;
        }

        [Route("api/projects")]
        [HttpPost]
        public void Post([FromBody] CreateProjectUICommand command)
        {
            Execute(() => { _projectLogic.Create(command); });
        }

        [Route("api/projects/{id}")]
        [HttpGet]
        public ProjectFormViewModel Get(Guid id)
        {
            return Execute(() => _projectLogic.Get(id));
        }

        [Route("api/projects")]
        [HttpPut]
        public void Put([FromBody] UpdateProjectUICommand command)
        {
            Execute(() => { _projectLogic.Update(command); });
        }

        [Route("api/projects/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() => _projectLogic.Delete(id));
        }

        [Route("api/projects/pagination")]
        [HttpPost]
        public PagedCollection<ProjectViewModel> Pagination([FromBody]ProjectPageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _projectLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/projects/parentProjectSelects")]
        [HttpGet]
        public IEnumerable<ProjectsDropDownListItem> GetOrganizations()
        {
            return Execute(() => _projectLogic.GetParentProjectsDropDownListItems());
        }

        [Route("api/projects/projectTypeSelects")]
        [HttpGet]
        public IEnumerable<ProjectTypesDropDownListItem> GetProjectTypeSelects()
        {
            return Execute(DropDownListItemsCreator.GetProjectTypesDropDownListItems);
        }

        [Route("api/projects/projectmanagement")]
        [HttpGet]
        public IEnumerable<ProjectsByProjectManagementViewModel> GetProjectsByProjectManagement()
        {
            return Execute(() => _projectLogic.GetProjectsByProjectManagement());
        }
        [Route("api/projects/projectinfo")]
        [HttpGet]
        public IEnumerable<ProjectsDropDownListItem> GetProjectDropDown()
        {
            return Execute(() => _projectLogic.GetProjectDropDown());
        }
        [Route("api/projects/team")]
        [HttpGet]
        public IEnumerable<ProjectsDropDownListItem> GetProjectsByTeamManagement()
        {
            return Execute(() => _projectLogic.GetProjectsByTeamManagement());
        }
    }
}