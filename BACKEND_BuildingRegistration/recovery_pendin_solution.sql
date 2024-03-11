ALTER DATABASE [BuildingRegistration] SET EMERGENCY;
GO

ALTER DATABASE [BuildingRegistration] set single_user
GO

DBCC CHECKDB ([BuildingRegistration], REPAIR_ALLOW_DATA_LOSS) WITH ALL_ERRORMSGS;
GO 

ALTER DATABASE [BuildingRegistration] set multi_user
GO