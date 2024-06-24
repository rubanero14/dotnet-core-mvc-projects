namespace Menu.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // Creating relationship between Ingredient and DishIngredient model
        public List<DishIngredient> DishIngredients { get; set; }
    }
}
