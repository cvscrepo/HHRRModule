using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Utility;
using Microsoft.AspNetCore.Mvc;

namespace HHRRModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestFormatController : ControllerBase
    {
        private readonly IRequestFormatService _requestFormatService;

        public RequestFormatController(IRequestFormatService requestFormatService)
        {
            _requestFormatService = requestFormatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequestFormats()
        {
            ResponseApi responseApi = new ResponseApi();
            try
            {
                List<RequestFormatDTO> requestFormats = await _requestFormatService.GetAllRequestFormats();
                responseApi.Success = true;
                responseApi.Value = requestFormats;
                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
                return BadRequest(responseApi);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestFormat(int id)
        {
            ResponseApi responseApi = new ResponseApi();
            try
            {
                RequestFormatDTO requestFormat = await _requestFormatService.GetRequestFormat(id);
                responseApi.Success = true;
                responseApi.Value = requestFormat;
                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
                return BadRequest(responseApi);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequestFormat([FromBody] RequestFormatDTO requestFormat)
        {
            try
            {
                RequestFormatDTO requestFormatCreated = await _requestFormatService.CreateRequestFormat(requestFormat);
                return Ok(requestFormatCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
    }
}
