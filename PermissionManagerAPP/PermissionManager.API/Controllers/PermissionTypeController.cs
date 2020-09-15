using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermissionManager.Core.Data.DTO;
using PermissionManager.Core.Service;

namespace PermissionManager.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PermissionTypeController : ControllerBase
  {
    private readonly IPermissionTypeService _PermissionTypeService;

    public PermissionTypeController
    (
      IPermissionTypeService PermissionTypeService
    )
    {
      _PermissionTypeService = PermissionTypeService;
    }

    [HttpGet]
    public async Task<IEnumerable<PermissionTypeDTO>> Get()
    {
      return await _PermissionTypeService.ListAllPermissionTypeAsync();
    }

    [HttpGet("{id}")]
    public async Task<PermissionTypeDTO> Get(int id)
    {
      return await _PermissionTypeService.GetPermissionTypeAsync(id);
    }
  }
}
