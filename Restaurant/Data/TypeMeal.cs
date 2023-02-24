namespace Restaurant.Data
{
    public class TypeMeal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterON { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
