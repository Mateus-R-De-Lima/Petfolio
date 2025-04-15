using FluentValidation;
using Petfolio.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Application.UseCases.Pets.Register
{
    public class RegisterPetValidator : AbstractValidator<RequestPetJson>
    {
        public RegisterPetValidator()
        {
            RuleFor(pet => pet.Name).NotEmpty().WithMessage("The title is required.");
            RuleFor(pet => pet.Birthday).LessThan(DateTime.UtcNow).WithMessage("Date of birth cannot be greater than today's date");
            RuleFor(pet => pet.Type).IsInEnum().WithMessage("Pet Type is not valid.");
        }
    }
}
