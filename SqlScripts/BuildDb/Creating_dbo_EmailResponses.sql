CREATE TABLE [dbo].[EmailResponses]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[EmailQueueId] [int] NOT NULL,
[PeopleId] [int] NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Dt] [datetime] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
