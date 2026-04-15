using CleanArchitecture.Application.Dtos;
using FluentValidation;

namespace CleanArchitecture.Application.Validation;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(u => u.Nome).NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(30).WithMessage("Nome deve ter no máximo 30 caracteres.");
        RuleFor(u => u.Telefone).NotEmpty().WithMessage("Telefone é obrigatório.")
            .Matches(@"^\d{10,11}$").WithMessage("Telefone deve conter apenas números e ter entre 10 e 11 dígitos.");
    }
}