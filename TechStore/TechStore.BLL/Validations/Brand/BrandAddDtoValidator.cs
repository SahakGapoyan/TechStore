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
                .NotNull().WithMessage("The Name is required!")
                .MustAsync(async (name, token) => !(await uow.BrandRepository.GetBrands())
                .Any(b => b.Name.Trim().ToLower() == name.Trim().ToLower()))
                .WithMessage("The Brand name already exists!");
        }
    }
}
