
DELETE FROM [dbo].[AbpClaimTypes]
DELETE FROM [dbo].[AbpPermissionGrants]
DELETE FROM [dbo].[AbpUsers]
DELETE FROM [dbo].[AbpRoles]
DELETE FROM [dbo].[AbpUserRoles]
DELETE FROM [dbo].[IdentityServerApiResources]
DELETE FROM [dbo].[IdentityServerApiResourceClaims]
DELETE FROM [dbo].[IdentityServerApiResourceScopes]
DELETE FROM [dbo].[IdentityServerApiScopes]
DELETE FROM [dbo].[IdentityServerClients]
DELETE FROM [dbo].[IdentityServerClientCorsOrigins]
DELETE FROM [dbo].[IdentityServerClientGrantTypes]
DELETE FROM [dbo].[IdentityServerClientPostLogoutRedirectUris]
DELETE FROM [dbo].[IdentityServerClientRedirectUris]
DELETE FROM [dbo].[IdentityServerClientScopes]
DELETE FROM [dbo].[IdentityServerClientSecrets]
DELETE FROM [dbo].[IdentityServerIdentityResources]
DELETE FROM [dbo].[IdentityServerIdentityResourceClaims]

/* App */
DELETE FROM [dbo].[AppAuthors];
DELETE FROM [dbo].[AppBooks];

--

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'4b0f0a32-184c-624b-87d8-3a0138d02db9',
	'sub',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'c3f3ca7ede474b9797ebe5ab67ae6d2c'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'b47b7355-c976-9374-892f-3a0138d02ef4',
	'name',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'0bf78dd6529f416fb4b99dd2e2087b41'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'cf25cee6-a76a-d2d7-66ce-3a0138d02ef5',
	'family_name',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'632aead5156847e08f53644b7589ccc9'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'8ff18f38-431e-2c2a-3301-3a0138d02ef7',
	'given_name',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'd3c8d45048514cf592df2715fbd44fcf'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'd90e26dd-a500-507e-7d73-3a0138d02ef8',
	'middle_name',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'd29317d9e55b48b586e705e792d57c02'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'06574c38-0942-b81c-c517-3a0138d02ef9',
	'nickname',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'317f914525ab4b50a632a4d5ea19f4f8'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'875c28c9-4f33-4b80-ae1d-3a0138d02efb',
	'preferred_username',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'87bb58751f414db3a02696f579b93f81'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'3cd678e7-6678-b75a-487c-3a0138d02efc',
	'profile',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'78f1b4516e764569bd758f33aeb3f4d5'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'94695a15-230c-9d1d-e8e4-3a0138d02efd',
	'picture',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'9e8c84e415444e0fb3ee6c220ddecf90'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'20b7a293-f793-0b5f-ea15-3a0138d02efe',
	'website',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'ee9f00f8d4aa413cbad61a4e020fd3e6'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'27e24332-d80e-b6c4-9c8b-3a0138d02eff',
	'gender',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'547385db86fb47388201a1dbd79ae49d'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'4171645c-425d-e759-0a60-3a0138d02f00',
	'birthdate',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'818655b75bda4d2289ecb99e01016cb8'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'19d3fab1-4dc0-3a9c-a40a-3a0138d02f02',
	'zoneinfo',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'75e2a196c183458ca844e3e97d2960bc'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'731f3d99-41dc-0da6-09ce-3a0138d02f03',
	'locale',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'5f366ff82d324521a5b5959921148d0c'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'0211e107-ead8-aa7e-5c07-3a0138d02f04',
	'updated_at',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'97f3dfb43a0b422498e0eb463eb960d0'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'd10df4f6-0987-9f24-610f-3a0138d02f0d',
	'email',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'66dd7bde9a9749c982549fe37d11dbe7'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'e506ee53-a71c-cd41-9ea5-3a0138d02f0e',
	'email_verified',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'4e20f64b3dcc419296dfb44704a0cb38'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'b015c386-cf29-201b-734d-3a0138d02f10',
	'address',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'13df4fc2b4f949c6bd19cc1162317e24'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'2f7e3302-6f4e-f74c-e53c-3a0138d02f13',
	'phone_number',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'51f50ede0e8840928e526f96afb979ae'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'dd77087a-fa79-a59f-285d-3a0138d02f14',
	'phone_number_verified',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'262ba3b7cc974d1d930b6415264aa355'
);

