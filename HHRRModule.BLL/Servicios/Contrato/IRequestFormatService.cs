using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IRequestFormatService
    {
        Task<List<RequestFormatDTO>> GetAllRequestFormats();
        Task<RequestFormatDTO> GetRequestFormat(int id);
        Task<RequestFormatDTO> CreateRequestFormat(RequestFormatDTO requestFormat);
        Task<bool> UpdatedRequestFormat(RequestFormatDTO requestFormat);
        Task<bool> DeleteRequestFormat(int id);
    }
}
