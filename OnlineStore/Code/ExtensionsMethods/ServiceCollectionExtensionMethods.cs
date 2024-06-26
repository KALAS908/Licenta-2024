﻿using OnlineStore.BusinessLogic.Base;
using OnlineStore.BusinessLogic.Implementation.Account;
using OnlineStore.BusinessLogic.Implementation.BrandImplementation;
using OnlineStore.BusinessLogic.Implementation.ColorImplementation;
using OnlineStore.BusinessLogic.Implementation.ComentsImplementation;
using OnlineStore.BusinessLogic.Implementation.Countries;
using OnlineStore.BusinessLogic.Implementation.EmailImplementation;
using OnlineStore.BusinessLogic.Implementation.GenderImplementation;
using OnlineStore.BusinessLogic.Implementation.MeasureImplementation;
using OnlineStore.BusinessLogic.Implementation.NewFolder;
using OnlineStore.BusinessLogic.Implementation.OrderImplementation;
using OnlineStore.BusinessLogic.Implementation.Products;
using OnlineStore.BusinessLogic.Implementation.TypeImplementation;
using OnlineStore.Code;
using OnlineStore.Common.DTOs;
using OnlineStore.Entities.Entities;
using OnlineStore.WebApp.Controllers;
using System.Security.Claims;

namespace OnlineStore.WebApp.Code.ExtensionsMethods
{
    public static class ServiceCollectionExtensionMethods
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<ControllerDependencies>();
            services.AddScoped<BaseController>();
            services.AddScoped<UserAccountController>();
            services.AddScoped<CountryController>();
            services.AddScoped<ProductController>();
            services.AddScoped<CategoryController>();
            services.AddScoped<BrandController>();
            services.AddScoped<GenderController>();
            services.AddScoped<TypeController>();
            services.AddScoped<ColorController>();
            services.AddScoped<MeasureController>();
            services.AddScoped<ShoppingCartController>();
            services.AddScoped<OrderController>();

            return services;
        }

        public static IServiceCollection AddOnlineStoreBusinessLogic(this IServiceCollection services)
        {

            services.AddScoped<ServiceDependencies>();
            services.AddScoped<UserAccountService>();
            services.AddScoped<CountriesService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ColorService>();
            services.AddScoped<BrandService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<GenderService>();
            services.AddScoped<TypeService>();
            services.AddScoped<MeasureService>();
            services.AddScoped<ColorService>();
            services.AddScoped<ShoppingCartService>();
            services.AddScoped<OrderService>();
            services.AddScoped<CommentService>();
            services.AddScoped<EmailService>();
            return services;
        }

        public static IServiceCollection AddCurentUser(this IServiceCollection services)
        {
            services.AddScoped(s =>
            {


                var accessor = s.GetService<IHttpContextAccessor>();
                var httpContext = accessor.HttpContext;
                var claims = httpContext.User.Claims;
                var Id = claims?.FirstOrDefault(c => c.Type == "Id")?.Value;
                var Email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var Role = claims?.FirstOrDefault(c => c.Type == "RoleId")?.Value;
                var IsAdmin = claims?.FirstOrDefault(c => c.Type == "IsAdmin")?.Value;

                var CurrentUser = new CurrentUserDto
                {
                    IsAuthenticated = httpContext.User.Identity.IsAuthenticated,
                    Id = Id,
                    Email = Email,
                    RoleId = Convert.ToInt32(Role),
                    IsAdmin = Convert.ToBoolean(IsAdmin),

                };

                return CurrentUser;
            });


            return services;
        }
    }
}
