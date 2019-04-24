SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpJenisInformasiInsert]
	@JenisInformasi varchar(20),
	@DibuatOleh varchar(20),
	@KodeRt varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	Insert into TbJenisInformasi (JenisInformasi, DibuatOleh, KodeRt) 
	values (@JenisInformasi, @DibuatOleh, @KodeRt)
END


GO
