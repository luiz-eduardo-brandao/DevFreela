using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Descrição é de 255 caracteres");

            RuleFor(p => p.Title)
                .MaximumLength(70)
                .WithMessage("Tamanho máximo de Título é de 70 caracteres");

            RuleFor(p => p.Title)
                .MinimumLength(3)
                .WithMessage("Tamanho mínimo de Título é de 3 caracteres");

            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Título é obrigatório!");

            RuleFor(p => p.Title)
                .NotNull()
                .WithMessage("Título é obrigatório!");
        }
    }
}
