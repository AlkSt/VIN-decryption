--����
--sp_configure 'show advanced options', 1;
--RECONFIGURE;
--GO
--sp_configure 'Ad Hoc Distributed Queries', 1;
--RECONFIGURE;
--GO

--���� 
--USE [master] 
--GO 

--EXEC master . dbo. sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0' , N'AllowInProcess' , 1 
--GO 

--EXEC master . dbo. sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0' , N'DynamicParameters' , 1 
--GO 

--��� ���
--EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1
--GO
--EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1
--GO

--������� ������ ��� ���� ��� � �� ������ ����� � ������ ������ �������
--EXEC sp_addlinkedserver
--    @server = 'ExServer',
--    @srvproduct = 'Excel', 
--    @provider = 'Microsoft.ACE.OLEDB.12.0',
--    @datasrc = 'D:Kniga1.xlsx',
--    @provstr = 'Excel 12.0;IMEX=1;HDR=YES;'

--����� � �������(����� �������)
--SELECT * FROM ExcelServer...[producter$]
SELECT * FROM OPENQUERY(ExServer, 'SELECT * FROM [producter$]')

--����� � �������
INSERT INTO productionTable (code, decrypte, id_firm) SELECT *
FROM OPENQUERY(ExcelServer, 'SELECT * FROM [producter$]')

--��������� ����� � �������
--SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', N'Excel 8.0;Database=D:Kniga1.xlsx', 
--'SELECT * FROM [producter$]')

--��������� �� ����� �������������� � ������� ��� ����� ACE