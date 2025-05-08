using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.Validations.Product;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Laptop
{
    public class LaptopAddDtoValidator : AbstractValidator<LaptopAddDto>
    {
        public LaptopAddDtoValidator(IUnitOfWork uow)
        {
            Include(new ProductAddDtoValidator<Data.Entity.Laptop>(uow));

            RuleFor(laptop => laptop.BatteryLifeInHours)
                .GreaterThan(0).WithMessage("The BatteryLifeInHours must be positive number!");
        }
    }
}
