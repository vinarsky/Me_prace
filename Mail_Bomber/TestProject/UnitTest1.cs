using NUnit.Framework;
namespace TestProject
{
    public class Tests
    {

        private MailSender _mailSender;

        [SetUp]
        public void Setup()
        {
            _mailSender = new MailSender();
        }

        [Test]
        public void Test1()
        {            
            Assert.Pass();
        }
    }
}