SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpJenisPekerjaanUpdate]
	@Id int,
	@JenisPekerjaan char(20),
	@DieditOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	Update TbJenisPekerjaan set JenisPekerjaan = @JenisPekerjaan, DieditOleh = @DieditOleh, DieditTanggal = GETDATE() where Id = @Id
END


GO
