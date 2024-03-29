SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisKegiatanSelect]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @Id > 0
		begin
			select djk.*, jk.JenisKegiatan 
			from TbDetailJenisKegiatan  djk
			inner join TbJenisKegiatan jk on jk.Id = djk.IdJenisKegiatan
			where djk.Id = @Id
		end
	else	
		begin	
			select djk.*, jk.JenisKegiatan 
			from TbDetailJenisKegiatan  djk
			inner join TbJenisKegiatan jk on jk.Id = djk.IdJenisKegiatan
		end

END



GO
