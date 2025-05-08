using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Ram;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Ram
{
    public class RamAddDtoValidator : AbstractValidator<RamAddDto>
    {
        public RamAddDtoValidator(IUnitOfWork uow)
        {
            RuleFor(ram => ram.Size)
                .NotNull().WithMessage("Ծավալը պարտադիր է!")
                .Must(size =>
                {
                    foreach (var letter in size)
                    {
                        if (!char.IsDigit(letter))
                            return false;
                    }
                    return true;
                }).WithMessage("Ծավալը միայն թվեր պետք է պարունակի!")
                .MustAsync(async (ram, token) => !(await uow.RamRepository.GetRams())
                .Any(r => r.Size.Trim().ToLower() == ram.Trim().ToLower()))
                .WithMessage("Տվյալ օպերատիվ հիշողությունը արդեն գոյություն ունի!");
        }
    }
}
