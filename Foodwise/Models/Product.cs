using System.ComponentModel.DataAnnotations;

namespace Foodwise.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Range(0, int.MaxValue)]    
        public decimal Calories { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Protein { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Carbohydrates { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Fat { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Weight { get; set; }


    }
}
