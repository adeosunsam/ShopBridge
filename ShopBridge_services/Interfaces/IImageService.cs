using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ShopBridge_services.Interfaces
{
    public interface IImageService
    {
        Task<UploadResult> UploadImage(IFormFile image);
    }
}
