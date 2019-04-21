using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class CommentController:BaseApiController
    {
        private readonly ICommentLogic _commentLogic;

        public CommentController(ICommentLogic commentLogic)
        {
            _commentLogic = commentLogic;
        }

        [Route("api/comments")]
        [HttpPost]
        public void Post([FromBody]CreateCommentUICommand command)
        {
            Execute(() => { _commentLogic.Create(command); });
        }
    }
}