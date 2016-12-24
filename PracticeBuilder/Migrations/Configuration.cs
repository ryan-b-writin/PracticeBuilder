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
                Info = "Trikonasana is usually performed in two parts, facing left, and then facing right. The practitioner begins standing with the feet one leg-length apart, knees unbent, turns the right foot completely to the outside and the left foot less than 45 degrees to the inside, keeping the heels in line with the hips. The arms are spread out to the sides, parallel to the ground, palms facing down; the trunk is extended as far as is comfortable to the right, while the arms remain parallel to the floor. Once the trunk is fully extended to the right, the right arm is dropped so that the right hand reaches the shin (or a block or on the floor) to the front (left side) of the right foot, with the palm down if flexed. The left arm is extended vertically, and the spine and trunk are gently twisted counterclockwise (i.e., upwards to the left, since they're roughly parallel to the floor), using the extended arms as a lever, while the spine remains parallel to the ground. The arms are stretched away from one another, and the head is often turned to gaze at the left thumb, slightly intensifying the spinal twist. Returning to standing, the bend is then repeated to the left.",
                Name = "Triangle",
                TwoSided = true,
                ImageURL = "https://upload.wikimedia.org/wikipedia/commons/9/9d/Trikonasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var DownwardDog = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The preparatory position is with the hands and knees on the floor, hands under the shoulders, fingers spread wide, knees under the hips and typically about seven inches (17 cm) apart, with the spine straightened and relaxed. On a deep exhale, the hips are pushed toward the ceiling, the body forming an inverted V - shape.The back is straight with the front ribs tucked in. The legs are straight with the heels reaching to the floor.The hands are open like starfish, keeping the forefinger and thumb pressing down on the floor / mat.The arms are straight, with the inner elbows turning towards the ceiling.If one has the tendency to hyper extend elbows, keeping a microbend to the elbows prevents taking the weight in the joints.Turning the elbows up towards the ceiling will engage the triceps and build strength.The shoulders are wide and relaxed.Line up the ears with the inner arms which keeps the neck lengthened.The hands are shoulder width apart and feet remain hip - width apart.If the hamstrings are very strong or tight, the knees are bent to allow the spine to lengthen fully.The navel is drawn in towards the spine, keeping the core engaged. The hips move up and back. Focus is on the breath while holding the asana, with deep, steady inhalation and exhalation creating a flow of energy through the body. On an exhale, the practitioner releases onto the hands and knees and rests in balasana.",
                Name = "Downward Dog",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Downwarddog.JPG#/media/File:Downwarddog.JPG"
            };
            var HalfMoon = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Balance on one leg and hand. Slowly lift upper body and other leg, then arm, then gaze",
                Name = "Half Moon",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Ardha-Chandrasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Ardha-Chandrasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Boat = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The body comes into a V-shape, balancing entirely on the buttocks. In different variations and traditions, the arms legs and torso may take different positions. In Paripurna Navasana, the legs and back are lifted high and arms extend forward and parallel to the ground. In Arda Navasana, hands interlace behind the neck and both back and shoulders are closer to the ground.",
                Name = "Boat",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Paripurna-Navasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Paripurna-Navasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var BoundAngle = new BasePose
            {
                DurationSuggestion = 5,
                Info = "From sitting position with both the legs outstretched forward, hands by the sides, palms resting on the ground, fingers together pointing forward, the legs are hinged at the knees so the soles of the feet meet. The legs are grasped at the ankles and folded more until the heels reach the perineum. The knees remain on the ground, the body erect and the gaze in front. The asana is held before coming back to the starting position. The thighs are stretched with care.",
                Name = "Bound Angle",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Baddha_Ko%E1%B9%87%C4%81sana-bound_angle.jpg#/media/File:Baddha_Ko%E1%B9%87%C4%81sana-bound_angle.jpg"
            };
            var Crow = new BasePose
            {
                DurationSuggestion = 5,
                Info = "This asana is considered an arm balance. According to B.K.S. Iyengar there are two techniques for entering into this balance. The simple method of achieving it is by pushing up from a crouching position. The advanced method is to drop down from a head stand.",
                Name = "Crow",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Bakasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Bakasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Child = new BasePose
            {
                DurationSuggestion = 5,
                Info = "In this asana, the body faces the floor in a fetal position. The knees and hips are bent with the shins on the floor. The chest can rest either on the knees or the knees can be spread to about the width of a yoga mat, allowing the chest to go between the knees. The head is stretched forward towards the ground - the forehead may touch the ground. The arms may be stretched forward in front of the head or backwards towards the feet.",
                Name = "Child's Pose",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Balasana.JPG#/media/File:Balasana.JPG"
            };
            var Cobra = new BasePose
            {
                DurationSuggestion = 5,
                Info = "From a prone position with palms and legs on the floor, the chest is lifted.",
                Name = "Cobra",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Bhujangasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Bhujangasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var WildThing = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Be careful while doing this pose if you have wrist, shoulder, elbow or any spinal cord injuries",
                Name = "Wild Thing",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Mr-yoga-wild-thing.jpg#/media/File:Mr-yoga-wild-thing.jpg"
            };
            var Chaturanga = new BasePose
            {
                DurationSuggestion = 5,
                Info = "In Chaturanga the hands and feet are on the floor, supporting the body, which is parallel to and lowered toward, but not touching, the floor. It looks much like a push up, but with the hands quite low (just above the pelvis), and the elbows kept in along the sides of the body.",
                Name = "Chaturanga",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Chaturanga-Dandasana_low_Yoga-Asana_Nina-Mel.jpg#/media/File:Chaturanga-Dandasana_low_Yoga-Asana_Nina-Mel.jpg"
            };
            var Wheel = new BasePose
            {
                DurationSuggestion = 5,
                Info = "In the general form of the asana, the practitioner has hands and feet on the floor, and the abdomen arches up toward the sky. Wheel Pose may be entered from a supine position or through a less rigorous supine backbend, such as Setu Bandha Sarvangasana (Bridge Pose). Some advanced practitioners can move into Wheel Pose by 'dropping back' from Tadasana (Mountain Pose), or by standing with the back to a wall, reaching arms overhead and walking hands down the wall toward the floor. Advanced practitioners may also follow wheel with any of its variations (listed below), or with other backbends, such as Dwi Pada Viparita Dandasana, or by pushing back up to stand in Tadasana.",
                Name = "Wheel",
                TwoSided = false,
                ImageURL = "https://en.wikipedia.org/wiki/Urdhva_Dhanurasana_(Chakrasana)#/media/File:Chakrasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Staff = new BasePose
            {
                DurationSuggestion = 5,
                Info = "To achieve this asana, begin in a seated position with the legs extended forward. The palms or the fingertips (if the palms don't reach) should be rested on either side of the body. The upper-body should be extending upward through the crown of the head, and the back should be completely perpendicular to the ground (as though sitting against a wall). If this is not possible, one may want to use a block underneath one's sitting bones to reduce the intensity in the hamstring muscles. The entire core should be engaged and ujjayi breath active throughout this asana. The legs should be squeezing together, and the toes should be pointing inwards toward the body. It may even be possible to create space between the heels and the ground by activating the leg muscles.",
                Name = "Staff",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Dandasana_yoga_posture.jpg#/media/File:Dandasana_yoga_posture.jpg"
            };
            var Bow = new BasePose
            {
                DurationSuggestion = 5,
                Info = "First the practitioner should lie prone and grasp the feet to lift the leg and chest to form a bow. Remain in this position for some time and then return to the previous position.",
                Name = "Bow",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Dhanurasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Dhanurasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Eagle = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Usually Garudasana is performed with a straight spine, so that it shows the mythical bird Garuda. But most of people make their spine round, which could be interpreted as a mistake or a variation.",
                Name = "Eagle",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Garudasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Garudasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var Plough = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The practitioner lies on the floor, lifts the legs, and then places them behind the head. Experienced practitioners may enter Halasana from a standing position by tucking chin to chest, placing hands on the floor, walking the feet towards the hands and bending at the elbows to lower shoulders to the floor.",
                Name = "Plough",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Halasana.jpg#/media/File:Halasana.jpg"
            };
            var Crescent = new BasePose
            {
                DurationSuggestion = 5,
                Info = "This pose has the following benefits: it stretched the side of the body, promotes spinal flexibility and balance.",
                Name = "Crescent",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Mr-yoga-side_bend.jpg#/media/File:Mr-yoga-side_bend.jpg"
            };
            var Fish = new BasePose
            {
                DurationSuggestion = 5,
                Info = "The asana is a backbend, where the practitioner lies on his or her back and lifts the heart (anahata) chakra by rising up on the elbows and drawing the shoulders back. The neck is lengthened, and the crown of the head Sahasrara chakra is 'pointed' toward the 'wall' behind the practitioner. As the arch of the back deepens with practice, and the heart and throat open further, the top of the head may brush the ground, but no weight should rest upon it.",
                Name = "Fish",
                TwoSided = false,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Matsyasana_Yoga-Asana_Nina-Mel.jpg#/media/File:Matsyasana_Yoga-Asana_Nina-Mel.jpg"
            };
            var WarriorI = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Use of bandhas increase the stability of the body in this asana. Both mula bandha (root lock) and uddiyana bandha (abdominal lock) should be engaged. This creates an axial extension in the spine which assists in supporting in the torso as the chest is brought up and back.",
                Name = "Warrior I",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Virabhadrasana_I_-_Warrior_Pose_I.jpg#/media/File:Virabhadrasana_I_-_Warrior_Pose_I.jpg"
            };
            var WarriorII = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Use of bandhas increase the stability of the body in this asana. Both mula bandha (root lock) and uddiyana bandha (abdominal lock) should be engaged. This creates an axial extension in the spine which assists in supporting in the torso as the chest is brought up and back.",
                Name = "Warrior II",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Warrior_II.jpg#/media/File:Warrior_II.jpg"
            };
            var WarriorIII = new BasePose
            {
                DurationSuggestion = 5,
                Info = "Engage the floating leg to help with balance",
                Name = "Warrior III",
                TwoSided = true,
                ImageURL = "https://commons.wikimedia.org/wiki/File:Tuladandasana.jpg#/media/File:Tuladandasana.jpg"
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
