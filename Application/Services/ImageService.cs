using Application.Models.Enums;
using Application.Models.Responses;
using Application.Services.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private readonly Account account;

        public ImageService(IConfiguration configuration)
        {
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }

        public async Task<BaseResponse<string>> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(account);

            var response = await client.UploadAsync(new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.Name
            });

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new BaseResponse<string>(response.SecureUri.ToString(), "Success Upload");
            }

            return new BaseResponse<string>(false, "Something went wrong");
        }
    }
}