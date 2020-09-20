--надо
--sp_configure 'show advanced options', 1;
--RECONFIGURE;
--GO
--sp_configure 'Ad Hoc Distributed Queries', 1;
--RECONFIGURE;
--GO

--тоже 
--USE [master] 
--GO 

--EXEC master . dbo. sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0' , N'AllowInProcess' , 1 
--GO 

--EXEC master . dbo. sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0' , N'DynamicParameters' , 1 
--GO 

--или так
--EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1
--GO
--EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1
--GO

--создает ресурс для того что б не писать много в строке вызова функции
--EXEC sp_addlinkedserver
--    @server = 'ExServer',
--    @srvproduct = 'Excel', 
--    @provider = 'Microsoft.ACE.OLEDB.12.0',
--    @datasrc = 'D:Kniga1.xlsx',
--    @provstr = 'Excel 12.0;IMEX=1;HDR=YES;'

--вывод в консоль(любой покатит)
--SELECT * FROM ExcelServer...[producter$]
SELECT * FROM OPENQUERY(ExServer, 'SELECT * FROM [producter$]')

--вброс с таблицу
INSERT INTO productionTable (code, decrypte, id_firm) SELECT *
FROM OPENQUERY(ExcelServer, 'SELECT * FROM [producter$]')

--прописать прямо в запросе
--SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', N'Excel 8.0;Database=D:Kniga1.xlsx', 
--'SELECT * FROM [producter$]')

--ВЫПОЛНЯТЬ ОТ ИМЕНИ АДМИНИСТРАТОРА И СКАЧАТЬ ДОП ПАКЕТ ACE