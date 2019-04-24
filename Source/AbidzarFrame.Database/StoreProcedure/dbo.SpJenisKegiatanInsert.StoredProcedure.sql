SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpJenisKegiatanInsert]
	@JenisKegiatan varchar(20),
	@Deskripsi varchar(100),
	@DibuatOleh varchar(100),
	@KodeRt varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	Insert TbJenisKegiatan (JenisKegiatan, Deskripsi, DibuatOleh, KodeRt) 
	values (@JenisKegiatan, @Deskripsi, @DibuatOleh, @KodeRt)

END


GO
