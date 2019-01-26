using AutoMapper;
using iForce.Core.Models;
using iForce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Core
{
    public static class Startup
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserViewModel>()
                    //.ForMember(dest => dest.UserStatusId, opts => opts.MapFrom(src => src.UserStatusId))
                    .ForMember(dest => dest.StatusString, opts => opts.MapFrom(src => src.UserStatus.Name))
                    //.ForMember(dest => dest.UserRoleId, opts => opts.MapFrom(src => src.UserRoleId))
                    .ForMember(dest => dest.RoleString, opts => opts.MapFrom(src => src.UserRole.Name));

                cfg.CreateMap<UserViewModel, User>()
                    .ForMember(dest => dest.UserRole, opts => opts.Ignore())
                    .ForMember(dest => dest.UserStatus, opts => opts.Ignore());

                cfg.CreateMap<List<User>, List<UserViewModel>>();
            });
        }
    }
}
