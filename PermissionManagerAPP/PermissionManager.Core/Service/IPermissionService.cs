using System.Collections.Generic;
using System.Threading.Tasks;
using PermissionManager.Core.Data.DTO;

namespace PermissionManager.Core.Service
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionDTO>> ListAllPermissionsAsync();
        Task<PermissionDTO> GetPermissionAsync(int id);
        Task CreatePermissionAsync(PermissionDTO Permission);
        Task UpdatePermissionAsync(int id,PermissionDTO Permission);
        Task DeletePermissionAsync(int id);
  }
}
