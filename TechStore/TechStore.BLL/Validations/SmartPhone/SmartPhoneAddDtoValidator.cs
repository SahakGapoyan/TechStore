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
                .NotNull().WithMessage("Էկրանի չափսը պարտադիր է!")
                .Must(screenSize =>
                    screenSize.All(ch => char.IsDigit(ch) || ch == '.') &&
                    screenSize.Count(ch => ch == '.') <= 1
                ).WithMessage("Էկրանի չափսը միայն թվեր պետք է պարունակի և ամենաշատը մեկ կետ");

            RuleFor(smartPhone => smartPhone.BatteryCapacity)
                .GreaterThan(0).WithMessage("Մարտկոցի հզորությունտ պետք է լինի դրական!");

            RuleFor(smartPhone => smartPhone.CameraMegaPixel)
               .GreaterThan(0).WithMessage("Տեսախցիկի Փիքսելները պետք է լինեն դրական!");
        }
    }
}
