using Domain.DTO;
using FluentValidation;

namespace Domain.Validator
{
    public class ToDoDTOValidator : AbstractValidator<ToDoDTO>
    {
        public ToDoDTOValidator() 
        {
            RuleFor(note => note.Note).NotEmpty();
            RuleFor(note => note.Note).NotNull();

            RuleFor(note => note.Concluded).Must(value => value == false || value == true);
        }
    }
}
