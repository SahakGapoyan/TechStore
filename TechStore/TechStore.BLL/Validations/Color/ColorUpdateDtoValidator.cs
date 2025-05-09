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
    public class ColorUpdateDtoValidator:AbstractValidator<ColorUpdateDto>
    {
        public ColorUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(color => color.Name)
                .MustAsync(async (color, name, token) =>
                    !(await uow.ColorRepository.GetColors())
                        .Any(b => b.Name.Trim().ToLower() == name.Trim().ToLower()
                               && b.Id!=color.Id))
                .WithMessage("Տվյալ գույնը արդեն գոյութոյւն ունի!");

            RuleFor(color => color.HexCode)
                .MustAsync(async (color, hexCode, token) =>
                    !(await uow.ColorRepository.GetColors())
                        .Any(c => c.HexCode.Trim().ToLower() == hexCode.Trim().ToLower()
                               && c.Id!=color.Id))
                .WithMessage("Տվյալ գույնի կոդը արդեն գոյութոյւն ունի!");
        }
    }
}
