ALTER TABLE [dbo].[ResourceOrganization] ADD CONSTRAINT [PK_ResourceOrganization] PRIMARY KEY CLUSTERED  ([ResourceId], [OrganizationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
