using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;

        public FinishProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            project.Finish();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
