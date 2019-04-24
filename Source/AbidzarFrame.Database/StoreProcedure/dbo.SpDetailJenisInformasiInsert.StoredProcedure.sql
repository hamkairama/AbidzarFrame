SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisInformasiInsert]
	@IdJenisInformasi int,
	@Judul varchar(100),
	@NamaFile varchar(16) = null,
	@Deskripsi text,
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbDetailJenisInformasi (IdJenisInformasi, Judul, NamaFile, Deskripsi, DibuatOleh)
	values (@IdJenisInformasi, @Judul, @NamaFile, @Deskripsi, @DibuatOleh)

END



GO
