ALTER TABLE [dbo].[AuditValues] ADD CONSTRAINT [PK_AuditValues] PRIMARY KEY CLUSTERED  ([AuditId], [MemberName])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO