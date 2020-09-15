using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionManager.Core.Data.Entity
{
  public class Permission : IEntity
  {        
      [Key]
      public int Id { get; set; }
      [Required]
      public string EmployeeName { get; set; }
      [Required]
      public string EmployeeLastName { get; set; }
      [ForeignKey("PermissionTypes")]
      [Required]
      public int PermissionType { get; set; }
      [Required]
      public DateTime PermissionDate { get; set; }

      public virtual PermissionType PermissionTypes { get; set; }
   }
}
