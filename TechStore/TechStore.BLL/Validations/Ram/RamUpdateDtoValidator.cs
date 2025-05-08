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
                }).WithMessage("The Size must contain only digits!")
                .MustAsync(async (ram, token) => !(await uow.RamRepository.GetRams())
                .Any(r => r.Size.Trim().ToLower() == ram.Trim().ToLower()))
                .WithMessage("The Ram size already exists!");
        }
    }
}
