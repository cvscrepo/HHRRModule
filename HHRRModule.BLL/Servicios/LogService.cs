using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class LogService : ILogService
    {
        private readonly IGenericRepository<Log> _logRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LogService(IGenericRepository<Log> logRepository, IMapper mapper, IUserService userService, IHttpContextAccessor httpContextAccessor )
        {
            _logRepository = logRepository;
            _mapper = mapper;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetClientIp()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return "IP no disponible";
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            return !string.IsNullOrEmpty(ipAddress) ? ipAddress : "IP no disponible";
        }

        public async Task<List<LogDTO>> GetAllLogs()
        {
            try
            {
                var logs = await _logRepository.Consultar();
                var query = logs.Include(c => c.User).AsEnumerable().ToList();
                return _mapper.Map<List<LogDTO>>(logs);
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<LogDTO> CreateLog(LogDTO log)
        {
            try
            {
                // check if user exist 
                var user = _userService.GetUser(log.UserId) ?? throw new Exception("No se encontró el usuario asociado al log");
                // Get ip address
                log.Description += " El ip del usuario es:" + GetClientIp();
                // Create log
                var logCreated = await _logRepository.Crear(_mapper.Map<Log>(log));
                
                return _mapper.Map<LogDTO>(logCreated);
            }
            catch
            {
                throw;
            }
        }
        
        public Task<bool> DeleteLog(LogDTO log)
        {
            try
            {
                // check if the log exists
                var logCreated = _logRepository.Obtener(l => l.IdLog == log.IdLog) ?? throw new Exception("No se encontró el log a eliminar");
                return _logRepository.Eliminar(_mapper.Map<Log>(log));
            }
            catch
            {
                throw;
            }
        }


    }
}
