using Armory.Api.Controllers.ArmoryUsers.Requests;
using Armory.Users.Application.ChangePassword;
using Armory.Users.Application.ResetPassword;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class ArmoryUsersProfile : Profile
    {
        public ArmoryUsersProfile()
        {
            CreateMap<ResetPasswordRequest, ResetPasswordCommand>();
            CreateMap<ChangePasswordRequest, ChangePasswordCommand>();
        }
    }
}
