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
            var HalfMoon = new BasePose { Name = "Half Moon", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = true, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/7/7b/Ardha-Chandrasana_Yoga-Asana_Nina-Mel.jpg" };
            var SeatedTwist = new BasePose { Name = "Seated Twist", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = true, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Ardha-Matsyendrasana_Yoga-Asana_Nina-Mel.jpg/800px-Ardha-Matsyendrasana_Yoga-Asana_Nina-Mel.jpg" };
            var Boat = new BasePose { Name = "Boat", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Paripurna-Navasana_Yoga-Asana_Nina-Mel.jpg/800px-Paripurna-Navasana_Yoga-Asana_Nina-Mel.jpg" };
            var BoundAngle = new BasePose { Name = "Bound Angle", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Baddha_Ko%E1%B9%87%C4%81sana-bound_angle.jpg/800px-Baddha_Ko%E1%B9%87%C4%81sana-bound_angle.jpg" };
            var Crane = new BasePose { Name = "Crane", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Bakasana_Yoga-Asana_Nina-Mel.jpg/800px-Bakasana_Yoga-Asana_Nina-Mel.jpg" };
            var Child = new BasePose { Name = "Child's Pose", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Balasana.JPG/1280px-Balasana.JPG" };
            var Cobra = new BasePose { Name = "Cobra", Info = "lorem ipsum", DurationSuggestion = 5, TwoSided = false, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Bhujangasana_Yoga-Asana_Nina-Mel.jpg/800px-Bhujangasana_Yoga-Asana_Nina-Mel.jpg" };

            context.BasePoses.AddOrUpdate(
                p => p.Name, Triangle, DownDog, Chair, HalfMoon, SeatedTwist, Boat, BoundAngle, Crane, Child, Cobra
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
