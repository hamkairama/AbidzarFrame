SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hamka Irama
-- Create date: Agustus 2018
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpKtpDelete]
	@Id int

AS
BEGIN
	SET NOCOUNT ON;
	
	Delete TbKtp where Id = @Id
END



GO
