using System.ComponentModel.DataAnnotations;

namespace Foodwise.Models
{
    public class MealProduct
    {
        public int Id { get; set; }

        [Required]
        public int MealId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Quantity { get; set; }

        public Meal ?Meal { get; set; }

        public Product ?Product { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Weight { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Kcal { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Protein { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Fat { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Carbohydrates { get; set; }

    }
}
