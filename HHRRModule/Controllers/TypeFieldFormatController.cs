using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Utility;
using Microsoft.AspNetCore.Mvc;

namespace HHRRModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeFieldFormatController : ControllerBase
    {
        private readonly ITypeFieldFormatService _typeFieldFormatService;

        public TypeFieldFormatController(ITypeFieldFormatService typeFieldFormatService)
        {
            _typeFieldFormatService = typeFieldFormatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypesFormat()
        {
            ResponseApi response = new ResponseApi();
            try
            {
                var typesFormat = await _typeFieldFormatService.GetAllTypeFieldFormats();
                response.Value = typesFormat;
                response.Message = "Success";
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeFormat(TypeFieldFormatDTO typeFieldFormat)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                var typeFormat = await _typeFieldFormatService.CreateTypeFieldFormat(typeFieldFormat);
                response.Value = typeFormat;
                response.Message = "Success";
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTypeFormat(TypeFieldFormatDTO typeFieldFormat)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                var typeFormat = await _typeFieldFormatService.UpdatedTypeFieldFormat(typeFieldFormat);
                response.Value = typeFormat;
                response.Message = "Success";
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeFormat(int id)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                var typeFormat = await _typeFieldFormatService.DeleteTypeFieldFormat(id);
                response.Value = typeFormat;
                response.Message = "Success";
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
    }
}
