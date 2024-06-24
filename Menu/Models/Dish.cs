namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; } 
        public double Price { get; set; }

        // Creating relationship between Dish and DishIngredient model
        public List<DishIngredient> DishIngredients { get; set; } 
    }
}
