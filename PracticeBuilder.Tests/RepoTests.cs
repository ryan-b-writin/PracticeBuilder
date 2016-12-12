using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeBuilder.DAL;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using PracticeBuilder.Models;
using System.Linq;

namespace PracticeBuilder.Tests
{
    [TestClass]
    public class RepoTests
    {
        private Mock<DbSet<Yogi>> mock_yogis { get; set; }
        private Mock<DbSet<Practice>> mock_practices { get; set; }
        private Mock<DbSet<BasePose>> mock_base_poses { get; set; }
        private Mock<DbSet<UserPose>> mock_user_poses { get; set; }
        private Mock<BuilderContext> mock_context { get; set; }
        private BuilderRepo repo { get; set; }
        private List<Yogi> yogis { get; set; }
        private List<Practice> practices { get; set; }
        private List<BasePose> base_poses { get; set; }
        private List<UserPose> user_poses { get; set; }

        public void ConnectMocksToDatastore()
        {
            var query_yogis = yogis.AsQueryable();
            var query_practices = practices.AsQueryable();
            var query_base_poses = base_poses.AsQueryable();
            var query_user_poses = user_poses.AsQueryable();

            mock_yogis.As<IQueryable<Yogi>>().Setup(m => m.Provider).Returns(query_yogis.Provider);
            mock_yogis.As<IQueryable<Yogi>>().Setup(m => m.Expression).Returns(query_yogis.Expression);
            mock_yogis.As<IQueryable<Yogi>>().Setup(m => m.ElementType).Returns(query_yogis.ElementType);
            mock_yogis.As<IQueryable<Yogi>>().Setup(m => m.GetEnumerator()).Returns(() => query_yogis.GetEnumerator());

            mock_context.Setup(c => c.Yogis).Returns(mock_yogis.Object);

            mock_yogis.Setup(t => t.Add(It.IsAny<Yogi>())).Callback((Yogi a) => yogis.Add(a));
            mock_yogis.Setup(t => t.Remove(It.IsAny<Yogi>())).Callback((Yogi a) => yogis.Remove(a));
            mock_yogis.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<Yogi>>())).Callback((IEnumerable<Yogi> a) => yogis.RemoveRange(0, a.Count<Yogi>()));

            /*-------------*/

            mock_practices.As<IQueryable<Practice>>().Setup(m => m.Provider).Returns(query_practices.Provider);
            mock_practices.As<IQueryable<Practice>>().Setup(m => m.Expression).Returns(query_practices.Expression);
            mock_practices.As<IQueryable<Practice>>().Setup(m => m.ElementType).Returns(query_practices.ElementType);
            mock_practices.As<IQueryable<Practice>>().Setup(m => m.GetEnumerator()).Returns(() => query_practices.GetEnumerator());

            mock_context.Setup(c => c.Practices).Returns(mock_practices.Object);