INSERT INTO [dbo].[AbpClaimTypes] (
	[Id],
	[Name],
	[Required],
	[IsStatic],
	[Regex],
	[RegexDescription],
	[Description],
	[ValueType],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'b0907bac-7c09-4418-0c75-3a0138d02f16',
	'role',
	'False',
	'True',
	NULL,
	NULL,
	NULL,
	0,
	'{}',
	'e4779eff9a3f40bebf1772efca889d24'
);

--

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'6f8e6569-76c9-912f-0a4d-3a0138d02b99',
	NULL,
	'FeatureManagement.ManageHostFeatures',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'e59e7828-59d5-a594-a95f-3a0138d02bab',
	NULL,
	'AbpIdentity.Roles',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'83f3ce69-01ce-a32a-ebfb-3a0138d02bad',
	NULL,
	'AbpIdentity.Roles.Create',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'64ee8d9f-575c-68fb-d085-3a0138d02baf',
	NULL,
	'AbpIdentity.Roles.Update',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'719ca0a7-77a1-f56e-6384-3a0138d02bb2',
	NULL,
	'AbpIdentity.Roles.Delete',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'78be19fb-1bcd-aeb4-cf35-3a0138d02bb4',
	NULL,
	'AbpIdentity.Roles.ManagePermissions',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'956ab25d-d2ed-738d-4642-3a0138d02bb5',
	NULL,
	'AbpIdentity.Users',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'8c36a31b-2874-a246-0c93-3a0138d02bb7',
	NULL,
	'AbpIdentity.Users.Create',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'de15268e-4b66-027c-bd94-3a0138d02bdd',
	NULL,
	'AbpIdentity.Users.Update',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'14b34613-988a-0f34-a865-3a0138d02bde',
	NULL,
	'AbpIdentity.Users.Delete',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'961be67f-4f26-05fe-acca-3a0138d02be0',
	NULL,
	'AbpIdentity.Users.ManagePermissions',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'8d2024ab-98c9-a6e0-df11-3a0138d02be2',
	NULL,
	'AbpTenantManagement.Tenants',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'bc5aa868-11dd-4991-8298-3a0138d02be3',
	NULL,
	'AbpTenantManagement.Tenants.Create',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'049fcc48-57f8-2f07-6986-3a0138d02be5',
	NULL,
	'AbpTenantManagement.Tenants.Update',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'46c6716b-e489-843c-c9e5-3a0138d02be6',
	NULL,
	'AbpTenantManagement.Tenants.Delete',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'2d00edbf-394a-ce11-63f8-3a0138d02be7',
	NULL,
	'AbpTenantManagement.Tenants.ManageFeatures',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'd9fdb044-b415-5e3c-d1e3-3a0138d02be8',
	NULL,
	'AbpTenantManagement.Tenants.ManageConnectionStrings',
	'R',
	'admin'
);

/* App */

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B1',
	NULL,
	'App.Authors',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B2',
	NULL,
	'App.Authors.Create',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B3',
	NULL,
	'App.Authors.Update',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B4',
	NULL,
	'App.Authors.Delete',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B5',
	NULL,
	'App.Books',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B6',
	NULL,
	'App.Books.Create',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B7',
	NULL,
	'App.Books.Update',
	'R',
	'admin'
);

INSERT INTO [dbo].[AbpPermissionGrants] (
	[Id],
	[TenantId],
	[Name],
	[ProviderName],
	[ProviderKey]
) VALUES (
	'05A33857-1E90-4FEF-9473-E880AD0AE1B8',
	NULL,
	'App.Books.Delete',
	'R',
	'admin'
);

