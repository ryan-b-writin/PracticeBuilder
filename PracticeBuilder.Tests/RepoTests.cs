using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeBuilder.DAL;

namespace PracticeBuilder.Tests
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void RepoCanCreateInstanceOfRepo()
        {
            PracticeBuilderRepo repo = new PracticeBuilderRepo();
            Assert.IsNotNull(repo);
        }
    }
}
