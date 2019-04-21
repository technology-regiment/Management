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
    public class AbsenceController : BaseApiController
    {
        private readonly IAbsenceLogic _absenceLogic;

        public AbsenceController(IAbsenceLogic absence)
        {
            _absenceLogic = absence;
        }

        [Route("api/absences")]
        [HttpPost]
        public void Post([FromBody]CreateAbsenceUICommand command)
        {
            Execute(() =>
            {
                _absenceLogic.Create(command);
            });
        }

        [Route("api/absences/{id}")]
        [HttpGet]
        public AbsenceViewModel Get(Guid id)
        {
            return Execute(() => _absenceLogic.Get(id));
        }

        [Route("api/absences/absenceTypes/")]
        [HttpGet]
        public IEnumerable<AbsenceTypesDropDownListItem> GetAbsenceTypes()
        {
            return Execute(DropDownListItemsCreator.GetAbsenceTypesDropDownListItems);
        }
    }
}
