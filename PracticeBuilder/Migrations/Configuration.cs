namespace PracticeBuilder.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PracticeBuilder.DAL.BuilderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PracticeBuilder.DAL.BuilderContext context)
        {
            var Triangle = new BasePose { Name = "Triangle", Info = "lorem ipsum", DurationSuggestion = 3, TwoSided = true, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg" };
            var DownDog = new BasePose { Name = "Downward Dog", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/d/d3/Downwarddog.JPG" };
            var Chair = new BasePose { Name = "Chair", Info = "lorem ipsum", DurationSuggestion = 3, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/59/Utkatasana_Yoga-Asana_Nina-Mel.jpg" };
            context.BasePoses.AddOrUpdate(
                p => p.Name, Triangle, DownDog, Chair
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
