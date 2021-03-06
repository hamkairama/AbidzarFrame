SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpMenuUpdate]
	@Id int = null,
	@NamaMenu varchar(100) = null,
	@ParentId int = null,
	@NamaParent varchar(100) = null,
	@NamaIcon varchar(50) = null,
	@MenuArea varchar(50) = null,
	@MenuController varchar(50) = null,
	@MenuAction varchar(50) = null,
	@MenuLink varchar(150) = null,
	@DieditOleh varchar(20) = null
AS
BEGIN TRANSACTION
BEGIN TRY
	SET NOCOUNT ON;

	UPDATE TbMenu SET NamaMenu = @NamaMenu, ParentId = @ParentId, NamaParent = @NamaParent, NamaIcon = @NamaIcon,
	MenuArea = @MenuArea, MenuController = @MenuController, MenuAction = @MenuAction, MenuLink = @MenuLink, DieditOleh = @DieditOleh, DieditTanggal = getdate() WHERE Id = @Id

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
