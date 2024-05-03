using Ecommerce.App.APIResponses;
using Ecommerce.App.Dto.BrandDto;
using Ecommerce.App.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.App.Constent.ApplicationContent;

namespace Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private APIResponse _response;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
            _response = new APIResponse();
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult<APIResponse>>Create(CreateBrandDto createBrandDto)
        {
            try
            {
                var result = await _brandService.CreateAysnc(createBrandDto);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.CreateOperationSuccess;
                _response.Result = result;
            }catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.Message = CommonMessage.CreateOperationFailed;
                _response.IsSuccess = false;
                _response.Result=ex;
            }
            return _response;
        }
    }
}
