using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using LocalizationResource = Mando.Localization.LocalizationResource;

namespace Mando
{
    public class DefaultPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext cntx)
        {
            var group = cntx.AddGroup(
                name: "App",
                LocalizableString.Create<LocalizationResource>("Permission:App")
            );

            // #

            var authors = group.AddPermission(
                name: "App.Authors",
                LocalizableString.Create<LocalizationResource>("Permission:App.Authors")
            );

            authors.AddChild(
                name: "App.Authors.Create",
                LocalizableString.Create<LocalizationResource>("Permission:App.Authors.Create")
            );

            authors.AddChild(
                name: "App.Authors.Update",
                LocalizableString.Create<LocalizationResource>("Permission:App.Authors.Update")
            );

            authors.AddChild(
                name: "App.Authors.Delete",
                LocalizableString.Create<LocalizationResource>("Permission:App.Authors.Delete")
            );

            // #

            var books = group.AddPermission(
                    name: "App.Books",
                    LocalizableString.Create<LocalizationResource>("Permission:App.Books")
                );

            books.AddChild(
                name: "App.Books.Create",
                LocalizableString.Create<LocalizationResource>("Permission:App.Books.Create")
            );

            books.AddChild(
                name: "App.Books.Update",
                LocalizableString.Create<LocalizationResource>("Permission:App.Books.Update")
            );

            books.AddChild(
                name: "App.Books.Delete",
                LocalizableString.Create<LocalizationResource>("Permission:App.Books.Delete")
            ); 
        }
    }
}
