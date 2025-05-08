using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.Validations.Product;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.SmartPhone
{
    public class SmartPhoneAddDtoValidator : AbstractValidator<SmartPhoneAddDto>
    {
        public SmartPhoneAddDtoValidator(IUnitOfWork uow)
        {
            Include(new ProductAddDtoValidator<Data.Entity.SmartPhone>(uow));

            RuleFor(smartPhone => smartPhone.ScreenSize)
                .NotNull().WithMessage("The ScreenSize is required!")
                .Must(screenSize =>
                    screenSize.All(ch => char.IsDigit(ch) || ch == '.') &&
                    screenSize.Count(ch => ch == '.') <= 1
                ).WithMessage("The ScreenSize must contain only digits and at most one dot!");

            RuleFor(smartPhone => smartPhone.BatteryCapacity)
                .GreaterThan(0).WithMessage("The BatteryCapacity must be positive number!");

            RuleFor(smartPhone => smartPhone.CameraMegaPixel)
               .GreaterThan(0).WithMessage("The CameraMegaPixel must be positive number!");
        }
    }
}
