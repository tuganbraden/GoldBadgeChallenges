using System;
using System.Collections.Generic;
using _03_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgeRepoTests
    {
        [TestMethod]
        public void AddBadge_ShouldGetNotNull()
        {
            Badge item = new Badge();
            item.BadgeID = 246;
            BadgeRepo repo = new BadgeRepo();

            repo.AddBadge(item);

            Assert.IsNotNull(repo.GetBadgeDict()[item.BadgeID]);
        }

        [TestMethod]
        public void UpdateBadge_ShouldBeTrue()
        {
            List<String> doors = new List<String>();
            doors.Add("A1");
            doors.Add("A2");
            Badge oldInfo = new Badge(343, doors);

            BadgeRepo repo = new BadgeRepo();
            repo.AddBadge(oldInfo);

            doors.Add("C2");
            doors.Remove("A2");
            Badge newInfo = new Badge(343, doors);

            bool updateResult = repo.UpdateBadge(newInfo);

            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteBadge_ShouldBeTrue()
        {
            List<String> doors = new List<String>();
            doors.Add("A1");
            doors.Add("A2");
            Badge oldInfo = new Badge(343, doors);

            BadgeRepo repo = new BadgeRepo();
            repo.AddBadge(oldInfo);

            bool deleteResult = repo.RemoveBadge(oldInfo.BadgeID);

            Assert.IsTrue(deleteResult);
        }
    }
}
