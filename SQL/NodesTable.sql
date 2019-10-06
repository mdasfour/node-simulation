﻿USE [NodeSimulation]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nodes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NodeId] [int] NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[OnlineTime] [datetime] NULL,
	[IsOnline] [bit] NOT NULL,
	[UploadUtilization] [decimal](7, 2) NULL,
	[MaxUploadUtilization] [decimal](7, 2) NULL,
	[UploadUtilizationExceeded]  AS (case when [UploadUtilization]>[MaxUploadUtilization] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end) PERSISTED,
	[DownloadUtilization] [decimal](7, 2) NULL,
	[MaxDownloadUtilization] [decimal](7, 2) NULL,
	[DownloadUtilizationExceeded]  AS (case when [DownloadUtilization]>[MaxDownloadUtilization] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end) PERSISTED,
	[ErrorRate] [decimal](7, 2) NULL,
	[MaxErrorRate] [decimal](7, 2) NULL,
	[ErrorRateExceeded]  AS (case when [ErrorRate]>[MaxErrorRate] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end) PERSISTED,
	[ConnectedClients] [int] NULL,
	[MaxConnectedClients] [int] NULL,
	[ConnectedClientsExceeded]  AS (case when [ConnectedClients]>[MaxConnectedClients] AND [Deleted]=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end) PERSISTED,
	[Deleted] [bit] NOT NULL,
	[InsertedDT] [datetime] NOT NULL,
	[UpdatedDT] [datetime] NULL,
	[DeletedDT] [datetime] NULL,
 CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_City] ON [dbo].[Nodes]
(
	[City] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted] ON [dbo].[Nodes]
(
	[Deleted] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Node_Id] ON [dbo].[Nodes]
(
	[NodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Nodes] ADD  CONSTRAINT [DF__tmp_ms_xx__IsOnl__2D27B809]  DEFAULT ((0)) FOR [IsOnline]
GO

ALTER TABLE [dbo].[Nodes] ADD  CONSTRAINT [DF__tmp_ms_xx__Delet__2E1BDC42]  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[Nodes] ADD  CONSTRAINT [DF__Nodes__InsertedD__300424B4]  DEFAULT (getdate()) FOR [InsertedDT]
GO


