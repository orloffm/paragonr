# Local development

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
