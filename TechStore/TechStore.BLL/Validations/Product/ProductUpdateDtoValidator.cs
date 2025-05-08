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
               .MustAsync(async (name, token) =>
               {
                   var repo = await uow.GetProductRepository<TProduct>();
                   return !(await repo.GetProducts(token)).Any(p => p.Name.Trim().ToLower() == name.Trim().ToLower());
               })
               .WithMessage("The Product name already exists!");

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0).WithMessage("The price must be non-negative");
        }
    }
}
