using Microsoft.VisualStudio.TestTools.UnitTesting;
using Omega;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    /// <summary>
    /// Test class tests properties of User class.
    /// </summary>
    [TestClass]
    public class UserTests
    {
        /// <summary>
        /// Tests invalid username
        /// </summary>
        [TestMethod]
        public void test_validUsername()
        {
            User user = new User();

            user.Username = "test123";
            Assert.AreEqual("test123", user.Username);
        }
        [TestMethod]
        public void test_invalidUsername()
        {
            User user = new User();

            user.Username = "te$#^&9";
            Assert.AreNotEqual("te$#^&9", user.Username);
        }

        /// <summary>
        /// tests password containing single qoute
        /// </summary>
        [TestMethod]
        public void test_validPassword()
        {
            User user = new User();

            user.Password = "mypassword";
            Assert.AreEqual("mypassword", user.Password);
        }
        [TestMethod]
        public void test_invalidPassword()
        {
            User user = new User();

            user.Password = "'; DROP TABLE Users; --";
            Assert.AreNotEqual("'; DROP TABLE Users; --", user.Password);
        }

        /// <summary>
        /// Tests that date of employment cannot be in the future
        /// </summary>
        [TestMethod]
        public void test_validDateOfEmployment()
        {
            User user = new User();

            user.DateOfEmployment = new DateTime(2022, 7, 1);
            Assert.AreEqual(new DateTime(2022, 7, 1), user.DateOfEmployment);
        }
        [TestMethod]
        public void test_invalidDateOfEmployment()
        {
            User user = new User();

            user.DateOfEmployment = new DateTime(2027, 2, 5);
            Assert.AreNotEqual(new DateTime(2027, 2, 5), user.DateOfEmployment);
        }
    }
}
