ALTER TABLE [dbo].[BundleHeader] ADD CONSTRAINT [BUNDLE_HEADER_PK] PRIMARY KEY NONCLUSTERED  ([BundleHeaderId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
