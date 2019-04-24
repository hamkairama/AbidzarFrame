SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpJenisKegiatanUpdate]
	@Id int,
	@JenisKegiatan varchar(20),
	@Deskripsi varchar(100),
	@DieditOleh varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	Update TbJenisKegiatan set JenisKegiatan = @JenisKegiatan, Deskripsi = @Deskripsi, DieditOleh = @DieditOleh, DieditTanggal = getdate() where id = @Id
END


GO
