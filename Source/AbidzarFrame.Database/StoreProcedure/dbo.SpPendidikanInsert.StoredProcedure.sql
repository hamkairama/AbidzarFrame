SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpPendidikanInsert]
	@Pendidikan varchar(20),
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	Insert into TbPendidikan (Pendidikan, DibuatOleh) values (@Pendidikan, @DibuatOleh)

END



GO
