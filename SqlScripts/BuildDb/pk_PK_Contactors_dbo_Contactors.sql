ALTER TABLE [dbo].[Contactors] ADD CONSTRAINT [PK_Contactors] PRIMARY KEY CLUSTERED  ([ContactId], [PeopleId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO