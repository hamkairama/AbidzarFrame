SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDetailJenisInformasiDelete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	Delete TbDetailJenisInformasi where Id = @Id

END



GO
