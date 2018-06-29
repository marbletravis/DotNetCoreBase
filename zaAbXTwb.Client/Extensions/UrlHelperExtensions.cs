using Microsoft.AspNetCore.Mvc;
using zaAbXTwb.Client.Controllers.Core;

namespace zaAbXTwb.Client.Extensions
{
  public static class UrlHelperExtensions
  {
    public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
    {
      return urlHelper.Action(
        action: nameof(AccountMvcController.ConfirmEmail),
        controller: "AccountMvc",
        values: new { userId, code },
        protocol: scheme);
    }

    public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
    {
      return urlHelper.Action(
        action: nameof(AccountMvcController.ResetPassword),
        controller: "AccountMvc",
        values: new { userId, code },
        protocol: scheme);
    }
  }
}