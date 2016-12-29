IF OBJECT_ID( '[dbo].[P_PRODUCT_I]', 'P' ) IS NOT NULL
	DROP  PROCEDURE  [dbo].[P_PRODUCT_I]
GO

CREATE PROCEDURE [dbo].[P_PRODUCT_I]
(
	@p_id               [VARCHAR],
	@p_name             [NVARCHAR],
	@p_price            [FLOAT],
	@p_total_price      [FLOAT],
	@p_desc             [NVARCHAR],
	@p_created_by       [VARCHAR],
	@p_created_on       [DATETIME],
	@p_last_updated_by  [VARCHAR],
	@p_last_updated_on  [DATETIME],
	@p_transaction_id   [VARCHAR]
)
AS
   
	INSERT INTO [dbo].[T_PRODUCT]
	(
		[ID],
		[NAME],
		[PRICE],
		[TOTAL_PRICE],
		[DESC],
		[CREATED_BY],
		[CREATED_ON],
		[LAST_UPDATED_BY],
		[LAST_UPDATED_ON],
		[TRANSACTION_ID]
	)
	VALUES
	(
		@p_id,
		@p_name,
		@p_price,
		@p_total_price,
		@p_desc,
		@p_created_by,
		@p_created_on,
		@p_last_updated_by,
		@p_last_updated_on,
		@p_transaction_id
	)

GO
