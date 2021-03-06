SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpStrukturInsert]
	@IdKtp varchar(16),
	@IdJabatan int,
	@AwalPeriode datetime,
	@AkhirPeriode datetime,
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbStruktur (IdKtp, IdJabatan, AwalPeriode, AkhirPeriode, DibuatOleh)
	values (@IdKtp, @IdJabatan, @AwalPeriode, @AkhirPeriode, @DibuatOleh)
END



GO
