using agenda_api.Models;
using FluentValidation;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(contact => contact.Name)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, Field.Name))
            .MaximumLength(MaximumLength.Fields).WithMessage(string.Format(ErrorMessages.MaxLength, Field.Name, MaximumLength.Fields))
            .Matches(Regex.ValidName).WithMessage(string.Format(ErrorMessages.InvalidField, Field.Name));

        RuleFor(contact => contact.Email)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, Field.Email))
            .MaximumLength(MaximumLength.Fields).WithMessage(string.Format(ErrorMessages.MaxLength, Field.Email, MaximumLength.Fields))
            .EmailAddress().WithMessage(string.Format(ErrorMessages.InvalidField, Field.Email));

        RuleFor(contact => contact.Phone)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, Field.Phone))
            .MaximumLength(MaximumLength.Phone).WithMessage(string.Format(ErrorMessages.MaxLength, Field.Phone, MaximumLength.Phone))
            .Matches(Regex.ValidPhone).WithMessage(string.Format(ErrorMessages.InvalidField, Field.Phone));
    }
}
