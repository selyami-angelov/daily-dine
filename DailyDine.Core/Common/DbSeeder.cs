using DailyDine.Infrastructure.Data;
using DailyDine.Infrastructure.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDine.Core.Common
{
    public static class DbSeeder
    {
        public static void SeedProducts(ApplicationDbContext context)
        {
            // Check if the database already contains products
            if (context.Set<Product>().Any())
            {
                return; // Database already seeded, exit the method
            }


            var categories = new List<Category>
            {
                new Category()
                {
                    Name = "Salads"
                },
                new Category()
                {
                    Name = "Soups"
                },
                new Category()
                {
                    Name = "Desserts"
                },
                new Category()
                {
                    Name = "Main"
                }
            };

            // Add the categories to the context and save changes
            context.Set<Category>().AddRange(categories);
            context.SaveChanges();


            var user = context.Set<ApplicationUser>().Find("f03bda2d-b1b0-4b3d-9c5d-357ceac0ea71");

            // Create a list of example products
            var products = new List<Product>
        {
            // Salads
            new Product
            {
                Name = "Greek Salad",
                Description = "Fresh mixed greens with tomatoes, cucumbers, olives, feta cheese, and Greek dressing.",
                Price = 9.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Caesar Salad",
                Description = "Crisp romaine lettuce with Parmesan cheese, croutons, and Caesar dressing.",
                Price = 8.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Caprese Salad",
                Description = "Sliced tomatoes, fresh mozzarella cheese, and basil drizzled with balsamic glaze.",
                Price = 10.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Cobb Salad",
                Description = "Grilled chicken, avocado, bacon, hard-boiled eggs, tomatoes, and blue cheese on a bed of mixed greens.",
                Price = 11.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Spinach Salad",
                Description = "Baby spinach leaves with strawberries, almonds, goat cheese, and a raspberry vinaigrette.",
                Price = 9.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Waldorf Salad",
                Description = "Mixed greens with apples, grapes, walnuts, and a creamy dressing.",
                Price = 8.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Quinoa Salad",
                Description = "Quinoa mixed with diced vegetables, herbs, and a lemon vinaigrette.",
                Price = 10.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Asian Sesame Salad",
                Description = "Mixed greens, mandarin oranges, crispy noodles, and a sesame ginger dressing.",
                Price = 9.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Chicken Caesar Salad",
                Description = "Grilled chicken, romaine lettuce, Parmesan cheese, croutons, and Caesar dressing.",
                Price = 10.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Watermelon Feta Salad",
                Description = "Fresh watermelon chunks, feta cheese, mint leaves, and a tangy citrus dressing.",
                Price = 9.99M,
                Category = categories[0],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[0].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },

             // Soups
            new Product
            {
                Name = "Chicken Noodle Soup",
                Description = "Classic soup made with tender chicken, egg noodles, carrots, and celery in a flavorful broth.",
                Price = 6.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Tomato Basil Soup",
                Description = "Creamy tomato soup infused with aromatic basil leaves.",
                Price = 5.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Clam Chowder",
                Description = "Rich and creamy soup loaded with tender clams, potatoes, and aromatic spices.",
                Price = 8.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
            new Product
            {
                Name = "Minestrone Soup",
                Description = "Hearty Italian vegetable soup with beans, pasta, and fresh herbs.",
                Price = 7.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                new Product
            {
                Name = "Butternut Squash Soup",
                Description = "Smooth and velvety soup made from roasted butternut squash, garnished with a drizzle of cream.",
                Price = 6.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                 new Product
            {
                Name = "French Onion Soup",
                Description = "Savory soup with caramelized onions, topped with melted cheese and toasted bread.",
                Price = 8.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                  new Product
            {
                Name = "Lentil Soup",
                Description = "Nutritious soup made with lentils, vegetables, and aromatic spices.",
                Price = 6.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                   new Product
            {
                Name = "Broccoli Cheddar Soup",
                Description = "Creamy soup with tender broccoli florets and melted cheddar cheese.",
                Price = 7.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                    new Product
            {
                Name = "Mushroom Soup",
                Description = "Earthy and flavorful soup made with fresh mushrooms, herbs, and a touch of cream.",
                Price = 6.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                     new Product
            {
                Name = "Corn Chowder",
                Description = "Creamy soup made with sweet corn kernels, potatoes, and smoky bacon.",
                Price = 7.99M,
                Category = categories[1],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[1].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
             
            // Desserts
            new Product
            {
                Name = "Chocolate Brownie",
                Description = "Rich and fudgy chocolate brownie topped with a scoop of vanilla ice cream and drizzled with chocolate sauce.",
                Price = 5.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
             new Product
            {
                Name = "New York Cheesecake",
                Description = "Classic creamy cheesecake with a graham cracker crust, served plain or with a choice of fruit topping.",
                Price = 7.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
              new Product
            {
                Name = "Apple Pie",
                Description = "Traditional homemade apple pie with a flaky crust, filled with cinnamon-spiced apples.",
                Price = 6.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
               new Product
            {
                Name = "Tiramisu",
                Description = "Layers of espresso-soaked ladyfingers and creamy mascarpone cheese, dusted with cocoa powder.",
                Price = 8.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                new Product
            {
                Name = "Chocolate Mousse",
                Description = "Light and airy chocolate mousse served in a glass, garnished with whipped cream and chocolate shavings.",
                Price = 6.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                 new Product
            {
                Name = "Fruit Tart",
                Description = "Buttery tart shell filled with vanilla custard and topped with a colorful assortment of fresh fruits.",
                Price = 7.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                  new Product
            {
                Name = "Creme Brulee",
                Description = "Classic French dessert featuring a silky vanilla custard topped with a caramelized sugar crust.",
                Price = 7.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                   new Product
            {
                Name = "Red Velvet Cake",
                Description = "Moist and velvety red-colored cake layered with cream cheese frosting and adorned with cake crumbs.",
                Price = 6.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                    new Product
            {
                Name = "Panna Cotta",
                Description = "Smooth and creamy Italian dessert made with sweetened cream and flavored with vanilla or other infusions.",
                Price = 7.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                     new Product
            {
                Name = "Mixed Berry Parfait",
                Description = "Layers of fresh berries, yogurt, and granola, served in a glass for a delightful and healthy dessert.",
                Price = 6.99M,
                Category = categories[2],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[2].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },

            // Entrees/Main Courses
            
            new Product
            {
                Name = "Grilled Salmon",
                Description = "Freshly grilled salmon fillet served with a lemon butter sauce, accompanied by seasonal vegetables and rice pilaf.",
                Price = 16.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
             new Product
            {
                Name = "Steak Frites",
                Description = "Grilled sirloin steak cooked to perfection, served with a side of crispy French fries and a tangy steak sauce.",
                Price = 18.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
              new Product
            {
                Name = "Chicken Parmesan",
                Description = "Breaded chicken breast topped with marinara sauce and melted mozzarella cheese, served with spaghetti or a side of your choice.",
                Price = 14.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
               new Product
            {
                Name = "Vegetable Stir-Fry",
                Description = "A medley of fresh vegetables stir-fried in a savory sauce, served over steamed rice or noodles.",
                Price = 12.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                new Product
            {
                Name = "Eggplant Parmesan",
                Description = "Breaded and fried eggplant slices layered with marinara sauce and melted cheese, served with a side of pasta or salad.",
                Price = 13.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                 new Product
            {
                Name = "Shrimp Scampi",
                Description = "Succulent shrimp sautéed in a garlic and butter sauce, served over a bed of linguine pasta.",
                Price = 17.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                  new Product
            {
                Name = "Beef Stroganoff",
                Description = "Tender strips of beef cooked in a creamy mushroom sauce, served over egg noodles or mashed potatoes.",
                Price = 15.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                   new Product
            {
                Name = "Spinach Ricotta Chicken",
                Description = "Chicken breast stuffed with a flavorful mixture of spinach and ricotta cheese, served with a side of roasted potatoes and vegetables.",
                Price = 16.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                    new Product
            {
                Name = "Vegetable Lasagna",
                Description = "Layers of pasta, fresh vegetables, marinara sauce, and melted cheese, baked to perfection.",
                Price = 13.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },
                     new Product
            {
                Name = "Thai Red Curry with Tofu",
                Description = "A spicy and aromatic Thai curry made with tofu, mixed vegetables, and coconut milk, served with steamed jasmine rice.",
                Price = 14.99M,
                Category = categories[3],
                CreatedDate = DateTime.Now,
                CreatedById = user.Id,
                CategoryId = categories[3].Id,
                EditedById= user.Id,
                EditedDate = DateTime.Now,
                CreatedBy = user,
                EditedBy = user,

            },

        };

            // Add the products to the context and save changes
            context.Set<Product>().AddRange(products);
            context.SaveChanges();
        }
    }
}