--

INSERT INTO [dbo].[AbpUsers] (
	[Id],
	[TenantId],
	[UserName],
	[NormalizedUserName],
	[Name],
	[Surname],
	[Email],
	[NormalizedEmail],
	[EmailConfirmed],
	[PasswordHash],
	[SecurityStamp],
	[IsExternal],
	[PhoneNumber],
	[PhoneNumberConfirmed],
	[TwoFactorEnabled],
	[LockoutEnd],
	[LockoutEnabled],
	[AccessFailedCount],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'e90d4046-05b4-537b-4134-3a0138d023d8',
	NULL,
	'admin',
	'ADMIN',
	'admin',
	NULL,
	'admin@abp.io',
	'ADMIN@ABP.IO',
	'False',
	'AQAAAAEAACcQAAAAED8S/+FhaEkegdo59zTk212iaz+d6r60V6QgrEtYMEHkx4LZjcJA2hPBOptrbCVI9A==',
	'PVZTORKN73OAA27WCZLQ52VP7KGCQVB6',
	'False',
	NULL,
	'False',
	'False',
	NULL,
	'True',
	0,
	'{}',
	'af60099b3d734da5a18533ba5ed84e50',
	'2022/1/5 3:49:03',
	NULL,
	'2022/1/5 3:49:04',
	NULL,
	'False',
	NULL,
	NULL
);

--

INSERT INTO [dbo].[AbpRoles] (
	[Id],
	[TenantId],
	[Name],
	[NormalizedName],
	[IsDefault],
	[IsStatic],
	[IsPublic],
	[ExtraProperties],
	[ConcurrencyStamp]
) VALUES (
	'40b10a16-cb30-ed64-cfce-3a0138d028d5',
	NULL,
	'admin',
	'ADMIN',
	'False',
	'True',
	'True',
	'{}',
	'ac818de0-e434-4a8a-9b74-22f0c652fbfd'
);

--

INSERT INTO [dbo].[AbpUserRoles] (
	[UserId],
	[RoleId],
	[TenantId]
) VALUES (
	'e90d4046-05b4-537b-4134-3a0138d023d8',
	'40b10a16-cb30-ed64-cfce-3a0138d028d5',
	NULL
);

--

INSERT INTO [dbo].[IdentityServerApiResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[AllowedAccessTokenSigningAlgorithms],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64',
	'Mando',
	'Mando API',
	NULL,
	'True',
	NULL,
	'True',
	'{}',
	'9e91503e78a343a7b713a3d085fb165e',
	'2022/1/5 3:49:06',
	NULL,
	'2022/1/5 3:49:06',
	NULL,
	'False',
	NULL,
	NULL
);

--

INSERT INTO [dbo].[IdentityServerApiResourceClaims] (
	[Type],
	[ApiResourceId]
) VALUES (
	'email',
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64'
);

INSERT INTO [dbo].[IdentityServerApiResourceClaims] (
	[Type],
	[ApiResourceId]
) VALUES (
	'email_verified',
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64'
);

INSERT INTO [dbo].[IdentityServerApiResourceClaims] (
	[Type],
	[ApiResourceId]
) VALUES (
	'name',
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64'
);

INSERT INTO [dbo].[IdentityServerApiResourceClaims] (
	[Type],
	[ApiResourceId]
) VALUES (
	'phone_number',
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64'
);

INSERT INTO [dbo].[IdentityServerApiResourceClaims] (
	[Type],
	[ApiResourceId]
) VALUES (
	'phone_number_verified',
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64'
);

INSERT INTO [dbo].[IdentityServerApiResourceClaims] (
	[Type],
	[ApiResourceId]
) VALUES (
	'role',
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64'
);

--

INSERT INTO [dbo].[IdentityServerApiResourceScopes] (
	[ApiResourceId],
	[Scope]
) VALUES (
	'3cab4bf2-a2f8-20a2-da19-3a0138d02f64',
	'Mando'
);

