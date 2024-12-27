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
    public class RequestFormatAuthService : IRequestFormatAuthService
    {
        private readonly IGenericRepository<RequestFormatAuth> _requestFormatAuthRepository;
        private readonly IMapper _mapper;

        public RequestFormatAuthService(IGenericRepository<RequestFormatAuth> requestFormatAuthRepository, IMapper mapper)
        {
            _requestFormatAuthRepository = requestFormatAuthRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreatedRequestFormatAuth(RequestFormatAuthDTO requestFormatAuth)
        {
            try
            {
                // check if the request format auth already exists
                IQueryable<RequestFormatAuth> requestFormatAuths = await _requestFormatAuthRepository.Consultar(r => r.IdRequestFormat == requestFormatAuth.IdRequestFormat);
                if (requestFormatAuths.Any())
                    throw new Exception("The request format auth already exists.");
                RequestFormatAuth created = await _requestFormatAuthRepository.Crear(_mapper.Map<RequestFormatAuth>(requestFormatAuth));
                return created != null;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> EditRequestFormatAuth(RequestFormatAuthDTO requestFormatAuth)
        {
            try
            {
                // Check if the request format auth already exists
                RequestFormatAuth requestFormatAuths = await _requestFormatAuthRepository.Obtener(r => r.IdRequestFormat == requestFormatAuth.IdRequestFormat);
                if (requestFormatAuths == null)
                    throw new Exception("The request format auth does not exist.");
                requestFormatAuths.Value = requestFormatAuth.Value;
                bool formatEdited = await _requestFormatAuthRepository.Editar(_mapper.Map<RequestFormatAuth>(requestFormatAuths));
                return formatEdited;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteRequestFormatAuth(int idRequestFormatAuth)
        {
            try
            {
                // Check if the request format auth already exists
                RequestFormatAuth requestFormatAuths = await _requestFormatAuthRepository.Obtener(r => r.IdRequestFormat == idRequestFormatAuth);
                if (requestFormatAuths == null)
                    throw new Exception("The request format auth does not exist.");
                bool deleted = await _requestFormatAuthRepository.Eliminar(_mapper.Map<RequestFormatAuth>(requestFormatAuths));
                return deleted;
            }
            catch
            {
                throw;
            }
        }

    }
}
