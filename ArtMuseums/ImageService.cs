
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ArtMuseums
{
    public class ImageService
    {
        public IConfiguration Configuration { get; }
        private CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;

        public ImageService(IConfiguration configuration)
        {
            Configuration = configuration;
            _cloudinarySettings = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey,
                _cloudinarySettings.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

        public  async Task<string> UploadImageAsync(IFormFile file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DiscardOriginalFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.Url.AbsolutePath;
        }
    }
}
