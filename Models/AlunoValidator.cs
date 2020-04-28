using FluentValidation;

namespace fluent_validation.Models
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator() 
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Informe o nome do aluno")
                .Length(3, 100).WithMessage("O nome deve ter no mínimo 3 e no máximo 100 caracteres");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Informe o e-mail do aluno")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(a => a.DataNascimento)
                .NotEmpty().WithMessage("Informe a data de nascimento do aluno")
                .Must(AlunoMaiorDeIdade).WithMessage("O aluno deve ser maio que 18 anos");
        }

        public static bool AlunoMaiorDeIdade(System.DateTime dataNascimento)
        {
            return dataNascimento <= System.DateTime.Now.AddYears(-18);
        }
    }
}