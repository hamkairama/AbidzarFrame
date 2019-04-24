SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpJenisKegiatanSelect]
	@Id int,
	@KodeRt varchar(20) = null
AS
BEGIN
	SET NOCOUNT ON;

	if @id > 0 
		begin
			select * from TbJenisKegiatan where Id = @Id and  (KodeRt = @KodeRt or @KodeRt is null)
		end
	else
		begin
			select * from TbJenisKegiatan where (KodeRt = @KodeRt or @KodeRt is null)
		end
END


GO
