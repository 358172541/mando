using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RequestLocalization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer.AspNetIdentity;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando.Pages.Account
{
    /// <summary>
    /// ref Volo.Abp.Account.Web.IdentityServer.Pages.IdentityServerSupportedLoginModel.cs
    /// </summary>
    public class LoginModel : AbpPageModel
    {
        public LanguageInfo Language { get; set; }
        public List<LanguageInfo> Languages { get; set; }
        public ILanguageProvider LanguageProvider { get; }

        [BindProperty] public LoginForm Form { get; set; }
        [BindProperty(SupportsGet = true), HiddenInput] public string ReturnUrl { get; set; }
        public IClientStore ClientStore { get; }
        public IEventService EventService { get; }
        public IdentitySecurityLogManager IdentitySecurityLogManager { get; }
        public IIdentityServerInteractionService IdentityServerInteractionService { get; }
        public IdentityUserManager IdentityUserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public LoginModel(
            ILanguageProvider languageProvider,
            IClientStore clientStore,
            IEventService eventService,
            IdentitySecurityLogManager identitySecurityLogManager,
            IIdentityServerInteractionService identityServerInteractionService,
            IdentityUserManager identityUserManager,
            SignInManager<IdentityUser> signInManager)
        {
            LanguageProvider = languageProvider;
            ClientStore = clientStore;
            EventService = eventService;
            IdentitySecurityLogManager = identitySecurityLogManager;
            IdentityServerInteractionService = identityServerInteractionService;
            IdentityUserManager = identityUserManager;
            SignInManager = signInManager;
            LocalizationResourceType = typeof(LocalizationResource);
        }

        private async Task GetLanguages()
        {
            var list = await LanguageProvider.GetLanguagesAsync();
            var item = list.FindByCulture(CultureInfo.CurrentCulture.Name, CultureInfo.CurrentUICulture.Name);
            if (item == null)
            {
                var pvdr = HttpContext.RequestServices.GetRequiredService<IAbpRequestLocalizationOptionsProvider>();
                var opts = await pvdr.GetLocalizationOptionsAsync();
                var check = opts.DefaultRequestCulture != null;
                var cultureName = check ? opts.DefaultRequestCulture.Culture.Name : CultureInfo.CurrentCulture.Name;
                var uiCultureName = check ? opts.DefaultRequestCulture.UICulture.Name : CultureInfo.CurrentUICulture.Name;
                var uiCultureDiaplayName = check ? opts.DefaultRequestCulture.UICulture.DisplayName : CultureInfo.CurrentUICulture.DisplayName;
                item = new LanguageInfo(cultureName, uiCultureName, uiCultureDiaplayName);
            }
            Language = item;
            Languages = list.Where(l => l != item).ToList();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Form = new LoginForm();

            var context = await IdentityServerInteractionService.GetAuthorizationContextAsync(ReturnUrl);

            if (context != null)
            {
                Form.UserName = context.LoginHint;

                var tenant = context.Parameters[TenantResolverConsts.DefaultTenantKey];

                if (string.IsNullOrEmpty(tenant) == false)
                {
                    CurrentTenant.Change(Guid.Parse(tenant));

                    Response.Cookies.Append(TenantResolverConsts.DefaultTenantKey, tenant);
                }
            }

            await GetLanguages();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            var context = await IdentityServerInteractionService.GetAuthorizationContextAsync(ReturnUrl);

            if (action == "Cancel")
            {
                if (context == null)
                    return Redirect("~/");

                await IdentityServerInteractionService.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);

                return Redirect(ReturnUrl);
            }

            ValidateModel();

            var result = await SignInManager.PasswordSignInAsync(Form.UserName, Form.Password, Form.Remember, true);

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
            {
                Identity = IdentitySecurityLogIdentityConsts.Identity,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = Form.UserName,
                ClientId = context?.Client?.ClientId
            });

            if (result.IsLockedOut)
            {
                ViewData["Message"] = L["UserLockedOutMessage"];
                await GetLanguages();
                return Page();
            }

            if (result.IsNotAllowed)
            {
                ViewData["Message"] = L["LoginIsNotAllowed"];
                await GetLanguages();
                return Page();
            }

            if (result.Succeeded == false)
            {
                ViewData["Message"] = L["InvalidUserNameOrPassword"];
                await GetLanguages();
                return Page();
            }

            var user = await IdentityUserManager.FindByNameAsync(Form.UserName);

            await EventService.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id.ToString(), user.UserName));

            return RedirectSafely(ReturnUrl); // safely
        }

        public class LoginForm
        {
            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
            public string UserName { get; set; }

            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string Password { get; set; }

            public bool Remember { get; set; }
        }
    }
}
