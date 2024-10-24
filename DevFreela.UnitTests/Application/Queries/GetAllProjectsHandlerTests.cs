using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsHandlerTests
    {
        [Fact]
        // Given_When_Then
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome 1", "Desc 1", 1, 2, 10000),
                new Project("Nome 2", "Desc 2", 1, 2, 20000),
                new Project("Nome 3", "Desc 3", 1, 2, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            projectRepositoryMock
                .Setup(p => p.GetAllAsync().Result)
                .Returns(projects);

            var getAllProjectQuery = new GetAllProjectsQuery("");
            var getAllProjectQueryHandler = new GetAllProjectsHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projectViewModelList.Count, projects.Count);

            projectRepositoryMock.Verify(p => p.GetAllAsync().Result, Times.Once);
        }
    }
}
