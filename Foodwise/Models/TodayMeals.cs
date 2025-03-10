using System.ComponentModel.DataAnnotations;

namespace Foodwise.Models
{
    public class TodayMeals
    {
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<Meal>? Meals { get; set; }

        public decimal TodayTotalCalories
        {
            get
            {
                decimal total = 0;
                foreach (var meal in Meals)
                {
                    total += meal.TotalCalories;
                }
                return total;

            }
        }
        public decimal TodayTotalProtein
        {
            get
            {
                decimal total = 0;
                foreach (var meal in Meals)
                {
                    total += meal.TotalProtein;
                }
                return total;
            }
        }
        public decimal TodayTotalCarbohydrates
        {
            get
            {
                decimal total = 0;
                foreach (var meal in Meals)
                {
                    total += meal.TotalCarbs;
                }
                return total;
            }
        }
        public decimal TodayTotalFat
        {
            get
            {
                decimal total = 0;
                foreach (var meal in Meals)
                {
                    total += meal.TotalFat;
                }
                return total;
            }
        }

    }
}
