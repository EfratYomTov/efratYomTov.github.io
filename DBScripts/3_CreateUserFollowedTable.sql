USE [Twitter]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS  (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserFollowed') 
	DROP TABLE [dbo].[UserFollowed];


GO
CREATE TABLE [dbo].[UserFollowed] (
    [ID]             INT IDENTITY (1, 1) NOT NULL,
    [UserID]         INT NOT NULL,
    [UserFollowedID] INT NOT NULL,

	CONSTRAINT PK_UserFollowed_ID PRIMARY KEY (ID),

	CONSTRAINT UC_UserFollowed_UserID_UserFollowedID UNIQUE(UserID, UserFollowedID),
	
	CONSTRAINT FK_UserFollowed_UserID  FOREIGN KEY (UserID)
        REFERENCES Twitter.dbo.Users (ID),
        
    CONSTRAINT FK_UserFollowed_UserFollowedID  FOREIGN KEY (UserFollowedID)
        REFERENCES Twitter.dbo.Users (ID),
);


