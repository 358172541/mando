using Mando.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Mando.Permissions
{
    public class MandoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MandoPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(MandoPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Localization.LocalizationResource>(name);
        }
    }
}
