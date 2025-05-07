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
                .NotNull().WithMessage("The Name is required!")
                .MustAsync(async (name, token) => !(await uow.ColorRepository.GetColors())
                .Any(b => b.Name.Trim().ToLower() == name.Trim().ToLower()))
                .WithMessage("The Color name already exists!");

            RuleFor(color => color.HexCode)
                .NotNull().WithMessage("The HexCode is required!")
                .MustAsync(async (hexCode, token) => !(await uow.ColorRepository.GetColors())
                .Any(c => c.HexCode.Trim().ToLower() == hexCode.Trim().ToLower()))
                .WithMessage("The Color HexCode already exists!");
        }
    }
}
