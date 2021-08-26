using _03_Badges_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgeRepoTests
    {
        BadgesRepo repo = new BadgesRepo();

        [TestMethod]
        public void TestThatCreateNewBadge_AddsBadgeToDictionary()
        {
            repo.CreateNewBadge(1234);
            var allBadges = repo.GetAllBadges();

            Assert.IsTrue(allBadges.Count == 1);
        }

        [TestMethod]
        public void TestThatAddingADoorToBadge_AddsDoorToCorrectBadgeId()
        {
            repo.CreateNewBadge(123);
            repo.AddDoorToBadge(123, "d1");

            var doors = repo.GetDoorsByBadgeId(123);

            Assert.AreEqual(1, doors.Count);
            Assert.IsTrue(doors.Contains("d1"));
        }

        [TestMethod]
        public void TestThatUpdatBadge_UpdatesBadge()
        {
            repo.CreateNewBadge(123);
            var doors = new List<string>();
            doors.Add("d1");
            doors.Add("g2");
            repo.UpdateBadge(123, doors);
            var updatedDoors = repo.GetDoorsByBadgeId(123);

            Assert.AreEqual(doors, updatedDoors);
            
        }

        [TestMethod]
        public void TestThatRemoveDoorFromBadge_RmovesDoorFromBadge()
        {
            repo.CreateNewBadge(1234);
            var doors1 = new List<string>();
            doors1.Add("d1");
            doors1.Add("f1");
            repo.UpdateBadge(1234, doors1);
            repo.RemoveDoorFromBadge(1234, "d1");
            var updatedDoors = repo.GetDoorsByBadgeId(1234);

            Assert.IsTrue(updatedDoors.Contains("f1"));
            Assert.IsFalse(updatedDoors.Contains("d1"));
        }

        [TestMethod]
        public void TestThatAddDoorToBadge_AddsDoorToCorrectBadge()
        {
            repo.CreateNewBadge(123);
            repo.AddDoorToBadge(123, "d1");
            var doors = repo.GetDoorsByBadgeId(123);

            Assert.AreEqual(1, doors.Count);
            Assert.IsTrue(doors.Contains("d1"));
        }
    }
}
