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
    public class FieldFormatService : IFieldFormatService
    {
        private readonly IGenericRepository<FieldFormat> _fieldFormatRepository;
        private readonly ITypeFieldFormatService _typeFieldFormatService;
        private readonly IRequestFormatService _requestFormatService;
        private readonly IMapper _mapper;

        public FieldFormatService(IGenericRepository<FieldFormat> genericRepository, IMapper mapper, ITypeFieldFormatService typeFieldFormatService, IRequestFormatService requestFormatService)
        {
            _fieldFormatRepository = genericRepository;
            _mapper = mapper;
            _typeFieldFormatService = typeFieldFormatService;
            _requestFormatService = requestFormatService;
        }

        public async Task<List<FieldFormatDTO>> GetAllFieldFormats()
        {
            try
            {
                IQueryable<FieldFormat> fieldFormats = await _fieldFormatRepository.Consultar();
                List<FieldFormat> query = fieldFormats.Include(f => f.IdTypeFieldNavigation).AsEnumerable().ToList();
                return _mapper.Map<List<FieldFormatDTO>>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<FieldFormatDTO> CreateFieldFormat(FieldFormatDTO fieldFormat)
        {
            try
            {
                // validate typeField
                TypeFieldFormatDTO typeField = await _typeFieldFormatService.GetTypeFormat(fieldFormat.IdTypeField) ?? throw new Exception("TypeField not found");

                // Validate RequestFormat
                RequestFormatDTO requestFormat = await _requestFormatService.GetRequestFormat(fieldFormat.IdRequestFormat) ?? throw new Exception("RequestFormat not found");

                FieldFormat fieldCreated = await _fieldFormatRepository.Crear(_mapper.Map<FieldFormat>(fieldFormat));

                return _mapper.Map<FieldFormatDTO>(fieldCreated);
            }
            catch
            {
                throw;

            }
        }
        public async Task<bool> UpdatedFieldFormat(FieldFormatDTO fieldFormat)
        {
            try
            {
                // Validate permission 

                // validate typeField
                TypeFieldFormatDTO typeField = await _typeFieldFormatService.GetTypeFormat(fieldFormat.IdTypeField) ?? throw new Exception("TypeField not found");

                // Validate RequestFormat
                RequestFormatDTO requestFormat = await _requestFormatService.GetRequestFormat(fieldFormat.IdRequestFormat) ?? throw new Exception("RequestFormat not found");

                // Validate if the fieldFormat exists
                FieldFormat fieldFormatExists = await _fieldFormatRepository.Obtener(f => f.IdField == fieldFormat.IdField) ?? throw new Exception("FieldFormat not found");

                // Update fieldFormat
                fieldFormatExists.NameFieldRequest = fieldFormat.NameFieldRequest;
                fieldFormatExists.ValueField = fieldFormat.ValueField;
                fieldFormatExists.UpdatedAt = DateTime.Now;
                bool updated = await _fieldFormatRepository.Editar(fieldFormatExists);
                return updated;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteFieldFormat(int id)
        {
            try
            {
                // Validate permission

                // Validate if the fieldFormat exists
                FieldFormat fieldFormatExists = await _fieldFormatRepository.Obtener(f => f.IdField == id) ?? throw new Exception("FieldFormat not found");

                // Delete fieldFormat
                bool deleted = await _fieldFormatRepository.Eliminar(fieldFormatExists);
                return deleted;
            }
            catch
            {
                throw;

            }
        }
    }
}
