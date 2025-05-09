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
    public class RamUpdateDtoValidator:AbstractValidator<RamUpdateDto>
    {
        public RamUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(ram => ram.Size)
                .Must(size =>
                {
                    foreach (var letter in size)
                    {
                        if (!char.IsDigit(letter))
                            return false;
                    }
                    return true;
                }).WithMessage("Ծավալը միայն թվեր կարող է պարունակել!")
                .MustAsync(async (ram, token) => !(await uow.RamRepository.GetRams())
                .Any(r => r.Size.Trim().ToLower() == ram.Trim().ToLower()))
                .WithMessage("Տվյալ օպերատիվ հիշողությունը արդեն գոյություն ունի!");
        }
    }
}
