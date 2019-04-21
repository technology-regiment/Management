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
    public class FeatureController : BaseApiController
    {
        private readonly IFeatureLogic _featureLogic;

        public FeatureController(IFeatureLogic featureLogic)
        {
            _featureLogic = featureLogic;
        }

        [Route("api/features")]
        [HttpPost]
        public Guid Post([FromBody]CreateFeatureUICommand command)
        {
            return Execute(() =>  _featureLogic.Create(command) );
        }

        [Route("api/features/dropdown")]
        [HttpGet]
        public IEnumerable<FeaturesDropDownListItem> GetFeaturesByDropDown()
        {
            return Execute(() => _featureLogic.GetFeaturesByDropDown());
        }

        [Route("api/features/{id}")]
        [HttpGet]
        public FeatureInfoViewModel GetFeatureInfos(Guid? id)
        {
            return Execute(() => _featureLogic.GetFeatureInfos(id));
        }

        [Route("api/features/userStorys/{id}")]
        [HttpGet]
        public IEnumerable<WorkTableInfoViewModel> GetUserStoryInfos(Guid id)
        {
            return Execute(() => _featureLogic.GetUserStoryInfos(id));
        }

        [Route("api/features/bugs/{id}")]
        [HttpGet]
        public IEnumerable<WorkTableInfoViewModel> GetBugInfos(Guid id)
        {
            return Execute(() => _featureLogic.GetBugInfos(id));
        }
    }
}