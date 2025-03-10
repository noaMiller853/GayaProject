create database GayaProject

create table Operation(Id int primary key IDENTITY(1, 1),Operation nvarchar(2))
create table Arguments(Id int primary key IDENTITY(1, 1),FieldOne nvarchar(20),FieldTwo nvarchar(20),Result nvarchar(30)
, OperationId int FOREIGN KEY REFERENCES Operation(Id),DateResult date)

INSERT INTO [dbo].[Operation] (Operation)
VALUES ('-'),
 ('+'),
 ('/'),
 ('*')


create procedure SelectResultTop3ByOperator @Id int
as
begin
    select top 3 *
    from [dbo].[Arguments]
    where [OperationId] = @Id;
end;
go

create procedure SelectCountExcuteByDate @Id int
as
begin
select count(id) as CountId from [dbo].[Arguments]
where [OperationId]=@Id and MONTH([DateResult])=Month(GETDATE())
end;
go


