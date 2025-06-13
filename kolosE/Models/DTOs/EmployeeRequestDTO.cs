using System.ComponentModel.DataAnnotations;

namespace kolosE.Models.DTOs;

public class EmployeeRequestDTO
{
    [Required]
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Role { get; set; }
    
}