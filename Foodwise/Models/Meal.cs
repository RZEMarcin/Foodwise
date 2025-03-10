using System.ComponentModel.DataAnnotations;

namespace Foodwise.Models
{

    public class Meal
    {
        public Meal()
        {
            MealProducts = new List<MealProduct>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } = DateTime.Now;

        public ICollection<MealProduct> MealProducts { get; set; }

        public decimal TotalCalories
        {

            get
            {
                decimal total = 0;
                foreach (var mealProduct in MealProducts)
                {
                    var product = mealProduct.Product;
                    if (product != null)
                    {
                        total += (product.Calories * mealProduct.Quantity * mealProduct.Weight) / 100;
                    }
                }
                return total;
            }
        }

        public decimal TotalProtein
        {
            get
            {
                decimal total = 0;
                foreach (var mealProduct in MealProducts)
                {
                    var product = mealProduct.Product;
                    if (product != null)
                    {
                        total += (product.Protein * mealProduct.Quantity * mealProduct.Weight) / 100; 
                    }
                }
                return total;
            }
        }

        public decimal TotalCarbs
        {
            get
            {
                decimal total = 0;
                foreach (var mealProduct in MealProducts)
                {
                    var product = mealProduct.Product;
                    if (product != null)
                    {
                        total += (product.Carbohydrates * mealProduct.Quantity * mealProduct.Weight) / 100; 
                    }
                }
                return total;
            }
        }

        public decimal TotalFat
        {
            get
            {
                decimal total = 0;
                foreach (var mealProduct in MealProducts)
                {
                    var product = mealProduct.Product;
                    if (product != null)
                    {
                        total += (product.Fat * mealProduct.Quantity * mealProduct.Weight) / 100; 
                    }
                }
                return total;
            }
        }
    }
}

