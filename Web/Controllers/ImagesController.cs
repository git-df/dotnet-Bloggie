using Application.Models.Responses;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<BaseResponse<string>> UploadAsync(IFormFile file)
        {
            var response = await _imageService.UploadAsync(file);

            return response;
        }
    }
}
