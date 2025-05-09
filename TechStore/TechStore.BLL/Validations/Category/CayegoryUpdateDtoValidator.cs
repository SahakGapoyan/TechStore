using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Category;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Category
{
    public class CayegoryUpdateDtoValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CayegoryUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(category => category.Name)
                .MustAsync(async (name, token) => !(await uow.CategoryRepository.GetCategories())
                .Any(c => c.Name.Trim().ToLower() == name.Trim().ToLower()))
                .WithMessage("Տվյալ կատեգորիան արդեն գոյութոյւն ունի!");
        }
    }
}
