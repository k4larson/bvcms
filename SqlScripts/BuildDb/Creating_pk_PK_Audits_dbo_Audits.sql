ALTER TABLE [dbo].[Audits] ADD CONSTRAINT [PK_Audits] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
