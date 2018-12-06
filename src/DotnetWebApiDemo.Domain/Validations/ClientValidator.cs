using DotnetWebApiDemo.Domain.Entities;
using FluentValidation;

namespace DotnetWebApiDemo.Domain.Validations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("The FirstName cannot be blank.")
                .Length(0, 20).WithMessage("The FirstName cannot be more than 20 characters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("The LastName cannot be blank.")
                .Length(0, 60).WithMessage("The LastName cannot be more than 60 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("The E-mail cannot be blank.")
                .Length(0, 60).WithMessage("The E-mail cannot be more than 60 characters.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("The Phone cannot be blank.")
                .Length(0, 16).WithMessage("The Phone cannot be more than 16 characters.");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("The enum value provided is outside the range of the gender enum.");
        }
    }
}