            mock_practices.Setup(t => t.Add(It.IsAny<Practice>())).Callback((Practice a) => practices.Add(a));
            mock_practices.Setup(t => t.Remove(It.IsAny<Practice>())).Callback((Practice a) => practices.Remove(a));
            mock_practices.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<Practice>>())).Callback((IEnumerable<Practice> a) => practices.RemoveRange(0, a.Count<Practice>()));

            /*-------------*/

            mock_base_poses.As<IQueryable<BasePose>>().Setup(m => m.Provider).Returns(query_base_poses.Provider);
            mock_base_poses.As<IQueryable<BasePose>>().Setup(m => m.Expression).Returns(query_base_poses.Expression);
            mock_base_poses.As<IQueryable<BasePose>>().Setup(m => m.ElementType).Returns(query_base_poses.ElementType);
            mock_base_poses.As<IQueryable<BasePose>>().Setup(m => m.GetEnumerator()).Returns(() => query_base_poses.GetEnumerator());

            mock_context.Setup(c => c.BasePoses).Returns(mock_base_poses.Object);

            mock_base_poses.Setup(t => t.Add(It.IsAny<BasePose>())).Callback((BasePose a) => base_poses.Add(a));
            mock_base_poses.Setup(t => t.Remove(It.IsAny<BasePose>())).Callback((BasePose a) => base_poses.Remove(a));
            mock_base_poses.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<BasePose>>())).Callback((IEnumerable<BasePose> a) => base_poses.RemoveRange(0, a.Count<BasePose>()));

            /*-------------*/

            mock_user_poses.As<IQueryable<UserPose>>().Setup(m => m.Provider).Returns(query_user_poses.Provider);
            mock_user_poses.As<IQueryable<UserPose>>().Setup(m => m.Expression).Returns(query_user_poses.Expression);
            mock_user_poses.As<IQueryable<UserPose>>().Setup(m => m.ElementType).Returns(query_user_poses.ElementType);
            mock_user_poses.As<IQueryable<UserPose>>().Setup(m => m.GetEnumerator()).Returns(() => query_user_poses.GetEnumerator());

            mock_context.Setup(c => c.UserPoses).Returns(mock_user_poses.Object);

            mock_user_poses.Setup(t => t.Add(It.IsAny<UserPose>())).Callback((UserPose a) => user_poses.Add(a));
            mock_user_poses.Setup(t => t.Remove(It.IsAny<UserPose>())).Callback((UserPose a) => user_poses.Remove(a));
            mock_user_poses.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<UserPose>>())).Callback((IEnumerable<UserPose> a) => user_poses.RemoveRange(0, a.Count<UserPose>()));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<BuilderContext>();
            mock_yogis = new Mock<DbSet<Yogi>>();
            mock_practices = new Mock<DbSet<Practice>>();
            mock_base_poses = new Mock<DbSet<BasePose>>();
            mock_user_poses = new Mock<DbSet<UserPose>>();
            yogis = new List<Yogi>
            {
                new Yogi
                {
                    YogiID = 0,
                    Name = "first"
                },
                new Yogi
                {
                    YogiID = 1,
                    Name = "second"
                }
            };
            practices = new List<Practice>
            {
                new Practice
                {
                    PracticeID = 0,
                    Name = "first"
                },
                new Practice
                {
                    PracticeID = 1,
                    Name = "second"
                }
            };
            base_poses = new List<BasePose>
            {
                new BasePose
                {
                    BasePoseID = 0,
                    Name = "first",
                    TwoSided = false
                },
                new BasePose
                {
                    BasePoseID = 1,
                    Name = "second",
                    TwoSided = true
                }
            };
            user_poses = new List<UserPose>
            {
                new UserPose
                {
                    UserPoseID = 0,
                    Name = "first",
                    Reference = new BasePose {BasePoseID = 2, Name = "Downward Dog", TwoSided = false },
                    Duration = 5,
                    PracticeOrder = 0
                },
                new UserPose
                {
                    UserPoseID = 0,
                    Name = "second",
                    Reference = new BasePose {BasePoseID = 3, Name = "Triangle", TwoSided = true },
                    Duration = 3,
                    PracticeOrder = 1
                }
            };
            repo = new BuilderRepo(mock_context.Object);
        }
        [TestCleanup]
        public void Teardown()
        {
            repo = null;
        }
        [TestMethod]
        public void RepoCanCreateInstanceOfRepo()
        {
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void RepoCanFindYogi()
        {
            ConnectMocksToDatastore();
            Yogi second_yogi = repo.FindYogi("second");

            Assert.AreEqual("second", second_yogi.Name);
        }
        [TestMethod]
        public void RepoCanAddYogi()
        {
            Assert.IsNotNull(null);
        }
        [TestMethod]
        public void RepoCanAddNewPractice()
        {
            ConnectMocksToDatastore();
            repo.AddNewPractice("first", "my new practice");
            Yogi found_yogi = repo.FindYogi("first");
            Practice found_practice = repo.SearchYogiForPractice("first", "my new practice");

            Assert.IsNotNull(found_practice);
        }
        [TestMethod]
        public void RepoCanRemovePractice()
        {
            Assert.IsNotNull(null);
        }
        [TestMethod]
        public void RepoCanGenerateUserPoseFromBasePose()
        {
            Assert.IsNotNull(null);
        }
        [TestMethod]
        public void RepoCanRemoveUserPose()
        {
            Assert.IsNotNull(null);
        }
        [TestMethod]
        public void RepoCanReorderUserPoses()
        {
            Assert.IsNotNull(null);
        }
        [TestMethod]
        public void RepoCanEditPoses()
        {
            Assert.IsNotNull(null);
        }

    }

}
