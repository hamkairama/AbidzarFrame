SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDokumentasiDetailJenisKegiatanSelect]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @Id > 0 
		begin 
			select ddjk.*, djk.NamaKegiatan 
			from TbDokumentasiDetailJenisKegiatan ddjk
			inner join TbDetailJenisKegiatan djk on djk.Id = ddjk.IdDetailJenisKegiatan
			where ddjk.Id = @Id
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
