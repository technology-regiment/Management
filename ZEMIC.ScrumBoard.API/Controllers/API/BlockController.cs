using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class BlockController : BaseApiController
    {
        private readonly IBlockLogic _blockLogic;

        public BlockController(IBlockLogic blockLogic)
        {
            _blockLogic = blockLogic;
        }

        [Route("api/blocks")]
        [HttpPost]
        public void Post([FromBody]CreateBlockUICommand command)
        {
            Execute(() => { _blockLogic.Create(command); });
        }
    }
}