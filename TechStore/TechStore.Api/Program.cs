
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.BLL.DtoModels.Laptop;
using TechStore.BLL.DtoModels.Product;
using TechStore.BLL.DtoModels.SmartPhone;
using TechStore.BLL.DtoModels.Tv;
using TechStore.BLL.Interfaces;
using TechStore.BLL.Services;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;
using TechStore.Data.Repositories;

namespace TechStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ICartItemService, CartItemService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<ILaptopService, LaptopService>();
            builder.Services.AddScoped<IMemoryService, MemoryService>();
            builder.Services.AddScoped<IModelService, ModelService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOSService, OSService>();
            builder.Services.AddScoped<IProductService<SmartPhone, SmartPhoneDto, SmartPhoneAddDto, SmartPhoneUpdateDto>,
                ProductService<SmartPhone, SmartPhoneDto, SmartPhoneAddDto, SmartPhoneUpdateDto>>();
            builder.Services.AddScoped<IProductService<Laptop, LaptopDto, LaptopAddDto, LaptopUpdateDto>,
                ProductService<Laptop, LaptopDto, LaptopAddDto, LaptopUpdateDto>>();
            builder.Services.AddScoped<IProductService<Tv, TvDto, TvAddDto, TvUpdateDto>,
                ProductService<Tv, TvDto, TvAddDto, TvUpdateDto>>();
            builder.Services.AddScoped<IRamService, RamService>();
            builder.Services.AddScoped<ISmartPhoneService, SmartPhoneService>();
            builder.Services.AddScoped<ITvService, TvService>();
            builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddDbContext<TechStoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TechStoreConnection"));
            });

            var app = builder.Build();

            app.UseCors(policy =>policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
