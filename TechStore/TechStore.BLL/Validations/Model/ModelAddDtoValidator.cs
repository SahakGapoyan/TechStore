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
                 .NotNull().WithMessage("The Name is required!")
                 .MustAsync(async (name, token) => !(await uow.ModelRepository.GetModels())
                 .Any(m => m.Name.Trim().ToLower() == name.Trim().ToLower()))
                 .WithMessage("The Category name already exists!");

            RuleFor(model => model.AnnouncementYear)
                .GreaterThan(1900).WithMessage("Announcement year must be after 1900.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Announcement year cannot be in the future.");

            RuleFor(model => model.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock must be non-negative number!");
        }
    }
}
