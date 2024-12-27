using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IFieldFormatService
    {
        Task<List<FieldFormatDTO>> GetAllFieldFormats();
        Task<FieldFormatDTO> CreateFieldFormat(FieldFormatDTO fieldFormat);
        Task<bool> UpdatedFieldFormat(FieldFormatDTO fieldFormat);
        Task<bool> DeleteFieldFormat(int id);   
    }
}
