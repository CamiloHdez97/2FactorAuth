using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Domain;
using Microsoft.AspNetCore.Identity;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Qr;

namespace API.Services;
public class TwoAuthService : ITwoAuthService
{
    private readonly IPasswordHasher<User> _passwordHash;
    private readonly IConfiguration _config;
    private readonly ILogger<TwoAuthService> _logger;
    private readonly int _accessTokenTimeout;
    private readonly int _refreshTokenTimeout;

    public TwoAuthService (
        
        IPasswordHasher<User> passwordHash,
        IConfiguration config,
        ILogger<TwoAuthService> logger
    )
    
    {
        _config = config;
        _passwordHash = passwordHash;
        _logger = logger;

        //Obtenermos la duración del los tokens desde la configuracion
        (_accessTokenTimeout, _refreshTokenTimeout) = GetTokenTimeout();
    }




    //Retornamos el codigo QR formateado en imagen png 
    public byte[] GetQrAsImg(ref User user){

        if(user.Email == null){

            throw new ArgumentNullException(nameof(user.Email));

        }

        var tfa = new TwoFactorAuth(_config["JWTSetting:Isser"],6,30,Algorithm.SHA256, new ImageChartsQrCodeProvider());
        string secret = tfa.CreateSecret(160);
        
        user.TwoFactorSecret = secret;

        var qr = tfa.GetQrCodeImageAsDataUri(user.Email,user.TwoFactorSecret);
        string DataQR = qr.Replace("data:image/png;base64,","");

        //user = null;

        return Convert.FromBase64String(DataQR);

    }

    //Verificamos la integridad del codigo conparando con la llave secret
    public bool VerifyCode(string secret, string code)
    {

        var tfa = new TwoFactorAuth(_config["JWTSettings:Issuer"],6,30,Algorithm.SHA256);
        return tfa.VerifyCode(secret, code);

    }


    //Metodo para obtener la ducarión del token
    private (int _accessTokenTimeout, int _refreshTokenTimeout) GetTokenTimeout(){

        return (

            int.TryParse(_config["JWTSettings:AccessTokenTimeInMinutes"], out int accessTokenTimeout)
                ? accessTokenTimeout : 15, // 15 minutes por defecto

            int.TryParse(_config["JWTSettings:AccessTokenTimeInHours"], out int _refreshTokenTimeout)
                ? _refreshTokenTimeout: 24 // 24 Horas

        );

    }    

}