using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Alergens { get; set; }
        public int Weight { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public int TypeMealId { get; set; }
        public TypeMeal TypeMeals { get; set; }
    }
}
