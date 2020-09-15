using System;
using System.ComponentModel.DataAnnotations;

namespace PermissionManager.Core.Data.DTO
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public int PermissionType { get; set; }
        [Required]
        public DateTime PermissionDate { get; set; }

        public virtual PermissionTypeDTO PermissionTypes { get; set; }
  }
}
