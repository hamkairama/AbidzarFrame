SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpKewarganegaraanUpdate]
	@Id int,
	@JenisKewarganegaraan varchar(3),
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Update TbKewarganegaraan set JenisKewarganegaraan = @JenisKewarganegaraan, DieditOleh = @DieditOleh, 
	DieditTanggal = GETDATE() where Id = @Id
END



GO
