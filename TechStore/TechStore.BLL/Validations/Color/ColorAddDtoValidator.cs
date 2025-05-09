using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Color;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Color
{
    public class ColorAddDtoValidator:AbstractValidator<ColorAddDto>
    {
        public ColorAddDtoValidator(IUnitOfWork uow)
        {
            RuleFor(color => color.Name)
                .NotNull().WithMessage("Անունը պարտադրի է!")
                .MustAsync(async (name, token) => !(await uow.ColorRepository.GetColors())
                .Any(b => b.Name.Trim().ToLower() == name.Trim().ToLower()))
                .WithMessage("Տվյալ գույնը արդեն գոյություն ունի!");

            RuleFor(color => color.HexCode)
                .NotNull().WithMessage("Գույնի կոդը պարտադիր է!")
                .MustAsync(async (hexCode, token) => !(await uow.ColorRepository.GetColors())
                .Any(c => c.HexCode.Trim().ToLower() == hexCode.Trim().ToLower()))
                .WithMessage("Տվյալ գույնի կեդը արդեն գոյություն ունի!");
        }
    }
}
