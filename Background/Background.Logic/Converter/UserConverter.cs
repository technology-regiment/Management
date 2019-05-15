using Background.Entities;
using Background.Logic.ViewModels;

namespace Background.Logic.Converter
{
    public static class UserConverter
    {
        public static UserViewModel ToViewModel(this User me)
        {
            return new UserViewModel
            {
                Id = me.Id,
                Name = me.Name,
            };
        }

    }
}