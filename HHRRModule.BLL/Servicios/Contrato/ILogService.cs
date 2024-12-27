using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface ILogService
    {
        Task<List<LogDTO>> GetAllLogs();
        Task<LogDTO> CreateLog(LogDTO log);
        Task<bool> DeleteLog(LogDTO log);
    }
}
