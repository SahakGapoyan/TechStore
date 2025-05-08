using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Brand;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Brand
{
    public class BrandAddDtoValidator : AbstractValidator<BrandAddDto>
    {
        public BrandAddDtoValidator(IUnitOfWork uow)
        {
            RuleFor(brand => brand.Name)
                .NotNull().WithMessage("Անունը պարտադիր է!")
                .MustAsync(async (name, token) => !(await uow.BrandRepository.GetBrands())
                .Any(b => b.Name.Trim().ToLower() == name.Trim().ToLower()))
                .WithMessage("Տվյալ բրենդը արդեն գոյություն ունի!");
        }
    }
}
