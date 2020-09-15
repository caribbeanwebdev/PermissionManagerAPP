using System.ComponentModel.DataAnnotations;

namespace PermissionManager.Core.Data.DTO
{
    public class PermissionTypeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
