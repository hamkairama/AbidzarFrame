SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpMenuInsert]
	@NamaMenu varchar(100) = null,
	@ParentId int = null,
	@NamaParent varchar(100) = null,
	@NamaIcon varchar(50) = null,
	@MenuArea varchar(50) = null,
	@MenuController varchar(50) = null,
	@MenuAction varchar(50) = null,
	@MenuLink varchar(150) = null,
	@DibuatOleh varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO TbMenu (NamaMenu, ParentId, NamaParent, NamaIcon, MenuArea, MenuController, MenuAction, MenuLink, DibuatOleh) 
	VALUES (@NamaMenu, @ParentId, @NamaParent, @NamaIcon, @MenuArea, @MenuController, @MenuAction, @MenuLink, @DibuatOleh)

COMMIT TRANSACTION
	
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
    EXEC SP_GET_ERROR_INFO  
	SELECT ERROR_MESSAGE(), ERROR_NUMBER()
	DECLARE @tempError VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR (@tempError, 16, 1)
END CATCH

GO
