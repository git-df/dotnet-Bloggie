using Application.Models;
using Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse> SignUp(SignUpUserModel model);
        Task<BaseResponse> SignIn(SignInUserModel model);
        Task SignOut();
    }
}
