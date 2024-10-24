using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public void TestIfUserCreatedSuccessfuly()
        {
            var user = new User("test", "test", DateTime.Now, "test", "role");

            Assert.NotNull(user);
            Assert.True(user.Active);
            Assert.NotNull(user.Skills);
            Assert.NotNull(user.OwnedProjects);
            Assert.NotNull(user.FreelanceProjects);
        }
    }
}