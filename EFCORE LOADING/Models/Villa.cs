using System.ComponentModel.DataAnnotations;

namespace EFCORE_LOADING.Models;

public class Villa
{
        [Key]
        public int ID { get; set; }
        
        public string? Name { get; set; }
        
        public double Price { get; set; }
        public ICollection<VillaAmeneties> VillaAmeneties { get; set; }
        
        
    }