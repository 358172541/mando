using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.Autofac;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.Swashbuckle;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    [DependsOn(
        typeof(ApplicationModule),
        typeof(EntityFrameworkCoreModule),
        typeof(HttpApiModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreMvcUiModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityAspNetCoreModule),
        typeof(AbpSwashbuckleModule)
    )]
    public class HttpApiHostModule : AbpModule
    {
        private static IList<LanguageInfo> LanguageInfoList =>
            new List<LanguageInfo>
            {
                new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"),
                new LanguageInfo("en", "en", "English")
            };
        private static IList<CultureInfo> CultureInfoList =>
            LanguageInfoList
                .Select(x => new CultureInfo(x.CultureName))
                .ToList();
        private static IList<IRequestCultureProvider> RequestCultureProviderList =>
            new List<IRequestCultureProvider>
            {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
            };

        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(budr => budr
                    .ConfigureServices(svcs => svcs
                        .AddApplication<HttpApiHostModule>())
                    .Configure(budr =>
                    {
                        budr.ApplicationServices
                            .GetRequiredService<ISettingDefinitionManager>()
                            .Get(LocalizationSettingNames.DefaultLanguage)
                                .DefaultValue = LanguageInfoList[0].CultureName; // zh-Hans
                        budr.InitializeApplication();
                    }))
                .UseAutofac();

        private static void ConfigureAuthentication(ServiceConfigurationContext cntx, IConfiguration cfgr)
        {
            cntx.Services
                .AddAuthentication()
                .AddJwtBearer(opts =>
                {
                    opts.Audience = "Mando";
                    opts.Authority = cfgr["AuthServer:Authority"];
                    opts.BackchannelHttpHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                    opts.RequireHttpsMetadata = Convert.ToBoolean(cfgr["AuthServer:RequireHttpsMetadata"]);
                });
        }
        private static void ConfigureCors(ServiceConfigurationContext cntx, IConfiguration cfgr)
        {
            cntx.Services
                .AddCors(opts =>
                {
                    opts.AddDefaultPolicy(budr =>
                    {
                        budr.WithOrigins(
                                cfgr["App:CorsOrigins"]
                                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(o => o.RemovePostFix("/"))
                                    .ToArray()
                            )
                            .WithAbpExposedHeaders()
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
                });
        }
        private static void ConfigureSwagger(ServiceConfigurationContext cntx, IConfiguration cfgr)
        {
            cntx.Services
                .AddAbpSwaggerGenWithOAuth(
                    cfgr["AuthServer:Authority"],
                    new Dictionary<string, string>
                    {
                        {"Mando", "Mando API"}
                    },
                    opts =>
                    {
                        opts.CustomSchemaIds(type => type.FullName);
                        opts.DocInclusionPredicate((name, desc) => true);
                        opts.SwaggerDoc("v1", new OpenApiInfo { Title = "Mando API", Version = "v1" });
                    });
        }

        public override void PreConfigureServices(ServiceConfigurationContext cntx)
        {
            PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(opts =>
            {
                opts.AddAssemblyResource(typeof(LocalizationResource), typeof(HttpApiHostModule).Assembly);
            });
        }
        public override void ConfigureServices(ServiceConfigurationContext cntx)
        {
            var cfgr = cntx.Services.GetConfiguration();

            Configure<AbpAspNetCoreMvcOptions>(opts =>
            {
                opts.ConventionalControllers.Create(typeof(ApplicationModule).Assembly);
            });

            Configure<AbpLocalizationOptions>(opts =>
            {
                LanguageInfoList.ToList().ForEach(x => opts.Languages.Add(x));
            });

            ConfigureAuthentication(cntx, cfgr);
            ConfigureCors(cntx, cfgr);
            ConfigureSwagger(cntx, cfgr);
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext cntx)
        {
            var budr = cntx.GetApplicationBuilder();
            var cfgr = cntx.GetConfiguration();
            
            budr.UseDeveloperExceptionPage();

            budr.UseAbpRequestLocalization(opts =>
                {
                    opts.DefaultRequestCulture = new RequestCulture(
                        budr.ApplicationServices
                            .GetRequiredService<ISettingDefinitionManager>()
                            .Get(LocalizationSettingNames.DefaultLanguage).DefaultValue); // zh-Hans
                    opts.SupportedCultures = CultureInfoList;
                    opts.SupportedUICultures = CultureInfoList;
                    opts.RequestCultureProviders = RequestCultureProviderList;
                });

            budr.UseCorrelationId();
            budr.UseStaticFiles();
            budr.UseRouting();
            budr.UseCors();
            budr.UseAuthentication();
            budr.UseJwtTokenMiddleware();
            budr.UseMultiTenancy();
            budr.UseUnitOfWork();
            budr.UseIdentityServer();
            budr.UseAuthorization();

            budr.UseSwagger();
            budr.UseAbpSwaggerUI(opts =>
                {
                    opts.OAuthClientId(cfgr["AuthServer:SwaggerClientId"]);
                    opts.OAuthClientSecret(cfgr["AuthServer:SwaggerClientSecret"]);
                    opts.OAuthScopes("Mando");

                    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Mando API");
                });

            budr.UseAuditing();
            budr.UseConfiguredEndpoints();
        }
    }
}
