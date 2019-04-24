SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpJenisInformasiSelect]
	@Id int,
	@KodeRt varchar(20) = null
AS
BEGIN
	SET NOCOUNT ON;

	if	@Id > 0
		begin
			select * from TbJenisInformasi where Id = @Id and (KodeRt = @KodeRt or @KodeRt is null)
		end
	else
		begin 
			select * from TbJenisInformasi where (KodeRt = @KodeRt or @KodeRt is null)
		end
END


GO
