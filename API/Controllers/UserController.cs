using API.Dtos;
using API.Services;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController : BaseApiController
{
    private readonly ILogger<UserController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITwoAuthService _auth;

    public UserController (
        
        ILogger<UserController> logger,
        IUnitOfWork unitOfWork,
        ITwoAuthService auth

    )
    
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _auth = auth;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<User>>> GetAll(){
        
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync();
                return Ok(users); 

             }
            catch (Exception ex)
            { 
                _logger.LogError("Error getting users: {0}", ex.Message);
                return BadRequest("some wrong");
            }
            
    }

    
    [HttpGet("QR/id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> GetQrAsCode(int id){

        try{

            User user = await _unitOfWork.Users.FindFirst(x => x.Id == id);
            byte[] Qr = _auth.GetQrAsImg(ref user);            
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveAsync();
            return File(Qr,"image/png");

            }
            catch (Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest("some wrong");


            }      

    }

    [HttpGet("QR/email/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> GetQrAsImg(string email){

        try{

            User user = await _unitOfWork.Users.FindFirst(x => x.Email == email);
            byte[] Qr = _auth.GetQrAsImg(ref user);            
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveAsync();
            return File(Qr,"image/png");

            }
            catch (Exception ex){
                _logger.LogError(ex.Message);
               return BadRequest("some wrong");

            }      

    }

    [HttpPost("QR/verify")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> VerifyCode([FromBody] UserDto data){

        try{
            
            User user = await _unitOfWork.Users.FindFirst(u => u.Id == data.Id);

            if(user.TwoFactorSecret == null){
    
                throw new ArgumentException(user.TwoFactorSecret);
    
            }

            var isOk = _auth.VerifyCode(user.TwoFactorSecret, data.Key);

            if(isOk == true){
                
                return Ok($"Id Usuario: {data.Id} \n Autenticado, con Key {data.Key}");

            }
            return Unauthorized();

        }catch(Exception ex){

            _logger.LogError(ex.Message);
            return BadRequest("Quaker camper");

        }
    }

}