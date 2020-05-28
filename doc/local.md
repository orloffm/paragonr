# Local development

## Linux: Installing SQL Server

Install Docker: http://gooseberryseedspittingcontest.com/post/xubuntu_notes/#docker

Run the container: http://gooseberryseedspittingcontest.com/post/xubuntu_notes/#sql-server-developer-edition

Install Azure Data Studio: http://gooseberryseedspittingcontest.com/post/xubuntu_notes/#azure-data-studio

## Setting up SQL Server

Create the user:

```
-- On master:
USE master;
GO

CREATE LOGIN paragonr_user
WITH PASSWORD = 'paragonr_password_A1'
GO

CREATE USER paragonr_user
FOR LOGIN paragonr_user
WITH DEFAULT_SCHEMA = dbo
GO

-- Now create the database:

CREATE DATABASE Paragonr
GO

USE Paragonr;
GO

CREATE USER paragonr_user
FOR LOGIN paragonr_user
WITH DEFAULT_SCHEMA = dbo
GO

-- Add user to the database roles you want
EXEC sp_addrolemember N'db_owner', N'paragonr_user'
GO
```
