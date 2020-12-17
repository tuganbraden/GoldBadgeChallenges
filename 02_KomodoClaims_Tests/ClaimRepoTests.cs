using System;
using System.Collections.Generic;
using _02_KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KomodoClaims_Tests
{
    [TestClass]
    public class ClaimRepoTests
    {
        [TestMethod]
        public void AddClaim_ShouldGetNotNull()
        {
            Claim test = new Claim();
            ClaimRepo testRepo = new ClaimRepo();

            testRepo.AddClaim(test);
            Claim fromRepo = testRepo.GetQueue().Peek();

            Assert.IsNotNull(fromRepo);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            Claim test = new Claim();
            Claim test2 = new Claim();
            ClaimRepo testRepo = new ClaimRepo();

            testRepo.AddClaim(test);
            testRepo.AddClaim(test2);
            testRepo.HandleClaim();

            Assert.AreEqual(test2, testRepo.GetQueue().Peek());
        }
    }
}
