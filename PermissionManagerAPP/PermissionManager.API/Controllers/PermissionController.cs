using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermissionManager.Core.Data.DTO;
using PermissionManager.Core.Service;

namespace PermissionManager.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PermissionController : ControllerBase
  {
    private readonly IPermissionService _PermissionService;

    public PermissionController
    (
      IPermissionService PermissionService
    )
    {
      _PermissionService = PermissionService;
    }


    [HttpGet]
    public async Task<IEnumerable<PermissionDTO>> Get()
    {
      return await _PermissionService.ListAllPermissionsAsync();
    }


    [HttpGet("{id}")]
    public async Task<PermissionDTO> Get(int id)
    {
      return await _PermissionService.GetPermissionAsync(id);
    }


    [HttpPost]
    public async void Post([FromBody] PermissionDTO permission)
    {
      await _PermissionService.CreatePermissionAsync(permission);
    }


    [HttpPut("{id}")]
    public async void Put(int id, [FromBody] PermissionDTO permission)
    {
      await _PermissionService.UpdatePermissionAsync(id,permission);
    }


    [HttpDelete("{id}")]
    public async void Delete(int id)
    {
      await _PermissionService.DeletePermissionAsync(id);
    }
  }
}
