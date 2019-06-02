using System;

namespace Background.Logic
{
    public class UpdateRoleUICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}