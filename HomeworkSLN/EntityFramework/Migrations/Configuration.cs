namespace EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.Northwind>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFramework.Northwind context)
        {
            var category = new List<Category>
            {
                new Category {CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales"  },
                new Category {CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
                new Category {CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                new Category {CategoryName = "Dairy Products", Description = "Cheeses" },
                new Category {CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
                new Category {CategoryName = "Meat/Poultry", Description = "Prepared meats" },
                new Category {CategoryName = "Produce", Description = "Dried fruit and bean curd" },
                new Category {CategoryName = "Seafood", Description = "Seaweed and fish" }
            };
            category.ForEach(c => context.Categories.AddOrUpdate(p => p.CategoryName, c));
            context.SaveChanges();

            var region = new List<Region>
            {
                new Region {RegionDescription = "Eastern", RegionID = 1 },
                new Region {RegionDescription = "Western", RegionID = 2  },
                new Region {RegionDescription = "Northern", RegionID = 3  },
                new Region {RegionDescription = "Southern", RegionID = 4  }

            };
            region.ForEach(t => context.Regions.AddOrUpdate(p => p.RegionDescription, t));
            context.SaveChanges();

            var territory = new List<Territory>
            {
                new Territory {TerritoryDescription = "Westboro", RegionID = 1, TerritoryID = "1" },
                new Territory {TerritoryDescription = "Hollis", RegionID = 2, TerritoryID = "2" },
                new Territory {TerritoryDescription = "Columbia", RegionID = 3, TerritoryID = "3" },
                new Territory {TerritoryDescription = "Denver", RegionID = 4, TerritoryID = "4" }

            };
            territory.ForEach(t => context.Territories.AddOrUpdate(p => p.TerritoryDescription, t));
            context.SaveChanges();
        }
    }
}
