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
    public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(brand => brand.Name)
               .MustAsync(async (name, token) => !(await uow.BrandRepository.GetBrands())
               .Any(b => b.Name.Trim().ToLower() == name.Trim().ToLower()))
               .WithMessage("Տվյալ բրենդը արդեն գոյութոյւն ունի!");
        }
    }
}
