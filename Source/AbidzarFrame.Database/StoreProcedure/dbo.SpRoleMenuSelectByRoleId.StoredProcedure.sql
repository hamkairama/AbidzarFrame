SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Create by	: Hamka
-- Create date	: 2018 
-- Description	: select all menu role by role id
-- =============================================
CREATE PROCEDURE [dbo].[SpRoleMenuSelectByRoleId] 
@IdRole VARCHAR(10) 

AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY		 
	DECLARE @tempTable TABLE (IdRole varchar(50), NamaRole varchar(100), IdMenu int, NamaMenu varchar(100), ParentId int, NamaParent varchar(100), MenuArea varchar(50), NamaIcon varchar(50), MenuController varchar(50), HaveAccess bit, Child int)
		
		-- insert data seluruh menu
		INSERT @tempTable (IdRole, NamaRole, IdMenu, NamaMenu, ParentId, NamaParent, MenuArea, NamaIcon, MenuController, HaveAccess, Child)
		SELECT @IdRole, (select TOP 1 NamaRole from TbRole WITH(NOLOCK) where IdRole = @IdRole),  me.Id, me.NamaMenu, ISNULL(me.ParentId, me.Id), me.NamaParent, me.MenuArea, me.NamaIcon, me.MenuController, 0, 
		case when me.ParentId IN (select  a.ParentId from TbMenu a WITH(NOLOCK) where a.Id = (me.Id +1) OR Id = (me.Id -1)) then 1 else 0 end as Child
		--ISNULL(me.Sequence, me.ParentId)
		--me.Sequence
		FROM TbMenu me WITH(NOLOCK)
		--WHERE me.IS_DELETED = 0
		ORDER BY me.id
		
		-- update aksesnya berdasarkan role
		UPDATE me
		SET HaveAccess = 1
		FROM @tempTable me
		INNER JOIN TbRoleMenu te ON me.IdMenu = te.IdMenu and me.IdRole = te.IdRole
		WHERE te.IdRole = @IdRole
	
		--update only this
		UPDATE @tempTable set CHILD = 1 where IdMenu IN (3,229,263,265,306)
		
		SELECT * FROM @tempTable
		WHERE IdRole <> ''	 
		ORDER BY ParentId, Child, NamaParent
		 
		  
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		EXEC SP_GET_ERROR_INFO 
		SELECT ERROR_MESSAGE(), ERROR_NUMBER()
		DECLARE @tempError VARCHAR(500) = ERROR_MESSAGE()
		RAISERROR (@tempError, 16, 1)
	END CATCH

END
GO
