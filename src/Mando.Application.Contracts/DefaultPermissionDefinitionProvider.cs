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
                name: "Default",
                LocalizableString.Create<LocalizationResource>("Permission:Default")
            );

            var authors = group.AddPermission(
                name: "Default.Authors",
                LocalizableString.Create<LocalizationResource>("Permission:Default.Authors")
            );

            authors.AddChild(
                name: "Default.Authors.Create",
                LocalizableString.Create<LocalizationResource>("Permission:Default.Authors.Create")
            );

            authors.AddChild(
                name: "Default.Authors.Update",
                LocalizableString.Create<LocalizationResource>("Permission:Default.Authors.Update")
            );

            authors.AddChild(
                name: "Default.Authors.Delete",
                LocalizableString.Create<LocalizationResource>("Permission:Default.Authors.Delete")
            );
        }
    }
}
