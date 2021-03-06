SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  HAMKA IRAMA
-- Create date:  24-Apr-2018  
-- Description: [SP_GET_ERROR_INFO]  
-- =============================================  
  
  
CREATE PROCEDURE [dbo].[SP_GET_ERROR_INFO]   
   
AS    
 INSERT INTO TbErrorLogs  
     ( ERR_NUMBER  
   ,ERR_SEVERITY  
   ,ERR_STAT  
   ,ERR_PROCEDURE  
   ,ERR_LINE  
   ,ERR_MESSAGE  
   ,CREATED_BY  
   ,CREATED_DATE  
   )  
 SELECT    
   ERROR_NUMBER() AS ErrorNumber    
  ,ERROR_SEVERITY() AS ErrorSeverity    
  ,ERROR_STATE() AS ErrorState    
  ,ERROR_PROCEDURE() AS ErrorProcedure    
  ,ERROR_LINE() AS ErrorLine    
  ,ERROR_MESSAGE() AS ErrorMessage  
  ,USER  
  ,GETDATE();   
GO
