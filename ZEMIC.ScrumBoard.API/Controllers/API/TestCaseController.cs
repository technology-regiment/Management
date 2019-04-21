using System;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class TestCaseController : BaseApiController
    {
        private readonly ITestCaseLogic _testCaseLogic;

        public TestCaseController(ITestCaseLogic testCaseLogic)
        {
            _testCaseLogic = testCaseLogic;
        }


        [Route("api/testcases")]
        [HttpPost]
        public Guid Post([FromBody]CreateTestCaseUICommand command)
        {
             return Execute(() =>  _testCaseLogic.Create(command));
        }

        [Route("api/testcases/{id}")]
        [HttpGet]
        public TestCaseInfoViewModel GetById(Guid id)
        {
            return Execute(() => _testCaseLogic.Get(id));
        }

        [Route("api/testcases")]
        [HttpPut]
        public void Put([FromBody] UpdateTestCaseStepUICommand command)
        {
            Execute(() => { _testCaseLogic.UpdateTestCaseStep(command); });
        }

    }
}