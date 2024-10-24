using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdHandlerTests
    {
        [Fact]
        public async Task ValidProjectId_Executed_ReturnCorrectProject()
        {
            
            // Arrange
            // var projectRepositoryMock = new Mock<IProjectRepository>();

            // var getProjectByIdQuery = new GetProjectByIdQuery(1);

            // var projectDetailsViewModel = new ProjectDetailsViewModel(getProjectByIdQuery.Id, "test", "test", 10000, null, null, "test", "test");

            // var project = new Project(projectDetailsViewModel.Title, projectDetailsViewModel.Description, 1, 2, 10000);

            // projectRepositoryMock
            //     .Setup(p => p.GetByIdAsync(getProjectByIdQuery.Id).Result)
            //     .Returns(It.IsAny<Project>());

            // var getProjectByHandler = new GetProjectByIdHandler(projectRepositoryMock.Object);

            // // Act
            // var result = await getProjectByHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // // Assert
            // Assert.NotNull(result);
            // Assert.Equal(result.Title, project.Title);
            // Assert.Equal(result.Description, project.Description);
            // Assert.Equal(result.TotalCost, project.TotalCost);
        }
    }
}
