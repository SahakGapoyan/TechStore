using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Memory;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Memory
{
    public class MemoryUpdateDtoValidator : AbstractValidator<MemoryUpdateDto>
    {
        public MemoryUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(memory => memory.Size)
                .MustAsync(async (memory, token) => !(await uow.MemoryRepository.GetMemories())
                .Any(m => m.Size.Trim().ToLower() == memory.Trim().ToLower()))
                .WithMessage("Տվյալ հիշողությունը արդեն գոյություն ունի!");
        }
    } 
}
