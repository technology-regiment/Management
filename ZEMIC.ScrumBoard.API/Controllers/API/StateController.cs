using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.Enums;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class StateController : BaseApiController
    {
        private readonly IStateLogic _stateLogic;

        public StateController(IStateLogic stateLogic)
        {
            _stateLogic = stateLogic;
        }

        [Route("api/states")]
        [HttpGet]
        public IEnumerable<StatesDropDownListItem> GetStatesDropDown()
        {
            return Execute(() => _stateLogic.GetStatesDropDown());
        }
    }
}