using System;
using System.Collections.Generic;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;
using ZEMIC.ScrumBoard.Logic.UICommands;
using ZEMIC.ScrumBoard.Logic.ViewModels;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    [TokenAuthorize]
    public class TestCaseStepController : BaseApiController
    {
        private readonly ITestCaseStepLogic _testCaseStepLogic;

        public TestCaseStepController(ITestCaseStepLogic testCaseStepLogic)
        {
            _testCaseStepLogic = testCaseStepLogic;
        }


        [Route("api/testcasesteps")]
        [HttpPost]
        public void Post([FromBody]CreateTestCaseStepUICommand command)
        {
            Execute(() => { _testCaseStepLogic.Create(command); });
        }

        [Route("api/testcasesteps/{id}")]
        [HttpGet]
        public IEnumerable<TestCaseStepViewModel> GetTestCaseStep(Guid id)
        {
            return Execute(() => _testCaseStepLogic.GetTestCaseStep(id));
        }

        [Route("api/testcasesteps/{id}")]
        [HttpDelete]
        public void DeleteTestCaseStep(Guid id)
        {
            Execute(() =>
            {
                _testCaseStepLogic.Delete(id);
            });
        }
    }
}