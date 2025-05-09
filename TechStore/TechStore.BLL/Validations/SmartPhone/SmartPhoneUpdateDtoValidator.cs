﻿using FluentValidation;
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
    public class SmartPhoneUpdateDtoValidator : AbstractValidator<SmartPhoneUpdateDto>
    {
        public SmartPhoneUpdateDtoValidator(IUnitOfWork uow)
        {
            Include(new ProductUpdateDtoValidator<Data.Entity.Product>(uow));

            RuleFor(smartPhone => smartPhone.ScreenSize)
               .Must(screenSize =>
                   screenSize.All(ch => char.IsDigit(ch) || ch == '.') &&
                   screenSize.Count(ch => ch == '.') <= 1
               ).WithMessage("Էկրանի չափսը միայն թվեր և կետ կարող է պարունակել!");

            RuleFor(smartPhone => smartPhone.BatteryCapacity)
                .GreaterThan(0).WithMessage("Մարտկոցի հզորությունը պետք է լինի դրական!");

            RuleFor(smartPhone => smartPhone.CameraMegaPixel)
               .GreaterThan(0).WithMessage("Տեսախցիկի Փիքսելները պետք է լինեն դրական!");
        }
    }
}
