SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpSignatureKtpUpdate]
	@Id int,
	@NamaFile varchar(16),
	@DieditOleh varchar(20)

AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbSignatureKtp set NamaFile = @NamaFile, DieditOleh = @DieditOleh, DieditTanggal = GETDATE()
	where Id = @Id
END



GO
