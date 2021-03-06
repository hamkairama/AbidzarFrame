SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpStrukturUpdate]
	@Id int,
	@IdKtp varchar(16),
	@IdJabatan int,
	@AwalPeriode datetime,
	@AkhirPeriode datetime,
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbStruktur set IdKtp = @IdKtp, IdJabatan = @IdJabatan, AwalPeriode = @AwalPeriode,
	AkhirPeriode = @AkhirPeriode, DieditOleh = @DieditOleh, DieditTanggal = getdate() where Id = @Id
END



GO
