ALTER TABLE [lookup].[Country] ADD CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
