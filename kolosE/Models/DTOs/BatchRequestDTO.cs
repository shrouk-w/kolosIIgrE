using System.ComponentModel.DataAnnotations;

namespace kolosE.Models.DTOs;

public class BatchRequestDTO
{
    [Required] 
    public int quantity { get; set; }
    [Required]
    [MaxLength(100)]
    public string Species { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nursery { get; set; }
    [Required]
    public List<EmployeeRequestDTO> Responsible { get; set; }
}