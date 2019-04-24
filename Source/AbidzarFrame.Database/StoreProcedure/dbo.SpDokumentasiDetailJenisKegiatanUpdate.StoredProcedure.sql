SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDokumentasiDetailJenisKegiatanUpdate]
	@Id int,
	@IdDetailJenisKegiatan int,
	@NamaFile varchar(500),
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbDokumentasiDetailJenisKegiatan set IdDetailJenisKegiatan = @IdDetailJenisKegiatan, NamaFile = @NamaFile,
	DieditOleh = @DieditOleh, DieditTanggal =GETDATE() where Id = @id
END



GO
