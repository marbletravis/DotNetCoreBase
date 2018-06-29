using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zaAbXTwb.Client.Controllers.Models;
using zaAbXTwb.Client.Extensions;
using zaAbXTwb.Data.Models;
using zaAbXTwb.Data.Models.AccountViewModels;
using zaAbXTwb.Service.Services;

namespace zaAbXTwb.Client.Controllers.Core
{

  [Authorize]
  [Route("api/[controller]/[action]")]
  public class AccountApiController : ApiController
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly ILogger _logger;

    public AccountApiController(
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager,
      IEmailSender emailSender,
      ILogger<AccountMvcController> logger)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _emailSender = emailSender;
      _logger = logger;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<Result> Login([FromBody] LoginViewModel viewModel)
    {
      // This doesn't count login failures towards account lockout
      // To enable password failures to trigger account lockout, set lockoutOnFailure: true
      var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return new Result() { Ok = true, Message = "User logged in." };
      }
      if (result.IsLockedOut)
      {
        throw new NotAuthorizedException("User account is locked");
      }
      throw new NotAuthorizedException("Invalid login attempt.");
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IdentityResult> Register([FromBody]RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
      var result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        _logger.LogInformation("User created a new account with password.");

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
        await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

        await _signInManager.SignInAsync(user, isPersistent: false);
        _logger.LogInformation("User created a new account with password.");
        return result;
      }

      return result;
    }
  }

}