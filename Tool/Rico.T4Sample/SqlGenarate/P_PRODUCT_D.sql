    



IF OBJECT_ID( '[dbo].[P_PRODUCT_D]', 'P' ) IS NOT NULL
	DROP  PROCEDURE  [dbo].[P_PRODUCT_D]
GO

CREATE PROCEDURE [dbo].[P_PRODUCT_D]
(
	@p_id               [VARCHAR],
	@p_version_no       [TIMESTAMP]
)
AS
   
	DELETE FROM [dbo].[T_PRODUCT]
	WHERE
			ID                  = @p_id AND
			VERSION_NO          = @p_version_no

GO