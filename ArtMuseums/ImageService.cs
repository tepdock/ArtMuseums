using CloudinaryDotNet;
using System;

namespace ArtMuseums
{
    public class ImageService
    {
        private readonly Cloudinary _cloudinary;
        public ImageService() {
            _cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL")) 
            {
                Api = 
                {
                    Secure= true,
                }
            };
        }
    }
}
