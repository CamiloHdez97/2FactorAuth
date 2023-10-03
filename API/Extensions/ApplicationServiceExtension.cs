
using Aplication.UnitOfWork;
using Domain.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Domain;

namespace Api.Extensions;

public static class ApplicationServiceExtension
{
         public static void AddAplicationService(this IServiceCollection services)
     {

        // Registra IUnitOfWork como un servicio de ámbito
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Registra AutoMapper utilizando AddAutoMapper
        services.AddAutoMapper(typeof(ApplicationServiceExtension));

        // Registra IUserService como un servicio de ámbito
        services.AddScoped<ITwoAuthService, TwoAuthService>();

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();  

     }

}