using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<UploadFileDto> Upload(IFormFile file )
        {
            #region Checking Extensions
            var extension = Path.GetExtension( file.FileName );

            var allowedExtensions= new string[]
            {
                ".png",
                ".jpg",
                ".svg"
            };

            bool isExtensionAllowed=allowedExtensions.Contains( extension, 
            StringComparer.InvariantCultureIgnoreCase);
            
            if(!isExtensionAllowed ) 
            {
                return BadRequest(new UploadFileDto());


            }
            #endregion

            #region Checking Length

            bool isSizeAllowed = file.Length is > 0 and < 4_000_000;
            if(!isSizeAllowed)
            {
                return BadRequest(new UploadFileDto());

            }
            #endregion

            #region Storing The Image

            var NewFileName = $"{Guid.NewGuid()}{extension}";
            var imagesPath = Path.Combine(Environment.CurrentDirectory, "images");
            var fullFilePath = Path.Combine(imagesPath, NewFileName);

            using var stream = new FileStream(fullFilePath, FileMode.Create);
            file.CopyTo(stream);

            #endregion

            #region Generating URL

            var url = $"{Request.Scheme}://{Request.Host}/Images/{NewFileName}";
            return new UploadFileDto(url);

            #endregion

        }





    }
}
