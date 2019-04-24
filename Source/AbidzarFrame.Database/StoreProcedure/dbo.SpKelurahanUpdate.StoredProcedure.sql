SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpKelurahanUpdate]
	@Id int,
	@IdKecamatan int,
	@KodeKelurahan varchar(20),
	@NamaKelurahan varchar(20),
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbKelurahan set IdKecamatan = @IdKecamatan, KodeKelurahan = @KodeKelurahan, NamaKelurahan = @NamaKelurahan, DieditOleh = @DieditOleh, DieditTanggal = GETDATE() 
	where Id = @Id

END



GO
