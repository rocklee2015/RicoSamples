
/****** Object:  Table [dbo].[T_ORDER_DETAIL]    Script Date: 10/22/2010 15:16:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ORDER_DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[T_ORDER_DETAIL]
GO

CREATE TABLE [dbo].[T_ORDER_DETAIL](
	[ID] [varchar](50) NOT NULL,
	[PRODUCT_ID] [varchar](50) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[TOTAL_PRICE] [float] NOT NULL,
	[CREATED_BY] [varchar](50) NULL,
	[CREATED_ON] [datetime] NULL,
	[LAST_UPDATED_BY] [varchar](50) NULL,
	[LAST_UPDATED_ON] [datetime] NULL,
	[VERSION_NO] [timestamp] NULL,
	[TRANSACTION_ID] [varchar](50) NULL,
	CONSTRAINT [PK_T_ORDER_DETAIL] PRIMARY KEY CLUSTERED
	(
		[ID] ASC, [PRODUCT_ID] ASC
	)
	) 

GO