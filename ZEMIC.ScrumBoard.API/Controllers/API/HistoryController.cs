using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class HistoryController : BaseApiController
    {
        private readonly IHistoryLogic _historyLogic;

        public HistoryController(IHistoryLogic historyLogic)
        {
            _historyLogic = historyLogic;
        }

        [Route("api/historys")]
        [HttpPost]
        public IEnumerable<HistoryViewModel> GetAllHistory([FromBody]HistoryPageAndSortingUICommand command)
        {
            return Execute(() => _historyLogic.GetAllHistory(command));
        }

        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "Content-Disposition", SupportsCredentials = true)]
        [Route("api/historyExport")]
        [HttpPost]
        public HttpResponseMessage Export([FromBody]HistoryPageAndSortingUICommand command)
        {
            return Execute(() => _historyLogic.Export(command));
        }
    }
}