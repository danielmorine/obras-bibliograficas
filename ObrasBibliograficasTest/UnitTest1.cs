using Moq;
using NUnit.Framework;
using ObrasBibliograficasWeb.Extension;
using ObrasBibliograficasWeb.Query;
using ObrasBibliograficasWeb.Repositories.Interfaces;
using ObrasBibliograficasWeb.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenFormattingTheNameSucceeds()
        {
            var mock = new Mock<IUserRepository>();
            var userService = new UserService(mock.Object);

            await userService.AddRangeAsync();

            var users = await userService.GetAllAsync(new ObrasBibliograficasWeb.Models.BibliographiesModel { Number = 5 });
            Assert.AreEqual(users.ToArray().Length > 0, users.ToArray().Length);
        }
    }
}