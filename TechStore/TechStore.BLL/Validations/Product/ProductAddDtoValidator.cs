using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Product;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Validations.Product
{
    public class ProductAddDtoValidator<TProduct> : AbstractValidator<ProductAddDto>
        where TProduct : Data.Entity.Product
    {
        public ProductAddDtoValidator(IUnitOfWork uow)
        {
            RuleFor(product => product.Name)
               .NotNull().WithMessage("Անունտ պարտադիր է!")
               .MustAsync(async (name, token) =>
               {
                   var repo = await uow.GetProductRepository<TProduct>();
                   return !(await repo.GetProducts(token)).Any(p => p.Name.Trim().ToLower() == name.Trim().ToLower());
               })
               .WithMessage("Տվյալ ապրանքը արդեն գոյություն ունի!!");

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Գինը չի կարող լինել բացասական");
        }
    }
}
