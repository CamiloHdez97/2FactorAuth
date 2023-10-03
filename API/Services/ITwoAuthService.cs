using API.Dtos;
using Domain;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace API.Services;

    public interface ITwoAuthService
    {
        byte[] GetQrAsImg(ref User user);

        bool VerifyCode(string secret, string code);


    }
