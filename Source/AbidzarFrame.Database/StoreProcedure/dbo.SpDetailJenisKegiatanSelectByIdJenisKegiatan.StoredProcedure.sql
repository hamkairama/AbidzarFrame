SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisKegiatanSelectByIdJenisKegiatan]
	@IdJenisKegiatan int
AS
BEGIN
	SET NOCOUNT ON;
	
	select djk.*, jk.JenisKegiatan 
	from TbDetailJenisKegiatan  djk
	inner join TbJenisKegiatan jk on jk.Id = djk.IdJenisKegiatan
	where djk.IdJenisKegiatan = @IdJenisKegiatan

END



GO
