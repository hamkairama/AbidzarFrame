SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Hamka Irama  
-- Create date: Agustus 2018  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[SpAppointmentDiaryUpdate]  
 @Id int,  
 @DateTimeScheduled datetime,  
 @AppointmentLength int = null,  
 @DieditOleh varchar(20) = null  
AS  
BEGIN TRANSACTION  
BEGIN TRY  
 SET NOCOUNT ON;  
  
 UPDATE AppointmentDiary SET DateTimeScheduled = @DateTimeScheduled, AppointmentLength = @AppointmentLength, DieditOleh = @DieditOleh, DieditTanggal = getdate() WHERE Id = @Id  
  
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
