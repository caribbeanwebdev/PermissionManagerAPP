using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PermissionManager.Core.Data;
using PermissionManager.Core.Data.DTO;
using PermissionManager.Core.Data.Entity;

namespace PermissionManager.Core.Service
{
  public class PermissionTypeService : IPermissionTypeService
  {

    private readonly IGenericRepository<PermissionType> _repo;
    private readonly IMapper _mapper;

    public PermissionTypeService(
        IGenericRepository<PermissionType> repo,
        IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    public async Task<IEnumerable<PermissionTypeDTO>> ListAllPermissionTypeAsync()
    {
      var entities =
          await _repo.GetAll();

      return entities
          .Select(e => _mapper.Map<PermissionType, PermissionTypeDTO>(e));
    }

    public async Task<PermissionTypeDTO> GetPermissionTypeAsync(int id)
    {
      var Type = await _repo.GetById(id);

      return _mapper.Map<PermissionType, PermissionTypeDTO>(Type);
    }

  }
}
