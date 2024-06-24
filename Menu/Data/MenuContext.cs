using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify the relations between dish model and ingredient model
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishID,
                di.IngredientID,
            });

            // Specify the relations between dish model and DishIngredient model
            // One dish to many DishIngredient relationships
            modelBuilder
                .Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishID);

            // Specify the relations between ingredient model and DishIngredient model
            // One ingredient to many DishIngredient relationships
            modelBuilder
                .Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientID);

            // Test/Mock data to test insert into database upon creation
            // Adding Dishes to the database
            modelBuilder.Entity<Dish>().HasData(
                new Dish 
                { 
                   Id = 1, 
                   Name = "Pizza Neapolitana",
                   ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSenWY1zGZX5wjVw5PJVZF2D7WEz5Z4Dkq11w&s",
                   Price = 7.99
                }
            );

            // Adding Ingredients to the database
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Mozarella Cheese" },
                new Ingredient { Id = 2, Name = "Tomato Sauce" },
                new Ingredient { Id = 3, Name = "Dough" },
                new Ingredient { Id = 4, Name = "Basil" }
            );

            // Adding both Dish and Ingredients to DishIngredients model and to the database
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishID = 1, IngredientID = 1 },
                new DishIngredient { DishID = 1, IngredientID = 2 },
                new DishIngredient { DishID = 1, IngredientID = 3 },
                new DishIngredient { DishID = 1, IngredientID = 4 }
            );

            base.OnModelCreating(modelBuilder);
        }

        // Creating 3 DB Sets to connect the 3 instances for each model we created
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
