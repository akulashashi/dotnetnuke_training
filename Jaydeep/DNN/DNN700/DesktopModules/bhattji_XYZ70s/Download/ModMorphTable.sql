if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bhattji_ModMorphs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bhattji_ModMorphs]
GO

CREATE TABLE [dbo].[bhattji_ModMorphs] (

	[ItemID] [int] IDENTITY (1, 1) NOT NULL ,
	[ModuleID] [int] NOT NULL ,
	[Title] [nvarchar] (100) COLLATE  NULL ,

	[ImgSrc] [nvarchar] (100) COLLATE  NULL ,
	[ImgWidth] [nvarchar] (10) COLLATE  NULL ,
	[ImgHeight] [nvarchar] (10) COLLATE  NULL ,

	[ImgMoSrc] [nvarchar] (100) COLLATE  NULL ,
	[ImgBgSrc] [nvarchar] (100) COLLATE  NULL ,

	[MusicSrc] [nvarchar] (100) COLLATE  NULL ,
	[AltText] [nvarchar] (100) COLLATE  NULL ,
	[Player] [nvarchar] (10) COLLATE  NULL ,
	[uiMode] [nvarchar] (10) COLLATE  NULL ,
	[RepeatCount] [int] NULL ,
	[FlashVars] [nvarchar] (500) COLLATE  NULL,
	[Hour] [int] NULL ,
	[Minute] [int] NULL  ,

	[Description] [nvarchar] (2000) COLLATE  NULL ,
	[NavURL] [nvarchar] (250) COLLATE  NULL ,
	[PublishDate] [datetime] NULL ,
	[ExpireDate] [datetime] NULL  ,
	[ViewOrder] [int] NULL ,
	[CreatedByUser] [nvarchar] (100) COLLATE  NULL ,
	[CreatedDate] [datetime] NULL ,
	[RatingVotes] [int] NULL ,
	[RatingTotal] [int] NULL

) ON [PRIMARY]
GO

