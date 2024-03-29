SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpStrukturUpdateByDrag]
	@IdKtp varchar(16),
	@NamaJabatan varchar(200),	
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;	
	declare @IdJabatan int

	select @IdJabatan = id from TbJabatan where NamaJabatan =  REPLACE(REPLACE(@NamaJabatan, '_0', ''), '_1', '')
	Update TbStruktur set IdJabatan = @IdJabatan, DieditOleh = @DieditOleh, DieditTanggal = getdate() where IdKtp = @IdKtp
END



GO
