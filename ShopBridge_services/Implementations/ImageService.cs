using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ShopBridge_dtos;
using ShopBridge_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge_services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ImageSettings _imageSettings;
        public ImageService()
        {

        }

        public ImageService(IOptions<ImageSettings> imageSettings)
        {
            _imageSettings = imageSettings.Value;
            _cloudinary = new Cloudinary(new Account(_imageSettings.AccountName,
             _imageSettings.ApiKey, _imageSettings.ApiSecret));
        }

        public async Task<UploadResult> UploadImage(IFormFile image)
        {
            var pictureFormat = false;
            var imageExtension = new List<string>() { ".jpg", ".png", ".jpeg" };

            foreach (var item in imageExtension)
            {
                if (image.FileName.EndsWith(item))
                {
                    pictureFormat = true;
                    break;
                }
            }

            if (pictureFormat == false)
            {
                throw new NotSupportedException("Image format not supported");
            }

            var uploadResult = new ImageUploadResult();

            using (var imageStream = image.OpenReadStream())
            {
                string filename = Guid.NewGuid().ToString() + image.FileName;

                uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(filename, imageStream),
                    Transformation = new Transformation().Radius("max").Chain().Crop("scale").Width(200).Height(200)
                });
            }
            return uploadResult;
        }
    }
}
