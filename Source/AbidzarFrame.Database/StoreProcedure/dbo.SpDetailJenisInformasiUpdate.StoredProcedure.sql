SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisInformasiUpdate]
	@Id int,
	@Judul varchar(100),
	@IdJenisInformasi int,
	@NamaFile varchar(16) = null,
	@Deskripsi text,
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbDetailJenisInformasi set IdJenisInformasi = @IdJenisInformasi, Judul = @Judul, NamaFile = @NamaFile, Deskripsi = @Deskripsi,
	DieditOleh = @DieditOleh, DieditTanggal = GETDATE() where Id = @Id

END



GO
