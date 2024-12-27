using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface ITypeFormatService
    {
        public Task<List<TypeFormatDTO>> GetAllTypeFormats();
        public Task<TypeFormatDTO> GetTypeFormat(int id);
        public Task<TypeFormatDTO> CreateTypeFormat(TypeFormatDTO typeFormat);
        public Task<bool> UpdateTypeFormat(TypeFormatDTO typeFormat);
        public Task<bool> DeleteTypeFormat(int id);
    }
}
