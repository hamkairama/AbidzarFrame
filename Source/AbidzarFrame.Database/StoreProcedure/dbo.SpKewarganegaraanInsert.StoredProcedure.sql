SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpKewarganegaraanInsert]
	@JenisKewarganegaraan varchar(3),
	@DibuatOleh varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	
	Insert into TbKewarganegaraan (JenisKewarganegaraan, DibuatOleh)
	values (@JenisKewarganegaraan, @DibuatOleh)
END



GO
