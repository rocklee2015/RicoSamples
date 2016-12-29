IF OBJECT_ID( '[dbo].[P_ORDER_U]', 'P' ) IS NOT NULL
	DROP  PROCEDURE  [dbo].[P_ORDER_U]
GO

CREATE PROCEDURE [dbo].[P_ORDER_U]
(
	@p_id               [VARCHAR],
	@p_date             [DATETIME],
	@p_supplier         [VARCHAR],
	@p_total_price      [FLOAT],
	@p_created_by       [VARCHAR],
	@p_created_on       [DATETIME],
	@p_last_updated_by  [VARCHAR],
	@p_last_updated_on  [DATETIME],
	@p_version_no       [TIMESTAMP],
	@p_transaction_id   [VARCHAR]
)
AS
   
	UPDATE [dbo].[T_ORDER]
	SET
		[DATE]              = @p_date,
		[SUPPLIER]          = @p_supplier,
		[TOTAL_PRICE]       = @p_total_price,
		[CREATED_BY]        = @p_created_by,
		[CREATED_ON]        = @p_created_on,
		[LAST_UPDATED_BY]   = @p_last_updated_by,
		[LAST_UPDATED_ON]   = @p_last_updated_on,
		[VERSION_NO]        = @p_version_no,
		[TRANSACTION_ID]    = @p_transaction_id
	WHERE
		[ID]                = @p_id AND
		[VERSION_NO]        = @p_version_no

GO
