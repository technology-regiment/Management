using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class BurnDownChartController : BaseApiController
    {
        private readonly IBurnDownChartLogic _burnDownChartLogic;

        public BurnDownChartController(IBurnDownChartLogic burnDownChartLogic)
        {
            _burnDownChartLogic = burnDownChartLogic;
        }

        [Route("api/burnDownCharts")]
        [HttpPut]
        public void Update([FromBody]UpdateBurnDownChartUICommand command)
        {
            Execute(() => { _burnDownChartLogic.Update(command); });
        }

        [Route("api/burnDownCharts")]
        [HttpGet]
        public BurnDownChartViewModel GetBurnDownChartData()
        {
            return Execute(() => _burnDownChartLogic.GetBurnDownChartData());
        }
    }
}