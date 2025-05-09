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
                .NotNull().WithMessage("The Ram is required!")
                .MustAsync(async (ram, token) => !(await uow.RamRepository.GetRams())
                .Any(r => r.Size.Trim().ToLower() == ram.Trim().ToLower()))
                .WithMessage("The Ram size already exists!");
        }
    }
}