--

INSERT INTO [dbo].[IdentityServerApiScopes] (
	[Id],
	[Enabled],
	[Name],
	[DisplayName],
	[Description],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'b7171a88-e167-6bfd-3e71-3a0138d03073',
	'True',
	'Mando',
	'Mando API',
	NULL,
	'False',
	'False',
	'True',
	'{}',
	'ccda25051c9b4886be6ffca92829a7e6',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

--

INSERT INTO [dbo].[IdentityServerClients] (
	[Id],
	[ClientId],
	[ClientName],
	[Description],
	[ClientUri],
	[LogoUri],
	[Enabled],
	[ProtocolType],
	[RequireClientSecret],
	[RequireConsent],
	[AllowRememberConsent],
	[AlwaysIncludeUserClaimsInIdToken],
	[RequirePkce],
	[AllowPlainTextPkce],
	[RequireRequestObject],
	[AllowAccessTokensViaBrowser],
	[FrontChannelLogoutUri],
	[FrontChannelLogoutSessionRequired],
	[BackChannelLogoutUri],
	[BackChannelLogoutSessionRequired],
	[AllowOfflineAccess],
	[IdentityTokenLifetime],
	[AllowedIdentityTokenSigningAlgorithms],
	[AccessTokenLifetime],
	[AuthorizationCodeLifetime],
	[ConsentLifetime],
	[AbsoluteRefreshTokenLifetime],
	[SlidingRefreshTokenLifetime],
	[RefreshTokenUsage],
	[UpdateAccessTokenClaimsOnRefresh],
	[RefreshTokenExpiration],
	[AccessTokenType],
	[EnableLocalLogin],
	[IncludeJwtId],
	[AlwaysSendClientClaims],
	[ClientClaimsPrefix],
	[PairWiseSubjectSalt],
	[UserSsoLifetime],
	[UserCodeType],
	[DeviceCodeLifetime],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'Mando_App',
	'Mando_App',
	'Mando_App',
	NULL,
	NULL,
	'True',
	'oidc',
	'False',
	'False',
	'True',
	'True',
	'False',
	'False',
	'False',
	'False',
	NULL,
	'True',
	NULL,
	'True',
	'True',
	300,
	NULL,
	31536000,
	300,
	NULL,
	31536000,
	1296000,
	1,
	'False',
	1,
	0,
	'True',
	'False',
	'False',
	'client_',
	NULL,
	NULL,
	NULL,
	300,
	'{}',
	'c3a263d0c15e462ba0c97dc7a67d5fa1',
	'2022/1/5 3:49:06',
	NULL,
	'2022/1/5 3:49:06',
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerClients] (
	[Id],
	[ClientId],
	[ClientName],
	[Description],
	[ClientUri],
	[LogoUri],
	[Enabled],
	[ProtocolType],
	[RequireClientSecret],
	[RequireConsent],
	[AllowRememberConsent],
	[AlwaysIncludeUserClaimsInIdToken],
	[RequirePkce],
	[AllowPlainTextPkce],
	[RequireRequestObject],
	[AllowAccessTokensViaBrowser],
	[FrontChannelLogoutUri],
	[FrontChannelLogoutSessionRequired],
	[BackChannelLogoutUri],
	[BackChannelLogoutSessionRequired],
	[AllowOfflineAccess],
	[IdentityTokenLifetime],
	[AllowedIdentityTokenSigningAlgorithms],
	[AccessTokenLifetime],
	[AuthorizationCodeLifetime],
	[ConsentLifetime],
	[AbsoluteRefreshTokenLifetime],
	[SlidingRefreshTokenLifetime],
	[RefreshTokenUsage],
	[UpdateAccessTokenClaimsOnRefresh],
	[RefreshTokenExpiration],
	[AccessTokenType],
	[EnableLocalLogin],
	[IncludeJwtId],
	[AlwaysSendClientClaims],
	[ClientClaimsPrefix],
	[PairWiseSubjectSalt],
	[UserSsoLifetime],
	[UserCodeType],
	[DeviceCodeLifetime],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'Mando_Swagger',
	'Mando_Swagger',
	'Mando_Swagger',
	NULL,
	NULL,
	'True',
	'oidc',
	'False',
	'False',
	'True',
	'True',
	'False',
	'False',
	'False',
	'False',
	NULL,
	'True',
	NULL,
	'True',
	'True',
	300,
	NULL,
	31536000,
	300,
	NULL,
	31536000,
	1296000,
	1,
	'False',
	1,
	0,
	'True',
	'False',
	'False',
	'client_',
	NULL,
	NULL,
	NULL,
	300,
	'{}',
	'ee5134ef405a45dd9b150a202a7d197d',
	'2022/1/5 3:49:06',
	NULL,
	'2022/1/5 3:49:06',
	NULL,
	'False',
	NULL,
	NULL
);

--

INSERT INTO [dbo].[IdentityServerClientCorsOrigins] (
	[ClientId],
	[Origin]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'http://localhost:4200'
);

INSERT INTO [dbo].[IdentityServerClientCorsOrigins] (
	[ClientId],
	[Origin]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'https://localhost:44314'
);

--

INSERT INTO [dbo].[IdentityServerClientGrantTypes] (
	[ClientId],
	[GrantType]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'authorization_code'
);

INSERT INTO [dbo].[IdentityServerClientGrantTypes] (
	[ClientId],
	[GrantType]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'client_credentials'
);

INSERT INTO [dbo].[IdentityServerClientGrantTypes] (
	[ClientId],
	[GrantType]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'password'
);

INSERT INTO [dbo].[IdentityServerClientGrantTypes] (
	[ClientId],
	[GrantType]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'authorization_code'
);

--

INSERT INTO [dbo].[IdentityServerClientPostLogoutRedirectUris] (
	[ClientId],
	[PostLogoutRedirectUri]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'http://localhost:4200'
);

--

INSERT INTO [dbo].[IdentityServerClientRedirectUris] (
	[ClientId],
	[RedirectUri]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'http://localhost:4200'
);

INSERT INTO [dbo].[IdentityServerClientRedirectUris] (
	[ClientId],
	[RedirectUri]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'https://localhost:44314/swagger/oauth2-redirect.html'
);

--

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'address'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'email'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'Mando'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'openid'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'phone'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'profile'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	'role'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'address'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'email'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'Mando'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'openid'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'phone'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'profile'
);

