using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface ITypeFieldFormatService
    {
        Task<List<TypeFieldFormatDTO>> GetAllTypeFieldFormats();
        Task<TypeFieldFormatDTO> GetTypeFormat(int id);
        Task<TypeFieldFormatDTO> CreateTypeFieldFormat(TypeFieldFormatDTO typeFieldFormat);
        Task<bool> UpdatedTypeFieldFormat(TypeFieldFormatDTO typeFieldFormat);
        Task<bool> DeleteTypeFieldFormat(int id);
    }
}
