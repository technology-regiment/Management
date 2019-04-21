using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.Enums;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class BusinessValueController : BaseApiController
    {
        private readonly IBusinessValueLogic _businessValueLogic;

        public BusinessValueController(IBusinessValueLogic businessValueLogic)
        {
            _businessValueLogic = businessValueLogic;
        }

        [Route("api/businessValues")]
        [HttpGet]
        public IEnumerable<BusinessValueDropDownListItem> GetBusinessValuesDropDown()
        {
            return Execute(() => _businessValueLogic.GetBusinessValuesDropDown());
        }
    }
}