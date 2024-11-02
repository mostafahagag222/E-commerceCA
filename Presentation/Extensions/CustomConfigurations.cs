using System.Reflection;
using System.Text;
using Application.Queries;
using Domain.DTOs.Payloads;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using InfraStructure.Data;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace APIs.Extensions
{
    public static class CustomConfigurations
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services,
            IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EcpContext>(options => options.UseSqlServer(cs));

            //add fluent validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegistrationPayload>();
            services.AddValidatorsFromAssemblyContaining<GetProductsPagePayload>();
            services.AddControllers(o => { o.Filters.Add<ValidationFilter>(); });

            //repositories DI
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<Lazy<IUserRepository>>(provider =>
                new Lazy<IUserRepository>(() => provider.GetRequiredService<IUserRepository>()));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<Lazy<IProductRepository>>(provider =>
                new Lazy<IProductRepository>(() => provider.GetRequiredService<IProductRepository>()));
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<Lazy<IBrandRepository>>(provider =>
                new Lazy<IBrandRepository>(() => provider.GetRequiredService<IBrandRepository>()));
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<Lazy<ITypeRepository>>(provider =>
                new Lazy<ITypeRepository>(() => provider.GetRequiredService<ITypeRepository>()));
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<Lazy<IBasketItemRepository>>(provider =>
                new Lazy<IBasketItemRepository>(() => provider.GetRequiredService<IBasketItemRepository>()));
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<Lazy<IBasketRepository>>(provider =>
                new Lazy<IBasketRepository>(() => provider.GetRequiredService<IBasketRepository>()));
            services.AddScoped<IShippingMethodRepository, ShippingMethodRepository>();
            services.AddScoped<Lazy<IShippingMethodRepository>>(provider =>
                new Lazy<IShippingMethodRepository>(() => provider.GetRequiredService<IShippingMethodRepository>()));
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<Lazy<IOrderItemRepository>>(provider =>
                new Lazy<IOrderItemRepository>(() => provider.GetRequiredService<IOrderItemRepository>()));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<Lazy<IOrderRepository>>(provider =>
                new Lazy<IOrderRepository>(() => provider.GetRequiredService<IOrderRepository>()));
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<Lazy<IPaymentRepository>>(provider =>
                new Lazy<IPaymentRepository>(() => provider.GetRequiredService<IPaymentRepository>()));
            services.AddScoped<IPaymentLogRepository, PaymentLogRepository>();
            services.AddScoped<Lazy<IPaymentLogRepository>>(provider =>
                new Lazy<IPaymentLogRepository>(() => provider.GetRequiredService<IPaymentLogRepository>()));

            //mediatr
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(DoesEmailExitsAsync).Assembly));

            //unit of work DI
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //cors policy
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });

            //add Authorization JWT
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warehouse Api Admin", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.
                    Enter 'bearer' [space] and then your token in the text input below.
                    Example: 'bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var routePattern = api.RelativePath;
                    if (!string.IsNullOrEmpty(routePattern))
                    {
                        // Extract the controller name from the route pattern
                        var controllerName =
                            routePattern.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                        if (!string.IsNullOrEmpty(controllerName))
                        {
                            return new[] { controllerName };
                        }
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                c.DocInclusionPredicate((_, _) => true);
            });


            return services;
        }
    }
}