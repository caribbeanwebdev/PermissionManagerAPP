using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PermissionManager.Core.Data;
using PermissionManager.Core.Data.DTO;
using PermissionManager.Core.Data.Entity;
using AutoMapper;

namespace PermissionManager.Core.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IGenericRepository<Permission> _repo;
        private readonly IMapper _mapper;

        public PermissionService(
            IGenericRepository<Permission> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PermissionDTO>> ListAllPermissionsAsync()
        {
            var Permissions = await
                _repo.GetPaginated(1, 10);

            var PermissionsDTO =
                Permissions.Select(e => _mapper.Map<Permission, PermissionDTO>(e));

            return PermissionsDTO;            
        }

        public async Task<PermissionDTO> GetPermissionAsync(int id)
        {
            var Permission = await _repo.GetById(id);
            var PermissionDTO = _mapper.Map<Permission, PermissionDTO>(Permission);

            return PermissionDTO;            
        }

        public async Task CreatePermissionAsync(PermissionDTO PermissionDTO)
        {
            var PermissionEntity = _mapper.Map<PermissionDTO, Permission>(PermissionDTO);

            await _repo.Create(PermissionEntity);
        }

        public async Task UpdatePermissionAsync(int id, PermissionDTO PermissionDTO) 
        {
            var PermissionEntity = _mapper.Map<PermissionDTO, Permission>(PermissionDTO);

            await _repo.Update(id, PermissionEntity);
        }

        public async Task DeletePermissionAsync(int id)
        {
            await _repo.Delete(id);
        }
  }
}
