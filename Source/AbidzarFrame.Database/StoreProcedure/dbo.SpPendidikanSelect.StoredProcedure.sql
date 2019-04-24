SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpPendidikanSelect]
	@Id int
	
AS
BEGIN
	SET NOCOUNT ON;

	if @Id > 0 
		begin
			select * from TbPendidikan where Id = @Id
		end
	else
		begin 
			select * from TbPendidikan
		end

END



GO
