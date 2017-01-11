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
            var Triangle = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin standing at the top of your mat with your feet hip-distance apart and your arms at your sides. Step your feet wide apart, about 4 to 5 feet. Turn your right foot out 90 degrees so your toes are pointing to the top of the mat. Pivot your left foot slightly inwards.",
                Name = "Triangle",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var DownwardDog = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin on your hands and knees. Stretch your elbows and relax your upper back. Spread your fingers wide and press firmly through your palms and knuckles. Exhale as you tuck your toes and lift your knees off the floor. Press the floor away from you as you lift through your pelvis.",
                Name = "Downward Dog",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Ado-muka-shvanasana.jpg/100px-Ado-muka-shvanasana.jpg"
            };
            var HalfMoon = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Balance on one leg and hand. Slowly lift upper body and other leg, then arm, then gaze",
                Name = "Half Moon",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Ardha-Chandrasana_Yoga-Asana_Nina-Mel.jpg/100px-Ardha-Chandrasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Boat = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The body comes into a V-shape, balancing entirely on the buttocks.",
                Name = "Boat",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/df/Ardha_Nav%C4%81sana-half-boat.jpg/100px-Ardha_Nav%C4%81sana-half-boat.jpg"
            };
            var BoundAngle = new BasePose
            {
                DurationSuggestion = 5,
                Info = "From sitting position with both the legs outstretched forward, hands by the sides, palms resting on the ground, fingers together pointing forward, the legs are hinged at the knees so the soles of the feet meet. The legs are grasped at the ankles and folded more until the heels reach the perineum. The knees remain on the ground, the body erect and the gaze in front. ",
                Name = "Bound Angle",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Baddha_Ko%E1%B9%87%C4%81sana-bound_angle.jpg/100px-Baddha_Ko%E1%B9%87%C4%81sana-bound_angle.jpg"
            };
            var Crow = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin by standing at the top of your mat in Mountain Pose (Tadasana) with your arms at your sides. Bend your knees and lower your hips, coming into a squat. Drop your torso slightly forward and bring your upper arms to the inside of your knees.",
                Name = "Crow",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Bakasana_Yoga-Asana_Nina-Mel.jpg/100px-Bakasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Child = new BasePose
            {
                DurationSuggestion = 5,
                Info = "In this asana, the body faces the floor in a fetal position. The knees and hips are bent with the shins on the floor. The chest can rest either on the knees or the knees can be spread to about the width of a yoga mat, allowing the chest to go between the knees.",
                Name = "Child's Pose",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Balasana.JPG/100px-Balasana.JPG"
            };
            var Cobra = new BasePose
            {
                DurationSuggestion = 5,
                Info = "From a prone position with palms and legs on the floor, the chest is lifted.",
                Name = "Cobra",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Bhujangasana_Yoga-Asana_Nina-Mel.jpg/100px-Bhujangasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var WildThing = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Start in Downward-Facing Dog. Bring your weight into your right hand and roll onto the outer edge of your right foot like Side Plank Pose.",
                Name = "Wild Thing",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Mr-yoga-wild-thing.jpg/220px-Mr-yoga-wild-thing.jpg"
            };
            var Chaturanga = new BasePose
            {
                DurationSuggestion = 5,
                Info = "In Chaturanga the hands and feet are on the floor, supporting the body, which is parallel to and lowered toward, but not touching, the floor. It looks much like a push up, but with the hands quite low (just above the pelvis), and the elbows kept in along the sides of the body.",
                Name = "Chaturanga",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Chaturanga-Dandasana_low_Yoga-Asana_Nina-Mel.jpg/100px-Chaturanga-Dandasana_low_Yoga-Asana_Nina-Mel.jpg"
            };
            var Wheel = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The practitioner has hands and feet on the floor, and the abdomen arches up toward the sky.",
                Name = "Wheel",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/df/Chakrasana_Yoga-Asana_Nina-Mel.jpg/100px-Chakrasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Staff = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin in a seated position with the legs extended forward. The palms or the fingertips should be rested on either side of the body. The upper-body should be extending upward through the crown of the head, and the back should be completely perpendicular to the ground (as though sitting against a wall).",
                Name = "Staff",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/Dandasana_yoga_posture.jpg/100px-Dandasana_yoga_posture.jpg"
            };
            var Bow = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Lie prone and grasp the feet to lift the leg and chest to form a bow.",
                Name = "Bow",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Dhanurasana_Yoga-Asana_Nina-Mel.jpg/100px-Dhanurasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Eagle = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin standing in Mountain Pose (Tadasana), with your arms at your sides. Bend your knees. Extend your arms straight in front of your body. Bend your elbows, and then raise your forearms perpendicular to the floor. Square your hips and chest to the front wall. Gaze at the tips of your thumbs.",
                Name = "Eagle",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Garudasana_Yoga-Asana_Nina-Mel.jpg/100px-Garudasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Plough = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The practitioner lies on the floor, lifts the legs, and then places them behind the head.",
                Name = "Plough",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a2/Halasana.jpg/100px-Halasana.jpg"
            };
            var Crescent = new BasePose
            {
                DurationSuggestion = 5,
                Info = "From Mountain pose, interlace the fingers, pointing the index finger up over the head, press the feet into the floor and reach the fingers and crown up while relaxing the shoulders down and back. Exhale and press the right hip out to the side, arching over to the left. Keep the feet grounded and the legs and buttocks engaged. Reach up and out through the fingers and crown.",
                Name = "Crescent",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Mr-yoga-side_bend.jpg/220px-Mr-yoga-side_bend.jpg"
            };
            var Fish = new BasePose
            {
                DurationSuggestion = 5,
                Info = "This is a backbend, where the practitioner lies on his or her back and lifts the heart by rising up on the elbows and drawing the shoulders back. The neck is lengthened, and the crown of the head is 'pointed' toward the 'wall' behind the practitioner.",
                Name = "Fish",
                TwoSided = false,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Matsyasana_Yoga-Asana_Nina-Mel.jpg/100px-Matsyasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var WarriorI = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin in Mountain Pose (Tadasana), standing with your feet hip-distance apart and your arms at your sides. Exhale as you step your feet wide apart, about 4 to 5 feet. Turn your right foot out 90 degrees, so your toes are pointing to the top of the mat. Pivot your left foot inwards at a 45-degree angle.",
                Name = "Warrior I",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/a/a6/Virabhadrasana_I_-_Warrior_Pose_I.jpg"
            };
            var WarriorII = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin in Mountain Pose (Tadasana), standing with your feet hip-distance apart and your arms at your sides. Exhale as you step your feet wide apart, about 4 to 5 feet. Turn your right foot out 90 degrees, so your toes are pointing to the top of the mat. Pivot your left foot slightly inwards.",
                Name = "Warrior II",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/Warrior_II.jpg/800px-Warrior_II.jpg"
            };
            var WarriorIII = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Begin standing in Mountain Pose (Tadasana) with your feet hip-distance apart and your arms at your sides. Turn to the left and step your feet wide apart, about 4 to 5 feet. Bend your right knee over your right ankle so your shin is perpendicular to the floor. Press your weight into your right foot.",
                Name = "Warrior III",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Tuladandasana.jpg/100px-Tuladandasana.jpg"
            };


            context.BasePoses.AddOrUpdate(
                p => p.Name,
                Triangle,
                WarriorI,
                WarriorII,
                WarriorIII,
                DownwardDog,
                HalfMoon,
                Boat,
                BoundAngle,
                Crow,
                Child,
                Cobra,
                WildThing,
                Chaturanga,
                Wheel,
                Staff,
                Bow,
                Eagle,
                Plough,
                Crescent,
                Fish);
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
