using PermissionManager.Core.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Core.Service
{
  public interface IPermissionTypeService
  {
    Task<IEnumerable<PermissionTypeDTO>> ListAllPermissionTypeAsync();
    Task<PermissionTypeDTO> GetPermissionTypeAsync(int id);
  }
}
