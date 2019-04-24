SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpPhotoKtpUpdate]
	@Id int,
	@NamaFile varchar(200),
	@DieditOleh varchar(20)

AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbPhotoKtp set NamaFile = @NamaFile, DieditOleh = @DieditOleh, DieditTanggal = GETDATE()
	where Id = @Id
END



GO
