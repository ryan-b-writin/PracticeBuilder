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
                    Name = "first",
                    Practices = new List<Practice>()
                },
                new Yogi
                {
                    YogiID = 1,
                    Name = "second",
                    Practices = new List<Practice>
                    {
                        new Practice
                        {
                            PracticeID = 2,
                            Name = "Sample Practice",
                            Poses = new List<UserPose>
                            {
                                new UserPose
                                {
                                    UserPoseID = 2,
                                    Name = "Sample User Pose",
                                    Reference = new BasePose
                                    {
                                        BasePoseID = 2,
                                        Name = "Sample Base Pose",
                                        TwoSided = true,
                                        DurationSuggestion = 3
                                    },
                                    Duration = 5,
                                    PracticeOrder = 0  
                                },
                                new UserPose
                                {
                                    UserPoseID = 3,
                                    Name = "Sample User Pose2",
                                    Reference = new BasePose
                                    {
                                        BasePoseID = 3,
                                        Name = "Sample Base Pose2",
                                        TwoSided = true,
                                        DurationSuggestion = 4
                                    },
                                    Duration = 4,
                                    PracticeOrder = 1
                                },
                                new UserPose
                                {
                                    UserPoseID = 4,
                                    Name = "Sample User Pose3",
                                    Reference = new BasePose
                                    {
                                        BasePoseID = 4,
                                        Name = "Sample Base Pose3",
                                        TwoSided = true,
                                        DurationSuggestion = 2
                                    },
                                    Duration = 6,
                                    PracticeOrder = 2
                                }
                            }
                        },
                        new Practice
                        {
                            PracticeID = 3,
                            Name = "Sample Practice 2"
                        },
                        new Practice
                        {
                            PracticeID = 4,
                            Name = "Sample Practice 3"
                        }
                    }
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
                    TwoSided = false,
                    DurationSuggestion = 3
                },
                new BasePose
                {
                    BasePoseID = 1,
                    Name = "second",
                    TwoSided = true,
                    DurationSuggestion = 5
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
        public void RepoCanAddNewPractice()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("first");
            PracticePost ppost = new PracticePost { practiceName = "my new practice" };
            repo.AddNewPractice(found_yogi, ppost);
            Practice found_practice = repo.SearchYogiForPractice(found_yogi, "my new practice");

            Assert.IsNotNull(found_practice);
        }
        [TestMethod]
        public void RepoEnsureMockYogiHasThreePractices()
        {
            ConnectMocksToDatastore();
            Yogi Test_yogi = repo.FindYogi("second");
            Assert.AreEqual(3, Test_yogi.Practices.ToList().Count);
        }
        [TestMethod]
        public void RepoCanRemovePractice()
        {
            ConnectMocksToDatastore();

            Yogi Test_yogi = repo.FindYogi("second");

            repo.RemovePracticeFromYogi(Test_yogi, "Sample Practice");

            Assert.AreEqual(2, Test_yogi.Practices.ToList().Count);
        }
        [TestMethod]
        public void RepoCanGenerateUserPoseFromBasePose()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            PosePost pose_post = new PosePost { practiceName = "Sample Practice", poseName = "first" };
            repo.NewUserPose(found_yogi, pose_post);

            Practice found_practice = repo.SearchYogiForPractice(found_yogi,pose_post.practiceName);
            UserPose found_user_pose = repo.FindUserPose(found_practice, pose_post.poseName);

            Assert.IsNotNull(found_user_pose);
        }
        [TestMethod]
        public void RepoEnsureMockYogiHasBasePoseToDelete()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            Practice found_practice = repo.SearchYogiForPractice(found_yogi, "Sample Practice");

            int expected_num_of_poses = 3;
            int actual_num_of_poses = found_practice.Poses.ToList().Count;

            Assert.AreEqual(expected_num_of_poses, actual_num_of_poses);

        }
        [TestMethod]
        public void RepoCanRemoveUserPose()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            Practice found_practice = repo.SearchYogiForPractice(found_yogi, "Sample Practice");
            PosePost pose_post = new PosePost { poseName = "Sample User Pose", practiceName = "Sample Practice" };
            repo.DeletePose(found_yogi, pose_post);

            int expected_num_of_poses = 2;
            int actual_num_of_poses = found_practice.Poses.ToList().Count;

            Assert.AreEqual(expected_num_of_poses, actual_num_of_poses);

        }
        [TestMethod]
        public void RepoCanFindBasePose()
        {
            ConnectMocksToDatastore();
            BasePose test_pose = new BasePose
            {
                Name = "testPose",
                DurationSuggestion = 4,
                Info = "test info",
                TwoSided = false
            };
            base_poses.Add(test_pose);

            BasePose found_pose = repo.FindBasePose("testPose");

            Assert.AreEqual(test_pose, found_pose);

        }
        /*[TestMethod]
        public void RepoEnsureMockPosesInOriginalOrder()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            Practice found_practice = repo.SearchYogiForPractice("second", "Sample Practice");
            UserPose found_pose = repo.FindUserPose(found_practice, "Sample User Pose");
            UserPose found_pose2 = repo.FindUserPose(found_practice, "Sample User Pose2");
            UserPose found_pose3 = repo.FindUserPose(found_practice, "Sample User Pose3");
            Assert.AreEqual(found_pose.PracticeOrder, 0);
            Assert.AreEqual(found_pose.PracticeOrder, 1);
            Assert.AreEqual(found_pose.PracticeOrder, 2);

        }*/
        /*[TestMethod]
        public void RepoCanReorderPoses()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            Practice found_practice = repo.SearchYogiForPractice("second", "Sample Practice");
            UserPose found_pose = repo.FindUserPose(found_practice, "Sample User Pose");
            UserPose found_pose2 = repo.FindUserPose(found_practice, "Sample User Pose2");
            UserPose found_pose3 = repo.FindUserPose(found_practice, "Sample User Pose3");

            repo.MovePose(found_practice, found_pose, 2);

            Assert.AreEqual(found_pose.PracticeOrder, 2);
            Assert.AreEqual(found_pose.PracticeOrder, 0);
            Assert.AreEqual(found_pose.PracticeOrder, 1);
        }*/
        [TestMethod]
        public void RepoEnsureOriginalPoseValues()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            Practice found_practice = repo.SearchYogiForPractice(found_yogi, "Sample Practice");
            UserPose found_pose = repo.FindUserPose(found_practice, "Sample User Pose");
            Assert.AreEqual(found_pose.Name, "Sample User Pose");
            Assert.AreEqual(found_pose.Duration, 5);
            Assert.IsNull(found_pose.Side);
        }
        [TestMethod]
        public void RepoCanEditPoses()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            Practice found_practice = repo.SearchYogiForPractice(found_yogi, "Sample Practice");
            UserPose found_pose = repo.FindUserPose(found_practice, "Sample User Pose");

            repo.EditPoseName(found_pose, "new name");
            repo.EditPoseDuration(found_pose, 20);
            repo.EditPoseSide(found_pose, "R");

            Assert.AreEqual(found_pose.Name, "new name");
            Assert.AreEqual(found_pose.Duration, 20);
            Assert.AreEqual(found_pose.Side, "R");
        }
        [TestMethod]
        public void RepoNoDuplicateYogiNames()
        {
            int count = yogis.Count;
            Assert.AreEqual(count, 2);

            yogis.Add(new Yogi
            {
                YogiID = 2,
                Name = "first"
            });

            int new_count = yogis.Count;
            Assert.AreEqual(count, new_count);
        }
        [TestMethod]
        public void RepoNoDuplicatePracticeNames()
        {
            int count = practices.Count;
            Assert.AreEqual(count, 2);

            practices.Add(new Practice
            {
                PracticeID = 3,
                Name = "first"
            });

            int new_count = practices.Count;
            Assert.AreEqual(count, new_count);
        }
        [TestMethod]
        public void RepoNoDuplicateUserPoseNames()
        {
            int count = user_poses.Count;
            Assert.AreEqual(count, 2);

            user_poses.Add(new UserPose
            {
                UserPoseID = 5,
                Name = "first"
            });

            int new_count = user_poses.Count;
            Assert.AreEqual(count, new_count);
        }
        [TestMethod]
        public void RepoGetAllBasePoses()
        {
            ConnectMocksToDatastore();
            int expected_pose_count = base_poses.Count;
            List<BasePose> basePoses = repo.GetBasePoses();
            int actual_pose_count = basePoses.Count;

            Assert.AreEqual(expected_pose_count, actual_pose_count);
        }
        [TestMethod]
        public void RepoGetAllPractices()
        {
            ConnectMocksToDatastore();
            Yogi found_yogi = repo.FindYogi("second");
            List<Practice> allPractices = repo.GetAllPractices(found_yogi);
            int expected_practice_count = 3;
            int actual_practice_count = allPractices.Count;

            Assert.AreEqual(expected_practice_count, actual_practice_count);

        }

    }

}
