using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.DtoModels.Product;
using TechStore.BLL.Validations.Product;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Laptop
{
    public class LaptopUpdateDtoValidator : AbstractValidator<LaptopUpdateDto>
    {
        public LaptopUpdateDtoValidator(IUnitOfWork uou)
        {
            Include(new ProductUpdateDtoValidator<Data.Entity.Laptop>(uou));

            RuleFor(laptop => laptop.BatteryLifeInHours)
                .GreaterThan(0).WithMessage("The BatteryLifeInHours must be positive number!");
        }
    }
}
