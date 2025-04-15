using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Interfaces;

namespace TechStore.BLL.Services
{
    public class BrandService
    {
        private readonly IUnitOfWork _uow;

        public BrandService(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
