using Azure.Core;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Test",
                Description = "Test",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 10000
            };

            projectRepositoryMock
                .Setup(p => p.AddAsync(It.IsAny<Project>()).Result)
                .Returns(1);

            var createProjectHandler = new CreateProjectHandler(projectRepositoryMock.Object);

            // Act
            var id = await createProjectHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id > 0);

            projectRepositoryMock.Verify(p => p.AddAsync(It.IsAny<Project>()).Result, Times.Once);
        }
    }
}
