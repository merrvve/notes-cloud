using Microsoft.AspNetCore.Mvc;
using nc2.Interfaces;

namespace nc2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        IMediaUpload _mediaService;
      public MediaController(IMediaUpload mediaService) 
        { 
        _mediaService= mediaService;
        }


        [HttpPost("{id}")]

        public async Task<IActionResult> UploadMedia(IFormFile file)
        {
            var result=  await _mediaService.UploadImageAsync(file);
            if(result.Error!= null) { return BadRequest(); }
            else { return Ok(201); }
        }
    }
}
