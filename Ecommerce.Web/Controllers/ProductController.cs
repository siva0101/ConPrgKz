using Ecommerce.App.APIResponses;
using Ecommerce.App.Dto.ProductDto;
using Ecommerce.App.Service.Interface;
using Ecommerce.Domain.Models;
using Ecommerce.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using static Ecommerce.App.Constent.ApplicationContent;

namespace Ecommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private APIResponse _response;
        public ProductController(IProductService service)
        {
            _service = service;
            
            _response = new APIResponse();
           
        }
        [HttpPost]
        [Route("UploadProduct")]
        //[Consumes("multipart/form-data")]
        
        public async Task<ActionResult<APIResponse>> Create( [FromBody]CreateProductDto createProductDto)
        {
            try
            {

                 var result = await _service.CreateAsync(createProductDto);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.CreateOperationSuccess;
                _response.Result = result;

               
            }
            catch (Exception ex)
            {
               _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = CommonMessage.CreateOperationFailed;
                _response.Result = ex;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var result = await _service.GetAllAsync();

                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;
            }catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Result = ex.Message;
            }
            return Ok(_response);
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<APIResponse>>Update(UpdateProductDto updateProductDto)
        {
            try
            {
                await _service.UpdateAsync(updateProductDto);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.UpdateOperationSuccess;
            }catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = CommonMessage.UpdateOperationFailed;
                _response.Result =ex.Message;
            }
            return Ok(_response);
        }

        [HttpDelete]
        [Route("DeleteProducts")]
        public async Task<ActionResult<APIResponse>>Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Invalid id");
                }

                var result = await _service.GetByIdAsync(id);
                if (result == null) 
                {
                    return NotFound("No Records");
                }
                await _service.DeleteAsync(id);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Message= CommonMessage.DeleteOperationSuccess;
                _response.Result = result;
            }catch (Exception ex)
            {
                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = CommonMessage.DeleteOpeationFailed;
                _response.Result = ex.Message;
            }
            return Ok(_response);
        }
    }
}
