SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDokumentasiDetailJenisKegiatanInsert]
	@IdDetailJenisKegiatan int,
	@NamaFile varchar(500),
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbDokumentasiDetailJenisKegiatan (IdDetailJenisKegiatan, NamaFile, DibuatOleh)
	values (@IdDetailJenisKegiatan, @NamaFile, @DibuatOleh)
END



GO
