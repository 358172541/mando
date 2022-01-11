using IdentityServer4.Services;
using Mando.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Identity;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Mando.Pages.Account
{
    /// <summary>
    /// ref Volo.Abp.Account.Web.IdentityServer.Pages.IdentityServerSupportedLogoutModel.cs
    /// </summary>
    public class LogoutModel : AbpPageModel
    {
        [BindProperty(SupportsGet = true), HiddenInput] public string ReturnUrl { get; set; }

        public IdentitySecurityLogManager IdentitySecurityLogManager { get; }
        public IIdentityServerInteractionService IdentityServerInteractionService { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public LogoutModel(
            IdentitySecurityLogManager identitySecurityLogManager,
            IIdentityServerInteractionService identityServerInteractionService,
            SignInManager<IdentityUser> signInManager)
        {
            IdentitySecurityLogManager = identitySecurityLogManager;
            IdentityServerInteractionService = identityServerInteractionService;
            SignInManager = signInManager;
            LocalizationResourceType = typeof(LocalizationResource);
        }

        public async Task<IActionResult> OnGetAsync(string logoutId)
        {
            if (string.IsNullOrEmpty(logoutId) == false)
            {
                var context = await IdentityServerInteractionService.GetLogoutContextAsync(logoutId);

                if (context == null)
                    return Redirect("~/");

                if (CurrentUser.IsAuthenticated)
                {
                    await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                    {
                        Identity = IdentitySecurityLogIdentityConsts.Identity,
                        Action = IdentitySecurityLogActionConsts.Logout,
                        ClientId = context.ClientId
                    });

                    await SignInManager.SignOutAsync();
                }

                return Redirect(context.PostLogoutRedirectUri);
            }
            else
            {
                if (CurrentUser.IsAuthenticated)
                {
                    await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                    {
                        Identity = IdentitySecurityLogIdentityConsts.Identity,
                        Action = IdentitySecurityLogActionConsts.Logout,
                        ClientId = null
                    });

                    await SignInManager.SignOutAsync();
                }

                return Redirect(ReturnUrl);
            }
        }
    }
}
