﻿USE [Twitter]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS  (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tweets') 
	DROP TABLE [dbo].[Tweets];


GO
CREATE TABLE [dbo].[Tweets] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [UserID]    INT            NOT NULL,
    [Content]   NVARCHAR (100) NOT NULL,
    [DateAdded] DATETIME       NOT NULL,

	CONSTRAINT PK_Tweets_ID PRIMARY KEY (ID),
	
	CONSTRAINT FK_Tweets_UserID  FOREIGN KEY (UserID)
        REFERENCES Twitter.dbo.Users (ID)
        ON DELETE CASCADE,
);

