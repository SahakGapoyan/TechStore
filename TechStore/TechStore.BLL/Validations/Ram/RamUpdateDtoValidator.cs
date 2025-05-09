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
    public class RamUpdateDtoValidator : AbstractValidator<RamUpdateDto>
    {
        public RamUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(ram => ram.Size)
                .MustAsync(async (ram, size, token) => !(await uow.RamRepository.GetRams())
                .Any(r => r.Size.Trim().ToLower() == size.Trim().ToLower() && r.Id != ram.Id))
                .WithMessage("Տվյալ օպերատիվ հիշողությունը արդեն գոյություն ունի!");
        }
    }
}
