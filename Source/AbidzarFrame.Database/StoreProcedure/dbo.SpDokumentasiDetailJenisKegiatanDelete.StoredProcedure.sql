SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpDokumentasiDetailJenisKegiatanDelete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	Delete TbDokumentasiDetailJenisKegiatan where Id = @Id

END



GO
