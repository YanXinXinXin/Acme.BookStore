using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Acme.BookStore
{
    [DependsOn(
        typeof(BookStoreDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(BookStoreApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    public class BookStoreApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BookStoreApplicationModule>();
            });
        Configure<RazorPagesOptions>(options =>
         {
           options.Conventions.AuthorizePage("/Books/Index", BookStorePermissions.Books.Default);
           options.Conventions.AuthorizePage("/Books/CreateModal", BookStorePermissions.Books.Create);
           options.Conventions.AuthorizePage("/Books/EditModal", BookStorePermissions.Books.Edit);
         });
    }
    }
}
