CREATE TABLE [dbo].[ClientStatuses](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Status] [nvarchar](max) NOT NULL
)

INSERT INTO [dbo].[ClientStatuses]([Status]) 
VALUES('OrdinaryClient')

INSERT INTO [dbo].[ClientStatuses]([Status]) 
VALUES('KeyClient')

