using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using nc2.Interfaces;

namespace nc2.Services
{
    public class MediaService : IMediaUpload
    {
        private readonly Cloudinary cloudinary;

        public MediaService() {
            cloudinary = new Cloudinary(new Account("deycjgpbv", "266778978122679", "GMy9e6jIM_JtAaXpxTRuhHSA7cM"));

        }
        public async Task<ImageUploadResult> UploadImageAsync(IFormFile image)
        {
            var uploadResult = new ImageUploadResult();
            if(image.Length> 0)
            {
                using var stream =  image.OpenReadStream();
                var uploadParams = new ImageUploadParams {
                    File = new FileDescription(image.FileName, stream),
                    Transformation = new Transformation().Height(200).Width(200).Crop("limit")
                };

                uploadResult= await cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;    
        }
    }
}
