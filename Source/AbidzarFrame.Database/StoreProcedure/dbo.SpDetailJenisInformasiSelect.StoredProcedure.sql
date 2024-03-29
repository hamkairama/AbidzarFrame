SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisInformasiSelect]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @Id > 0
		BEGIN
			SELECT dji.*, ji.JenisInformasi 
			FROM TbDetailJenisInformasi dji
			INNER JOIN TbJenisInformasi ji ON ji.Id = dji.IdJenisInformasi
			WHERE dji.Id = @Id
		END
	ELSE
		BEGIN
			SELECT dji.*, ji.JenisInformasi 
			FROM TbDetailJenisInformasi dji
			INNER JOIN TbJenisInformasi ji ON ji.Id = dji.IdJenisInformasi
		END

END



GO
