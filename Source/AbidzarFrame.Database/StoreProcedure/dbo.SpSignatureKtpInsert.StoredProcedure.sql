SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpSignatureKtpInsert]
	@NamaFile varchar(16),
	@DibuatOleh varchar(20)

AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbSignatureKtp (NamaFile, DibuatOleh)
	values (@NamaFile, @DibuatOleh)
END



GO
