using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.API.Extensions;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;
using System.Security.Claims;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public AccountController(UserManager<AppUser> userManager, 
                             SignInManager<AppUser> signInManager, 
                             ITokenService tokenService,
                             IMapper mapper)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _tokenService = tokenService;
      _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetCurrentUserAsync()
    {
      var user = await _userManager.FindByEmailFromClaimsPrincipalAsync(User);

      return new UserDTO
      {
        Email = user.Email,
        Token = _tokenService.CreateToken(user),
        DisplayName = user.DisplayName,
      };
    }

    [HttpGet("emailExists")]
    public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
    {
      return await _userManager.FindByEmailAsync(email) != null;
    }

    [HttpGet("address")]
    public async Task<ActionResult<AddressDTO>> GetUserAddressAsync()
    {
      var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);
      return _mapper.Map<Address, AddressDTO>(user.Address);
    }

    [Authorize]
    [HttpPut("address")]
    public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO address)
    {
      var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);
      user.Address = _mapper.Map<AddressDTO, Address>(address);

      var result = await _userManager.UpdateAsync(user);
      if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDTO>(user.Address));
      return BadRequest("Error trying to update the user.");
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
    {
      var user = await _userManager.FindByEmailAsync(loginDTO.Email);
      if (user == null) return Unauthorized(new ApiResponse(401));

      var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
      if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

      return new UserDTO
      {
        Email = user.Email,
        Token = _tokenService.CreateToken(user),
        DisplayName = user.DisplayName,
      };
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
    {
      if(CheckEmailExistsAsync(registerDTO.Email).Result.Value)
      {
        return new BadRequestObjectResult(new ApiValidationErrorResponse {
          Errors = new [] {"Email Address is in Use"}
        });
      }

      var user = new AppUser
      {
        DisplayName = registerDTO.DisplayName,
        Email = registerDTO.Email,
        UserName = registerDTO.Email
      };

      var result = await _userManager.CreateAsync(user, registerDTO.Password);
      if (!result.Succeeded) return BadRequest(new ApiResponse(400));

      return new UserDTO
      {
        DisplayName = user.DisplayName,
        Email = user.Email,
        Token = _tokenService.CreateToken(user)
      };
    }
  }
}
