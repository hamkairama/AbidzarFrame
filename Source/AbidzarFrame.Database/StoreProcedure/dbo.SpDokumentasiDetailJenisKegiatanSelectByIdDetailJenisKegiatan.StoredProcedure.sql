SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDokumentasiDetailJenisKegiatanSelectByIdDetailJenisKegiatan]
	@IdDetailJenisKegiatan int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @IdDetailJenisKegiatan > 0 
		begin 
			select ddjk.*, djk.NamaKegiatan 
			from TbDokumentasiDetailJenisKegiatan ddjk
			inner join TbDetailJenisKegiatan djk on djk.Id = ddjk.IdDetailJenisKegiatan
			where ddjk.IdDetailJenisKegiatan = @IdDetailJenisKegiatan
		end
	else
		begin
			select ddjk.*, djk.NamaKegiatan 
			from TbDokumentasiDetailJenisKegiatan ddjk
			inner join TbDetailJenisKegiatan djk on djk.Id = ddjk.IdDetailJenisKegiatan
			select * from TbDokumentasiDetailJenisKegiatan
		end

END



GO
