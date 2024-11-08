using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE_LOADING.Models;

public class VillaAmeneties
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    

    // Foreign key for Villa
    [ForeignKey("Villa")]
    public int VillaId { get; set; }
    
    // Navigation property back to Villa
    public Villa Villa { get; set; }
}