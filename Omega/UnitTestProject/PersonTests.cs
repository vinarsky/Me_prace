using Microsoft.VisualStudio.TestTools.UnitTesting;
using Omega;
using System;

namespace UnitTestProject
{
    /// <summary>
    /// TestClass test properties of Person class.
    /// </summary>
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void test_validFirstname()
        {
            Person person = new Person(1);
            person.Firstname = "John";
            Assert.AreEqual("John", person.Firstname);
        }

        [TestMethod]
        public void test_invalidFirstname()
        {
            Person person = new Person(1);
            person.Firstname = "Jo%$&";
            Assert.AreNotEqual("Jo%$&", person.Firstname);
        }

        [TestMethod]
        public void test_validLastname()
        {
            Person person = new Person(1);
            person.Lastname = "Doe";
            Assert.AreEqual("Doe", person.Lastname);
        }

        [TestMethod]
        public void test_invalidLastname()
        {
            Person person = new Person(1);
            person.Lastname = "Do";
            Assert.AreNotEqual("Do", person.Lastname);
        }

        [TestMethod]
        public void test_validTel()
        {
            Person person = new Person(1);
            person.Tel = 123456789;
            Assert.AreEqual(123456789, person.Tel);
        }

        [TestMethod]
        public void test_invalidTel()
        {
            Person person = new Person(1);
            person.Tel = 123;
            Assert.AreNotEqual(123, person.Tel);
        }

        [TestMethod]
        public void test_validEmail()
        {
            Person person = new Person(1);
            person.Email = "john.doe@gmail.com";
            Assert.AreEqual("john.doe@gmail.com", person.Email);
        }

        [TestMethod]
        public void test_invalidEmail()
        {
            Person person = new Person(1);
            person.Email = "johndoe.com";
            Assert.AreNotEqual("johndoe.com", person.Email);
        }

        [TestMethod]
        public void test_ToStringReturnsFullname()
        {
            Person person = new Person(1);
            person.Firstname = "John";
            person.Lastname = "Doe";
            Assert.AreEqual("John Doe", person.ToString());
        }
    }

}
