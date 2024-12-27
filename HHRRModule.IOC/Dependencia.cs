using HHRRModule.BLL.Servicios;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.BLL.Servicios_tareas;
using HHRRModule.BLL.Servicios_tareas.Contrato;
using HHRRModule.DAL.Repositorios;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.Model;
using HHRRModule.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HhrrmoduleContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CadenaSql"))
            );
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IContextClaimsService, ContextClaimsService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IFieldFormatService, FieldFormatService>();
            services.AddScoped<IRequestFormatAuthService, RequestFormatAuthService>();
            services.AddScoped<IRequestFormatService, RequestFormatService>();
            services.AddScoped<ITypeFieldFormatService, TypeFieldFormatService>();
            services.AddScoped<ITypeFormatService, TypeFormatService>();
            services.AddScoped<IEmployedService, EmployedService>();
            services.AddScoped<IRoleService, RoleService>();    
            services.AddScoped<TypeFormatService, TypeFormatService>();
        }
    }
}
