ALTER TABLE [dbo].[words] ADD CONSTRAINT [PK_words_1] PRIMARY KEY CLUSTERED  ([word])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
