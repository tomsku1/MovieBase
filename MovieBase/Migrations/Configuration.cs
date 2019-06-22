namespace MovieBase.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieBase.DAL.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieBase.DAL.MovieContext context)
        {
            var categories = new List<Category>
             {
                 new Category { Name = "Family" },
                 new Category { Name = "Fantasy" },
                 new Category { Name = "Western" },
                 new Category { Name = "Romance" },
                 new Category { Name = "Thriller" },
                 new Category { Name = "Animated" },
                 new Category { Name = "Action" },
                 new Category { Name = "Comedy"}
                 
             };

            categories.ForEach(c => context.Categories.AddOrUpdate(m => m.Name, c));
            context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie { Name = "Man on Fire", Description="dfhdhj", CategoryID=categories.Single(c => c.Name == "Action").Id, WhenWatched=new DateTime(2015,03,13), MyRate=8  },
                new Movie { Name = "Friends", Description="luilhfj", CategoryID=categories.Single(c => c.Name == "Comedy").Id, WhenWatched=new DateTime(2018,11,21), MyRate=5  },
                new Movie { Name = "Godfather", Description="rtyhsgfxhjn", CategoryID=categories.Single(c => c.Name == "Action").Id, WhenWatched=new DateTime(2013,01,22), MyRate=8  },
                new Movie { Name = "Shrek", Description="waerg", CategoryID=categories.Single(c => c.Name == "Animated").Id, WhenWatched=new DateTime(2019,05,30), MyRate=8  },
                new Movie { Name = "Nothing Hill", Description="rjsf", CategoryID=categories.Single(c => c.Name == "Romance").Id, WhenWatched=new DateTime(2012,01,11), MyRate=8  },
                new Movie { Name = "Django", Description="fkhjfjgh", CategoryID=categories.Single(c => c.Name == "Western").Id, WhenWatched=new DateTime(2019,05,31), MyRate=4  },
                new Movie { Name = "Bridget Jones", Description="fkhjfjgh", CategoryID=categories.Single(c => c.Name == "Comedy").Id, WhenWatched=new DateTime(2017,07,12), MyRate=7  },
                new Movie { Name = "The Lion King", Description="fkhjfjgh", CategoryID=categories.Single(c => c.Name == "Animated").Id, WhenWatched=new DateTime(2018,04,09), MyRate=8  },
                new Movie { Name = "Zootopia", Description="fkhjfjgh", CategoryID=categories.Single(c => c.Name == "Animated").Id, WhenWatched=new DateTime(2017,02,04), MyRate=9  },
                new Movie { Name = "Lost", Description="fkhjfjgh", CategoryID=categories.Single(c => c.Name == "Action").Id, WhenWatched=new DateTime(2018,01,04), MyRate=5  },
                new Movie { Name = "Narcos", Description="fkhjfjgh", CategoryID=categories.Single(c => c.Name == "Action").Id, WhenWatched=new DateTime(2015,11,08), MyRate=8  }

            };

            movies.ForEach(c => context.Movies.AddOrUpdate(m => m.Name, c));
            context.SaveChanges();
        }
    }
}
