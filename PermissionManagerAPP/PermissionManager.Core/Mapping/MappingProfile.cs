using AutoMapper;
using PermissionManager.Core.Data.DTO;
using PermissionManager.Core.Data.Entity;

namespace PermissionManager.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PermissionDTO, Permission>().ReverseMap();
            CreateMap<PermissionTypeDTO, PermissionType>().ReverseMap();
        }
    }
}
