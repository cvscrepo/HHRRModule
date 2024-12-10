using AutoMapper;
using HHRRModule.DTO;
using HHRRModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, UserDTO>().ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleDTO>().ReverseMap();
            #endregion

            #region Employee
            CreateMap<Employed, EmployedDTO>().ReverseMap();
            #endregion

            #region UserState
            CreateMap<UserState, UserStateDTO>().ReverseMap();
            #endregion

            #region RequestFormat
            CreateMap<RequestFormat, RequestFormatDTO>().ReverseMap();
            #endregion

            #region FieldFormat
            CreateMap<FieldFormat, FieldFormatDTO>().ReverseMap();
            #endregion

            #region TypeFormat
            CreateMap<TypeFormat, TypeFormatDTO>().ReverseMap();
            #endregion

            #region TypeFieldFormat
            CreateMap<TypeFieldFormat, TypeFieldFormatDTO>().ReverseMap();
            #endregion

            #region Authorization
            CreateMap<Authorization, AuthorizationDTO>().ReverseMap();
            #endregion

            #region RequestFormatAuth 
            CreateMap<RequestFormatAuth, RequestFormatAuthDTO>().ReverseMap();
            #endregion

            #region Logs
            CreateMap<Log, LogDTO>().ReverseMap();
            #endregion
        }
    }
}
