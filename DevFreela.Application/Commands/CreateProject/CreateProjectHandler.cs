using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            var id = await _repository.AddAsync(project);

            return id;
        }
    }
}
