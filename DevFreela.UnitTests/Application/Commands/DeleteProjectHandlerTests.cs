using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectHandlerTests
    {
        [Fact]
        public async Task ValidProjectId_Executed_DeleteProject()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var deleteProjectCommand = new DeleteProjectCommand(1);
            var project = new Project("test", "test", 1, 2, 10000);

            projectRepositoryMock
                .Setup(p => p.GetByIdAsync(deleteProjectCommand.Id).Result)
                .Returns(project);

            projectRepositoryMock
                .Setup(p => p.SaveChangesAsync())
                .Returns(Task.FromResult(true));

            var deleteProjectHandler = new DeleteProjectHandler(projectRepositoryMock.Object);

            // Act
            await deleteProjectHandler.Handle(deleteProjectCommand, new CancellationToken());

            // Assert
            projectRepositoryMock.Verify(p => p.SaveChangesAsync(), Times.Once());
        }
    }
}
