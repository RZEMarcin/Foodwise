using System.ComponentModel.DataAnnotations;

namespace Foodwise.Models
{
    
        public class Meal
        {
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string? Name { get; set; }

           
            [DataType(DataType.Date)]
            public DateTime DateTime { get; set; } = DateTime.Now;

        public ICollection<MealProduct> ?MealProducts { get; set; }
        }
    }

