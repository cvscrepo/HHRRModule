using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class TypeFormatService : ITypeFormatService
    {
        private readonly IGenericRepository<TypeFormat> _typeFormatRepository;
        private readonly IMapper _mapper;

        public TypeFormatService(IGenericRepository<TypeFormat> typeFormatRepository, IMapper mapper)
        {
            _typeFormatRepository = typeFormatRepository;
            _mapper = mapper;
        }

        public async Task<List<TypeFormatDTO>> GetAllTypeFormats()
        {
            try
            {
                IQueryable<TypeFormat> typeFormats = await _typeFormatRepository.Consultar();
                List<TypeFormat> query = typeFormats.Include(t => t.Authorizations).Include(t => t.TypeFieldFormats).AsEnumerable().ToList();
                return _mapper.Map<List<TypeFormatDTO>>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TypeFormatDTO> GetTypeFormat(int id)
        {
            try
            {
                IQueryable<TypeFormat> typeFormats = await _typeFormatRepository.Consultar(t=> t.IdTypeFormat == id);
                TypeFormat query = typeFormats.Include(t => t.Authorizations).Include(t => t.TypeFieldFormats).FirstOrDefault();
                return _mapper.Map<TypeFormatDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TypeFormatDTO> CreateTypeFormat(TypeFormatDTO typeFormat)
        {
            try
            {
                // Validate if typeFormat in created
                TypeFormat typeFormat1 = await _typeFormatRepository.Obtener(t => t.NameType == typeFormat.NameType);
                if (typeFormat1 != null)
                {
                    throw new Exception("El tipo de formato ya existe");
                }
                TypeFormat entity = _mapper.Map<TypeFormat>(typeFormat);
                TypeFormat typeFormatCreated = await _typeFormatRepository.Crear(entity);
                return _mapper.Map<TypeFormatDTO>(typeFormatCreated);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateTypeFormat(TypeFormatDTO typeFormat)
        {
            try
            {
                TypeFormat typeFormat1 = _mapper.Map<TypeFormat>(typeFormat);
                // buscar el registro
                TypeFormat typeFormat2 = await _typeFormatRepository.Obtener(t => t.IdTypeFormat == typeFormat.IdTypeFormat) ?? throw new Exception("No se encontró");
                // actualizar el registro
                typeFormat2.NameType = typeFormat1.NameType;
                typeFormat2.TypeCode = typeFormat1.TypeCode;
                typeFormat2.Version = typeFormat1.Version;
                typeFormat2.UpdatedAt = DateTime.Now;
                
                // guardar los cambios
                return await _typeFormatRepository.Editar(typeFormat2);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteTypeFormat(int id)
        {
            try
            {
                TypeFormat typeFormat2 = await _typeFormatRepository.Obtener(t => t.IdTypeFormat == id) ?? throw new Exception("No se encontró");
                // eliminar el registro
                return await _typeFormatRepository.Eliminar(typeFormat2);
            }
            catch
            {
                throw;
            }
        }
    }
}
