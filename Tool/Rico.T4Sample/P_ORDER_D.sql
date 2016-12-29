IF OBJECT_ID( '[dbo].[P_ORDER_D]', 'P' ) IS NOT NULL
	DROP  PROCEDURE  [dbo].[P_ORDER_D]
GO

CREATE PROCEDURE [dbo].[P_ORDER_D]
(
	@p_id               [VARCHAR],
	@p_version_no       [TIMESTAMP]
)
AS
   
	DELETE FROM [dbo].[T_ORDER]
	WHERE
			ID                  = @p_id AND
			VERSION_NO          = @p_version_no

GO
