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
    public class ProductUpdateDtoValidator<TProduct> : AbstractValidator<ProductUpdateDto>
        where TProduct : Data.Entity.Product
    {
        public ProductUpdateDtoValidator(IUnitOfWork uow)
        {
            RuleFor(product => product.Name)
               .MustAsync(async (product,name, token) =>
               {
                   var repo = await uow.GetProductRepository<TProduct>();
                   return !(await repo.GetProducts(token))
                   .Any(p => p.Name.Trim().ToLower() == name.Trim().ToLower()
                   && p.Id!=product.Id);
               })
               .WithMessage("Տվալ ապրանքը արդեն գոյություն ունի!");

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Գինը չի կարող լինել բացասական!");
        }
    }
}
