CREATE TABLE [dbo].[Articles] (
    [id]    UNIQUEIDENTIFIER CONSTRAINT [DF_Articles_id] DEFAULT (newid()) NOT NULL,
    [title] NVARCHAR (MAX)   NOT NULL,
    [text]  NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([id] ASC)
);

