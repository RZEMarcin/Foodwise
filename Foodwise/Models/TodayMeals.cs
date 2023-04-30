using System.ComponentModel.DataAnnotations;

namespace Foodwise.Models
{
    public class TodayMeals 
    {
        public int Id { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<Meal> ?Meals { get; set; }
    }
}
