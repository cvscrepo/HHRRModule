using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IEmployedService
    {
        public Task<List<EmployedDTO>> GetAllEmployeds();
        public Task<EmployedDTO> CreateEmployed(EmployedDTO employed);
        public Task<EmployedDTO> UpdateEmployed(EmployedDTO employed);
        public Task<bool> DeleteEmployed(EmployedDTO employed);
    }
}
