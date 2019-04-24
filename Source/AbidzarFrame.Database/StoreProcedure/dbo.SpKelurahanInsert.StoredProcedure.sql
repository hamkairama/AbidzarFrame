SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKelurahanInsert]
	@IdKecamatan int,
	@KodeKelurahan varchar(20),
	@NamaKelurahan varchar(20),
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbKelurahan(IdKecamatan, KodeKelurahan, NamaKelurahan, DibuatOleh) 
	values (@IdKecamatan, @KodeKelurahan, @NamaKelurahan, @DibuatOleh)

END



GO
