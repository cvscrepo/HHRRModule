using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class EmployedService : IEmployedService
    {
        public IGenericRepository<Employed> _employedRepository;
        public IMapper mapper;

        public EmployedService(IGenericRepository<Employed> employedRepository, IMapper mapper)
        {
            _employedRepository = employedRepository;
            this.mapper = mapper;
        }

        public async Task<List<EmployedDTO>> GetAllEmployeds()
        {
            try
            {
                IQueryable<Employed> employeds = await _employedRepository.Consultar();
                return mapper.Map<List<EmployedDTO>>(employeds);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployedDTO> CreateEmployed(EmployedDTO employed)
        {
            try
            {
                Employed employedFound = await _employedRepository.Obtener(e => e.IdEmployed == employed.IdEmployed);
                if (employedFound != null)
                {
                    throw new Exception("El empleado ya existe");
                }
                Employed employedCreated = await _employedRepository.Crear(mapper.Map<Employed>(employed));
                return mapper.Map<EmployedDTO>(employedCreated);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployedDTO> UpdateEmployed(EmployedDTO employed)
        {
            try
            {
                Employed employedFound = await _employedRepository.Obtener(e => e.IdEmployed == employed.IdEmployed);
                if (employedFound == null)
                {
                    throw new Exception("El empleado no existe");
                }
                employedFound.Position = employed.Position;
                employedFound.Department = employed.Department;
                employedFound.TypeEmployed = employed.TypeEmployed; // Operativo o administrativo
                employedFound.StateId = employed.StateId; // Activo o inactivo
                employedFound.UrlPhoto = employed.UrlPhoto;
                employedFound.UpdatedAt = DateTime.Now;
                bool employedUpdated = await _employedRepository.Editar(employedFound);

                return mapper.Map<EmployedDTO>(employedFound);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployed(EmployedDTO employed)
        {
            try
            {
                Employed employedFound = await _employedRepository.Obtener(e => e.IdEmployed == employed.IdEmployed);
                if (employedFound == null)
                {
                    throw new Exception("El empleado no existe");
                }
                return await _employedRepository.Eliminar(employedFound);
            }
            catch
            {
                throw;
            }
        }
    }
}
