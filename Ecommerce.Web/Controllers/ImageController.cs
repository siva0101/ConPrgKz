using Ecommerce.App.APIResponses;
using Ecommerce.App.Dto.ProductDto;
using Ecommerce.App.Service.Interface;
using Ecommerce.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SQLitePCL;
using static Ecommerce.App.Constent.ApplicationContent;

namespace Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContexts _context;
        private APIResponse _apiResponse;
        public ImageController(IImageService imageService, IWebHostEnvironment webHostEnvironment, ApplicationDbContexts context)
        {
            _imageService = imageService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _apiResponse = new APIResponse();

        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<ActionResult> Create([FromForm] CreateImageDto createImageDto, [FromForm] List<IFormFile> files)
        {
            try
            {
                //foreach (var file in files)
                //{
                //    //var fileName = Path.GetFileName(file.FileName);
                //    var filepath = Path.Combine(_webHostEnvironment.ContentRootPath + "/Images", file.FileName);
                //    using (var stream = new FileStream(filepath, FileMode.Create))
                //    {
                //        await file.CopyToAsync(stream); 
                //    }
                //    createImageDto.Image = file.FileName;

                //}
                ////var imagePath = await _context.ImageDb
                //.Select(i => i.Image)
                //.FirstOrDefaultAsync();

                //// If no image path is found, return NotFound response
                //if (imagePath == null)
                //{
                //    return NotFound();
                //}

                //// Open the image file stream
                //var imageFileStream = System.IO.File.OpenRead(imagePath);

                //// Return the image file stream as a file result with the appropriate content type
                //return File(imageFileStream, "image/jpeg"); // Change content type as needed

                foreach (var file in files)
                {
                    // Generate a new UUID for the image filename
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                

                    // Define the file path where the image will be saved
                    var filePath = Path.Combine(_webHostEnvironment.ContentRootPath + "/Images", uniqueFileName);

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Assign the UUID as the image filename in your DTO or model property
                    createImageDto.Image = uniqueFileName;
                }


                var result = await _imageService.CreateAsync(createImageDto);
                _apiResponse.StatusCode = System.Net.HttpStatusCode.Created;
                _apiResponse.IsSuccess  = true;
                _apiResponse.Message = CommonMessage.CreateOperationSuccess;
                _apiResponse.Result = result;
                return Ok(result);
            }
            catch (Exception)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _apiResponse.AddErrors(CommonMessage.SystemError);
                _apiResponse.IsSuccess = false;
                return NotFound("something worng");
            }
            
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                var result = await _imageService.GetAllAsync();
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.Result = result;
                
            }catch (Exception ex)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _apiResponse.AddErrors(CommonMessage.SystemError);
                _apiResponse.IsSuccess = false;
                _apiResponse.Result= ex;
            }
            return _apiResponse;
        }
    }
}
