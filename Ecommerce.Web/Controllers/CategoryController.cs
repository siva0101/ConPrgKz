using Ecommerce.App.APIResponses;
using Ecommerce.App.Dto.CategoryDto;
using Ecommerce.App.Dto.ProductDto;
using Ecommerce.App.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using static Ecommerce.App.Constent.ApplicationContent;

namespace Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private APIResponse _response;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new APIResponse();
        }
        [HttpPost]
        [Route("UplaodCategory")]
        public async Task<ActionResult<APIResponse>>Create(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var result = await _categoryService.CreateAsync(createCategoryDto);
                if (result == null)
                {
                    return NotFound("Category is invalid");
                };
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.CreateOperationSuccess;
                _response.Result = result;
            }catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.IsSuccess= false;
                _response.Message = CommonMessage.CreateOperationFailed;
                _response.Result = ex;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var result = await _categoryService.GetAllAsync();
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = result;
            }catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.IsSuccess= false;
                _response.Result = ex;
            }
            return _response;
        }
    }
}
