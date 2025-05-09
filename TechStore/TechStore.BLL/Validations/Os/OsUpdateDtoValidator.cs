using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.OS;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Os
{
    public class OsUpdateDtoValidator:AbstractValidator<OSUpdateDto>
    {
        public OsUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(os => os.Name)
               .MustAsync(async (name, token) => !(await uow.OSRepsoitory.GetOSs())
               .Any(os => os.Name.Trim().ToLower() == name.Trim().ToLower()))
               .WithMessage("Տվյալ օպերացիոն համակարգը արդեն գոյություն ունի!");
        }
    }
}
