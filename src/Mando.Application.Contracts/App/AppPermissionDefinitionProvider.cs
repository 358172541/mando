using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando.App
{
    public class AppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext cntx)
        {
            var group = cntx.AddGroup(
                name: "App.Store",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store")
            );

            // #

            var authors = group.AddPermission(
                name: "App.Store.Authors",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Authors")
            );

            authors.AddChild(
                name: "App.Store.Authors.Create",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Authors.Create")
            );

            authors.AddChild(
                name: "App.Store.Authors.Update",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Authors.Update")
            );

            authors.AddChild(
                name: "App.Store.Authors.Delete",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Authors.Delete")
            );

            // #

            var books = group.AddPermission(
                    name: "App.Store.Books",
                    LocalizableString.Create<LocalizationResource>("Permission:App.Store.Books")
                );

            books.AddChild(
                name: "App.Store.Books.Create",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Books.Create")
            );

            books.AddChild(
                name: "App.Store.Books.Update",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Books.Update")
            );

            books.AddChild(
                name: "App.Store.Books.Delete",
                LocalizableString.Create<LocalizationResource>("Permission:App.Store.Books.Delete")
            ); 
        }
    }
}
