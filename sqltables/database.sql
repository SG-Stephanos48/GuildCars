USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='GuildCar')
DROP DATABASE GuildCar
GO

CREATE DATABASE GuildCar
GO

USE GuildCar
GO
