
using CloudinaryDotNet.Actions;

namespace nc2.Interfaces
{
    public interface IMediaUpload
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile image);
    }
}
