using FamilyDoctor.Models;
using FluentValidation;
using System;

namespace WebApplication1_Logowanie.Models.CreatePatientValidator
{
    public class UserValidator : AbstractValidator<Patient>
    {
        public void CreateValidator()
        {

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("Pole jest obowiazkowe").Length(3, 40);

            RuleFor(p => p.FirstName)
                 .NotEmpty().WithMessage("Pole jest obowiazkowe").Length(3, 50);


            RuleFor(p => p.BornDate)
                .NotEmpty().WithMessage("Pole obowiazkowe")
                .LessThan(p => DateTime.Now).WithMessage("Prosze uzupelnic pole");


            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Pole jest obowiazkowe").Length(10, 50);

        }
    }

   
}