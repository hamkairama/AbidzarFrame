SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpKewarganegaraanSelect]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	
	if @Id > 0
		begin
			select * from TbKewarganegaraan where Id = @Id
		end
	else
		begin	
			select * from TbKewarganegaraan
		end
END



GO
