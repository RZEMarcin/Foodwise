using Microsoft.AspNetCore.Mvc.Rendering;

namespace Foodwise.Models
{
    public class AddProductsViewModel
    {
        public int MealId { get; set; }
        public List<SelectListItem> ProductOptions { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Weight { get; set; }
    }
}
