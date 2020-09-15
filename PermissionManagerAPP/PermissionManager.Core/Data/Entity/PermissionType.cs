using System.ComponentModel.DataAnnotations;

namespace PermissionManager.Core.Data.Entity
{
    public class PermissionType : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
