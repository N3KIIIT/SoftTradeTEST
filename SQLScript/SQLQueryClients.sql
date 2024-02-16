

CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) Primary KEY NOT NULL ,
	[Name] [nvarchar](max) NOT NULL,
	[StatusId] [int] NOT NULL,
	[ManagerId] [int] NOT NULL,
	[ProductId] [int],
	CONSTRAINT [FK_Clients_ClientStatuses_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ClientStatuses] ([Id]),
CONSTRAINT [FK_Clients_Managers_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Managers] ([Id]),
CONSTRAINT [FK_Clients_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
)

