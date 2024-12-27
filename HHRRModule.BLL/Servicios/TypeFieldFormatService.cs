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
    public class TypeFieldFormatService : ITypeFieldFormatService
    {
        private readonly IGenericRepository<TypeFieldFormat> _typeFieldFormatRepository;
        private readonly ITypeFormatService _typeFormatService;
        private readonly IMapper _mapper;

        public TypeFieldFormatService(IGenericRepository<TypeFieldFormat> typeFieldFormatRepository, IMapper mapper, ITypeFormatService typeFormatService)
        {
            _typeFieldFormatRepository = typeFieldFormatRepository;
            _mapper = mapper;
            _typeFormatService = typeFormatService;
        }

        public async Task<List<TypeFieldFormatDTO>> GetAllTypeFieldFormats()
        {
            try
            {
                IQueryable<TypeFieldFormat> typeFieldFormats = await _typeFieldFormatRepository.Consultar();
                if (!typeFieldFormats.Any())
                    throw new Exception("No records found.");

                List<TypeFieldFormat> query = typeFieldFormats.AsEnumerable().ToList();
                return _mapper.Map<List<TypeFieldFormatDTO>>(query);
            }
            catch (Exception ex)
            {
                // Log the exception (assuming a logging service is available)
                throw new Exception($"An error occurred while retrieving all TypeFieldFormats: {ex.Message}", ex);
            }
        }

        public async Task<TypeFieldFormatDTO> GetTypeFormat(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid ID provided.");

                IQueryable<TypeFieldFormat> typeFieldFormat = await _typeFieldFormatRepository.Consultar(t => t.IdTypeFormat == id)
                    ?? throw new Exception("Record not found.");

                return _mapper.Map<TypeFieldFormatDTO>(typeFieldFormat);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the TypeFieldFormat with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<TypeFieldFormatDTO> CreateTypeFieldFormat(TypeFieldFormatDTO typeFieldFormat)
        {
            try
            {
                // Check if TypeFormat exists
                TypeFormatDTO typeFormatDTO = await _typeFormatService.GetTypeFormat(typeFieldFormat.IdTypeFormat)
                    ?? throw new Exception("The TypeFormat does not exist.");

                TypeFieldFormat entity = _mapper.Map<TypeFieldFormat>(typeFieldFormat);

                TypeFieldFormat createdEntity = await _typeFieldFormatRepository.Crear(entity);
                return _mapper.Map<TypeFieldFormatDTO>(createdEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the TypeFieldFormat: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdatedTypeFieldFormat(TypeFieldFormatDTO typeFieldFormat)
        {
            try
            {

                TypeFieldFormat existingEntity = await _typeFieldFormatRepository.Obtener(t => t.IdTypeField == typeFieldFormat.IdTypeField)
                    ?? throw new Exception("Record not found.");

                existingEntity.IdTypeFormat = typeFieldFormat.IdTypeFormat;
                existingEntity.NameTypeField = typeFieldFormat.NameTypeField;
                existingEntity.TypeValue = typeFieldFormat.TypeValue;
                existingEntity.UpdatedAt = DateTime.Now;

                return await _typeFieldFormatRepository.Editar(existingEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the TypeFieldFormat: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteTypeFieldFormat(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Invalid ID provided.");

                TypeFieldFormat existingEntity = await _typeFieldFormatRepository.Obtener(t => t.IdTypeField == id)
                    ?? throw new Exception("Record not found.");

                return await _typeFieldFormatRepository.Eliminar(existingEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the TypeFieldFormat with ID {id}: {ex.Message}", ex);
            }
        }
    }

}
