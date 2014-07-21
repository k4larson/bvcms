
CREATE VIEW [dbo].Churches
AS
SELECT c FROM (
SELECT OtherNewChurch c FROM dbo.People
UNION 
SELECT OtherPreviousChurch c FROM dbo.People
) AS t
GROUP BY c

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO