﻿using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas.Host;

namespace TTH.MonkBlog
{
    [DependsOn(
        typeof(MonkBlogDomainSharedModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(SaasHostApplicationContractsModule),
        typeof(AbpAuditLoggingApplicationContractsModule),
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpAccountPublicApplicationContractsModule),
        typeof(AbpAccountAdminApplicationContractsModule),
        typeof(LanguageManagementApplicationContractsModule),
        typeof(LeptonThemeManagementApplicationContractsModule),
        typeof(TextTemplateManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class MonkBlogApplicationContractsModule : AbpModule
    {

    }
}