INSERT INTO [dbo].[IdentityServerClientScopes] (
	[ClientId],
	[Scope]
) VALUES (
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	'role'
);

--

INSERT INTO [dbo].[IdentityServerClientSecrets] (
	[Type],
	[Value],
	[ClientId],
	[Description],
	[Expiration]
) VALUES (
	'SharedSecret',
	'E5Xd4yMqjP5kjWFKrYgySBju6JVfCzMyFp7n2QmMrME=',
	'127d0309-9c5e-569c-7b9a-3a0138d03161',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerClientSecrets] (
	[Type],
	[Value],
	[ClientId],
	[Description],
	[Expiration]
) VALUES (
	'SharedSecret',
	'E5Xd4yMqjP5kjWFKrYgySBju6JVfCzMyFp7n2QmMrME=',
	'76b02a69-26c9-6220-16f4-3a0138d03235',
	NULL,
	NULL
);

--

INSERT INTO [dbo].[IdentityServerIdentityResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'db59ca48-5b0d-6df0-bb9b-3a0138d02ea4',
	'openid',
	'Your user identifier',
	NULL,
	'True',
	'True',
	'False',
	'True',
	'{}',
	'ed53270846ed471c832ce1182e66b360',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerIdentityResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05',
	'profile',
	'User profile',
	'Your user profile information (first name, last name, etc.)',
	'True',
	'False',
	'True',
	'True',
	'{}',
	'6965e019aec444eab91060dbdd81bbe8',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerIdentityResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'10b532ac-404e-eaaa-3850-3a0138d02f0f',
	'email',
	'Your email address',
	NULL,
	'True',
	'False',
	'True',
	'True',
	'{}',
	'9679b254583241f0bed88ed764839a40',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerIdentityResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'f4a43902-2063-90d8-01bf-3a0138d02f11',
	'address',
	'Your postal address',
	NULL,
	'True',
	'False',
	'True',
	'True',
	'{}',
	'df16802ff1b34fadb4d5638d6829b0ac',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerIdentityResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'74f5c9a3-c027-d134-143e-3a0138d02f15',
	'phone',
	'Your phone number',
	NULL,
	'True',
	'False',
	'True',
	'True',
	'{}',
	'b9792392b4744f1fa5da7cb5110fcfbd',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[IdentityServerIdentityResources] (
	[Id],
	[Name],
	[DisplayName],
	[Description],
	[Enabled],
	[Required],
	[Emphasize],
	[ShowInDiscoveryDocument],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'1ef2ba33-e221-d435-1a7c-3a0138d02f17',
	'role',
	'Roles of the user',
	NULL,
	'True',
	'False',
	'False',
	'True',
	'{}',
	'1d669a9e9a1b42d4a5deb16eeb73ecfe',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

--

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'sub',
	'db59ca48-5b0d-6df0-bb9b-3a0138d02ea4'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'birthdate',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'family_name',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'gender',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'given_name',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'locale',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'middle_name',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'name',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'nickname',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'picture',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'preferred_username',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'profile',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'updated_at',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'website',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'zoneinfo',
	'bfb63072-3a2a-fc25-b11a-3a0138d02f05'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'email',
	'10b532ac-404e-eaaa-3850-3a0138d02f0f'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'email_verified',
	'10b532ac-404e-eaaa-3850-3a0138d02f0f'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'address',
	'f4a43902-2063-90d8-01bf-3a0138d02f11'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'phone_number',
	'74f5c9a3-c027-d134-143e-3a0138d02f15'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'phone_number_verified',
	'74f5c9a3-c027-d134-143e-3a0138d02f15'
);

INSERT INTO [dbo].[IdentityServerIdentityResourceClaims] (
	[Type],
	[IdentityResourceId]
) VALUES (
	'role',
	'1ef2ba33-e221-d435-1a7c-3a0138d02f17'
);

/* Default.Authors */

INSERT INTO [dbo].[AppAuthors] (
	[Id],
	[Name],
	[Birthday],
	[Biography],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'45167A79-20F7-401A-9051-C1A4365B9246',
	'Man',
	'2022/2/2 2:22:22',
	NULL,
	'{}',
	'1d669a9e9a1b42d4a5deb16eeb73ecza',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[AppAuthors] (
	[Id],
	[Name],
	[Birthday],
	[Biography],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]
) VALUES (
	'45167A79-20F7-401A-9051-C1A4365B9247',
	'Woman',
	'2022/2/2 2:22:22',
	NULL,
	'{}',
	'1d669a9e9a1b42d4a5deb16eeb73ecza',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);

INSERT INTO [dbo].[AppBooks] (
	[Id],
	[AuthorId],
	[Name],
	[Type],
	[PublishDate],
	[Price],
	[ExtraProperties],
	[ConcurrencyStamp],
	[CreationTime],
	[CreatorId],
	[LastModificationTime],
	[LastModifierId],
	[IsDeleted],
	[DeleterId],
	[DeletionTime]        
) VALUES (
	'A0F5A862-EE91-4A3E-B351-9921A64CBE1C',
	'45167A79-20F7-401A-9051-C1A4365B9247',
	'Programing',
	1,
	'2022/2/2 2:22:22',
	1.1,
	'{}',
	'1d669a9e9a1b42d4a5deb16eeb73ecza',
	'2022/1/5 3:49:06',
	NULL,
	NULL,
	NULL,
	'False',
	NULL,
	NULL
);