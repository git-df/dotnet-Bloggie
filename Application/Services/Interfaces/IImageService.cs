using Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        public Task<BaseResponse<string>> UploadAsync(IFormFile file);
    }
}
