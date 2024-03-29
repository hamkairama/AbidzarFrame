SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author  : Hamka  
-- Create date : Januari 2019 
-- Description : get list of record from access right menus  
-- =============================================  
CREATE PROCEDURE [dbo].[SpMenuAccessRight]  
  @Nik varchar(16)
AS  
BEGIN  
 BEGIN TRANSACTION   
 BEGIN TRY 
  DECLARE @IdRole varchar(20)
  SELECT @IdRole = IdRole FROM TbUser WHERE Nik = @Nik
    
  --SELECT menu.* 
  --FROM TbMenu menu
  --INNER JOIN TbRoleMenu roleMenu ON roleMenu.IdMenu = menu.Id
  --WHERE roleMenu.IdRole = @IdRole
  --ORDER BY NamaMenu ASC
  

  CREATE TABLE #TempMenu (NamaParent varchar(100))
  INSERT INTO #TempMenu
  SELECT DISTINCT NamaParent FROM 
  (
	SELECT menu.* 
	FROM TbMenu menu
	INNER JOIN TbRoleMenu roleMenu ON roleMenu.IdMenu = menu.Id
	WHERE roleMenu.IdRole = @IdRole
  ) TBLE
  WHERE NamaParent IS NOT NULL

  SELECT menu.* 
  FROM TbMenu menu
  INNER JOIN TbRoleMenu roleMenu ON roleMenu.IdMenu = menu.Id
  WHERE roleMenu.IdRole = @IdRole AND menu.MenuController IS NOT NULL
  --ORDER BY NamaMenu ASC
  UNION ALL
  SELECT menu.* 
  FROM TbMenu menu
  WHERE menu.NamaMenu in 
  (
	SELECT * FROM #TempMenu
  )
  AND menu.MenuController IS NULL

  COMMIT TRANSACTION;  
  DROP TABLE #TempMenu   
   
 END TRY  
 BEGIN CATCH  
  ROLLBACK TRANSACTION  
  EXEC SP_GET_ERROR_INFO  
  SELECT ERROR_MESSAGE(), ERROR_NUMBER()  
  DECLARE @tempError VARCHAR(500) = ERROR_MESSAGE()  
  RAISERROR (@tempError, 16, 1)
  DROP TABLE #TempMenu   
  
 END CATCH  
  
END
GO
