using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models.Identity;

namespace PUC.PosGraduacao.BookStore.API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
      _signInManager = signInManager;
      _userManager = userManager;
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
        Token = "Token Placeholder",
        DisplayName = user.DisplayName,
      };
    }
  }
}
