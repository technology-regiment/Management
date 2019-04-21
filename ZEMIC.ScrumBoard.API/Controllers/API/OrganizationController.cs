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
    public class OrganizationController : BaseApiController
    {
        private readonly IOrganizationLogic _organizationLogic;

        public OrganizationController(IOrganizationLogic organizationLogic)
        {
            _organizationLogic = organizationLogic;
        }

        [Route("api/organizations")]
        [HttpPost]
        public void Post([FromBody] CreateOrganizationUICommand command)
        {
            Execute(() =>
            {
                _organizationLogic.Create(command);
            });
        }

        [Route("api/organizations/pagination")]
        [HttpPost]
        public PagedCollection<OrganizationViewModel> Pagination([FromBody]OrganizationPageAndSortingUICommand pageAndSorting)
        {
            return Execute(() => _organizationLogic.GetAllByPageAndSorting(pageAndSorting));
        }

        [Route("api/organizations")]
        [HttpPut]
        public void Put([FromBody]UpdateOrganizationUIConmmand command)
        {
            Execute(() =>
            {
                _organizationLogic.Update(command);
            });
        }

        [Route("api/organizations/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _organizationLogic.Delete(id);
            });
        }

        [Route("api/organizations/{id}")]
        [HttpGet]
        public OrganizationViewModel GetById(Guid id)
        {
            return Execute(() => _organizationLogic.Get(id));
        }

        [Route("api/organizations/organizationSelects")]
        [HttpGet]
        public IEnumerable<OrganizationsDropDownListItem> GetOrganizationSelects()
        {
            return Execute(() => _organizationLogic.GetOrganizationsDropDownListItems());
        }
    }
}
