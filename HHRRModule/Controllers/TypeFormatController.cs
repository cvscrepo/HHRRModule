using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Utility;
using Microsoft.AspNetCore.Mvc;

namespace HHRRModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeFormatController : ControllerBase
    {
        private readonly ITypeFormatService typeFormatService;

        public TypeFormatController(ITypeFormatService typeFormatService)
        {
            this.typeFormatService = typeFormatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypeFormats()
        {
            ResponseApi response = new ResponseApi();
            try
            {
                List<TypeFormatDTO> typeFormats = await typeFormatService.GetAllTypeFormats();
                response.Success = true;
                response.Message = "Success";
                response.Value = typeFormats;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeFormat(int id)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                TypeFormatDTO typeFormat = await typeFormatService.GetTypeFormat(id);
                response.Success = true;
                response.Message = "Success";
                response.Value = typeFormat;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeFormat(TypeFormatDTO typeFormat)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                TypeFormatDTO typeFormatCreated = await typeFormatService.CreateTypeFormat(typeFormat);
                response.Success = true;
                response.Message = "Success";
                response.Value = typeFormatCreated;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTypeFormat(TypeFormatDTO typeFormat)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                bool updated = await typeFormatService.UpdateTypeFormat(typeFormat);
                response.Success = updated;
                response.Message = updated ? "Success" : "Error";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeFormat(int id)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                bool deleted = await typeFormatService.DeleteTypeFormat(id);
                response.Success = deleted;
                response.Message = deleted ? "Success" : "Error";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
