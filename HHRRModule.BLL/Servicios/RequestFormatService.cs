using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class RequestFormatService : IRequestFormatService
    {
        private readonly IGenericRepository<RequestFormat> _requestFormatRepository;
        private readonly IGenericRepository<Employed> _employedRequest;
        private readonly ITypeFormatService _typeFormatService;
        private readonly IMapper _mapper;

        public RequestFormatService(IGenericRepository<RequestFormat> genericRepository, IMapper mapper, ITypeFormatService typeFormatService)
        {
            _requestFormatRepository = genericRepository;
            _mapper = mapper;
            _typeFormatService = typeFormatService;
        }

        public async Task<List<RequestFormatDTO>> GetAllRequestFormats()
        {
            try
            {
                IQueryable<RequestFormat> requestFormats = await _requestFormatRepository.Consultar();
                List<RequestFormat> query = requestFormats.Include(r => r.FieldFormats).ThenInclude(t => t.IdTypeFieldNavigation).Include(r => r.RequestFormatAuths).AsEnumerable().ToList();
                return _mapper.Map<List<RequestFormatDTO>>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RequestFormatDTO> GetRequestFormat(int id)
        {
            try
            {
                IQueryable<RequestFormat> requestFormatById = await _requestFormatRepository.Consultar(r => r.IdRequest == id);
                RequestFormat requestFormat = requestFormatById.Include(r => r.FieldFormats).ThenInclude(f => f.IdTypeFieldNavigation).Include(r => r.RequestFormatAuths).FirstOrDefault();
                return _mapper.Map<RequestFormatDTO>(requestFormat);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RequestFormatDTO> CreateRequestFormat(RequestFormatDTO requestFormat)
        {
            try
            {
                // Validation of permission, employed and typeFormat
                Employed employe = await _employedRequest.Obtener(e => e.IdEmployed == requestFormat.IdEmployed) ?? throw new Exception("No existe el empleado");
                TypeFormatDTO typeFormat = await _typeFormatService.GetTypeFormat(requestFormat.IdTypeFormat) ?? throw new Exception("No existe el tipo de formato");

                // Create requestFormat
                RequestFormat requestFormatCreated = await _requestFormatRepository.Crear(_mapper.Map<RequestFormat>(requestFormat));
                return _mapper.Map<RequestFormatDTO>(requestFormatCreated);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdatedRequestFormat(RequestFormatDTO requestFormat)
        {
            try
            {
                // Validate if the requestFormat exists
                RequestFormat requestFormatExists = await _requestFormatRepository.Obtener(r => r.IdRequest == requestFormat.IdRequest) ?? throw new Exception("No existe el formato de solicitud");

                // Validate permission

                // Update requestFormat
                requestFormatExists.NameRequest = requestFormat.NameRequest;
                bool updated = await _requestFormatRepository.Editar(requestFormatExists);
                return updated;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteRequestFormat(int id)
        {
            try
            {
                IQueryable<RequestFormat> requestFormatExists = await _requestFormatRepository.Consultar(r => r.IdRequest == id) ?? throw new Exception("No existe el formato de solicitud");
                RequestFormat requestFormat = requestFormatExists.Include(r => r.FieldFormats).Include(r => r.RequestFormatAuths).FirstOrDefault();

                // Validate permission

                // Delete requestFormat
                bool deleted = await _requestFormatRepository.Eliminar(requestFormat);
                return deleted;
            }
            catch
            {
                throw;
            }
        }
    }
}
