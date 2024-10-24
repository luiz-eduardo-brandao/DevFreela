using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void CheckIfProjectCreatedSuccessfully()
        {
            string title = "test";
            string description = "description test";
            int idClient = 1;
            int idFreelancer = 2;
            decimal totalCost = 10000;

            var project = new Project(title, description, idClient, idFreelancer, totalCost);

            Assert.NotNull(project);
            Assert.Equal(title, project.Title);
            Assert.Equal(description, project.Description);
            Assert.Equal(idClient, project.IdClient);
            Assert.Equal(idFreelancer, project.IdFreelancer);
            Assert.Equal(totalCost, project.TotalCost);
        }

        [Fact]
        public void TestIfUpdateProjectWorks()
        {
            string newTitle = "new title";
            string newDescription = "new description";
            decimal newCost = 20000;

            var project = new Project("Teste", "Teste", 1, 1, 10);
            
            Assert.NotNull(project);

            project.Update(newTitle, newDescription, newCost);

            Assert.Equal(newTitle, project.Title);
            Assert.Equal(newDescription, project.Description);
            Assert.Equal(newCost, project.TotalCost);
        }

        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Teste", "Teste", 1, 1, 10);
            
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);
            
            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

        }

        [Fact]
        public void TestIfProjectFinishWorks() 
        {
            var project = new Project("test", "test", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.FinishedAt);

            project.Start();

            project.Finish();

            Assert.Equal(ProjectStatusEnum.Finished, project.Status);
            Assert.NotNull(project.FinishedAt);
        }
    }
}
