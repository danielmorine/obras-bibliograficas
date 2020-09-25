using Moq;
using NUnit.Framework;
using ObrasBibliograficasWeb.Repositories.Interfaces;
using ObrasBibliograficasWeb.Services;

namespace Tests
{
    public class Tests
    {
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<IUserRepository>();
            _userService = new UserService(mock.Object);
        }

        [Test]
        public void WhenTheyHaveOnlyOneCapitalLetter()
        {
            var name = "Julio Neto da silva";
            var result = _userService.FormatName(name);

            Assert.AreEqual("SILVA, Julio Neto da ", result);
        }

        [Test]
        public void WhenTheyHaveOnlyTwoCapitalLetter()
        {
            var name = "José Ivaldo Gomes de Andrade Filho";
            var result = _userService.FormatName(name);

            Assert.AreEqual("ANDRADE FILHO, José Ivaldo Gomes de ", result);
        }

        [Test]
        public void WhenYouHaveOnlyOneName()
        {
            var name = "silvio";

            var result = _userService.FormatName(name);

            Assert.AreEqual("SILVIO", result);
        }

        [Test]
        public void WhenYouHaveOnlyOneNameAndSurname()
        {
            var name = "silvio andrade";

            var result = _userService.FormatName(name);

            Assert.AreEqual("ANDRADE, Silvio ", result);
        }
    }
}