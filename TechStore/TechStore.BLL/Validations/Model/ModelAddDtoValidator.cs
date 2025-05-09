using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Model;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Model
{
    public class ModelAddDtoValidator : AbstractValidator<ModelAddDto>
    {
        public ModelAddDtoValidator(IUnitOfWork uow)
        {
            RuleFor(model => model.Name)
                 .NotNull().WithMessage("Անունը պարտադիր է!")
                 .MustAsync(async (name, token) => !(await uow.ModelRepository.GetModels())
                 .Any(m => m.Name.Trim().ToLower() == name.Trim().ToLower()))
                 .WithMessage("Տվյալ մոդելը արդեն գոյություն ունի!");

            RuleFor(model => model.AnnouncementYear)
                .GreaterThan(1900).WithMessage("Թողարկամն տարեթիվը պետք է լինի 1900-ից բարձր")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Թողարկման տարեթիվը չի կարող լինել ապագայից");

            RuleFor(model => model.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Քանակը չի կարող լինել բացասական!");
        }
    }
}
