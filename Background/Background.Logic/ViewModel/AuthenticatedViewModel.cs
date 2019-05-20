using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Logic.ViewModel
{
    public class AuthenticatedViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AuthenticationToken { get; set; }
        public string SystemRoleName { get; set; }
        public Guid SystemRoleId { get; set; }
    }
}
